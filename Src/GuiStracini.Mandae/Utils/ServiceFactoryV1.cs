// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 2018-01-05
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="ServiceFactoryV1.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.Utils
{
    using Attributes;
    using GoodPractices;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using SDKBuilder;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Transport;
    using Transport.V1;
    using BaseResponse = Transport.BaseResponse;

    /// <summary>
    /// This class is a utility helper that performs the request to the API using an inherited <see cref="SDKBuilder.BaseRequest" /> class
    /// </summary>
    public sealed class ServiceFactoryV1
    {
        #region Private fields

        /// <summary>
        /// The constants
        /// </summary>
        private readonly Dictionary<string, string> _constants;

        /// <summary>
        /// The configure await flag.
        /// </summary>
        private readonly bool _configureAwait;

        /// <summary>
        /// The API authorization
        /// </summary>
        private string _apiAuthorization;

        #endregion

        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFactoryV1" /> class.
        /// </summary>
        /// <param name="configureAwait">if set to <c>true</c> [configure await].</param>
        public ServiceFactoryV1(bool configureAwait = true)
        {
            _configureAwait = configureAwait;
            _constants = new Dictionary<string, string>();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Gets the constants.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.InvalidOperationException">Cannot get the constants path</exception>
        /// <exception cref="System.InvalidOperationException">Cannot get the constants from file {match.Value}</exception>
        private async Task<bool> GetConstants(CancellationToken cancellationToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.DashboardEndpoint);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                client.DefaultRequestHeaders.Add("Keep-Alive", "timeout=600");
                client.DefaultRequestHeaders.UserAgent.ParseAdd(Constants.UserAgent);
                var response = await client
                    .GetAsync("login", cancellationToken)
                    .ConfigureAwait(_configureAwait);
                var content = await response.Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(_configureAwait);
                if (!Constants.PathPattern.IsMatch(content))
                    throw new InvalidOperationException("Cannot get the constants path");
                var match = Constants.PathPattern.Match(content);
                response = await client
                    .GetAsync(match.Value, cancellationToken)
                    .ConfigureAwait(_configureAwait);
                content = await response.Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(_configureAwait);
                if (!Constants.JsPattern.IsMatch(content))
                    throw new InvalidOperationException(
                        $"Cannot get the constants from file {match.Value}"
                    );
                match = Constants.JsPattern.Match(content);
                var matches = Constants.Pattern.Matches(match.Groups["constants"].Value);
                foreach (Match m in matches)
                    _constants.Add(m.Groups["key"].Value, m.Groups["value"].Value);
                return true;
            }
        }

        /// <summary>
        /// Executes the specified method.
        /// </summary>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="requestObject">The request object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>TOut.</returns>
        /// <exception cref="System.Net.Http.HttpRequestException">Requested method {method} not implemented in V1</exception>
        /// <exception cref="GuiStracini.Mandae.GoodPractices.MandaeApiException"></exception>
        private async Task<TOut> Execute<TOut, TIn>(
            ActionMethod method,
            TIn requestObject,
            CancellationToken cancellationToken
        )
            where TIn : Request
            where TOut : BaseResponse
        {
            var endpoint = string.Concat(
                requestObject.GetRequestEndPoint(),
                requestObject.GetRequestAdditionalParameter(method)
            );
            var baseEndpoint = "https://pedido.api.mandae.com.br";
            if (_constants.TryGetValue("URLAPIPEDIDO_NGINX", out var constant))
                baseEndpoint = constant;
            var attribute = (ExtendedEndpointRouteAttribute)
                requestObject.GetRequestEndPointAttribute();
            if (
                attribute != null
                && !string.IsNullOrWhiteSpace(attribute.CustomBase)
                && _constants.TryGetValue(attribute.CustomBase, out var constant1)
            )
                baseEndpoint = constant1;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseEndpoint);
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );
                client.DefaultRequestHeaders.UserAgent.ParseAdd(@"GuiStracini.Mandae/3.0.0");
                client.DefaultRequestHeaders.Referrer = new Uri(_constants["URL_SITE"]);
                client.DefaultRequestHeaders.Add("API-TOKEN", _constants["API_TOKEN"]);
                if (!string.IsNullOrWhiteSpace(_apiAuthorization))
                    client.DefaultRequestHeaders.Add("Authorization", _apiAuthorization);

                var formatter = new JsonMediaTypeFormatter
                {
                    SerializerSettings = new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented,
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        NullValueHandling = NullValueHandling.Ignore
                    }
                };

                try
                {
                    HttpResponseMessage response;
                    switch (method)
                    {
                        case ActionMethod.GET:
                            response = await client
                                .GetAsync(endpoint, cancellationToken)
                                .ConfigureAwait(_configureAwait);
                            break;
                        case ActionMethod.POST:
                            response = await client
                                .PostAsync(endpoint, requestObject, formatter, cancellationToken)
                                .ConfigureAwait(_configureAwait);
                            break;
                        case ActionMethod.PUT:
                            response = await client
                                .PutAsync(endpoint, requestObject, formatter, cancellationToken)
                                .ConfigureAwait(_configureAwait);
                            break;
                        case ActionMethod.DELETE:
                            response = await client
                                .DeleteAsync(endpoint, cancellationToken)
                                .ConfigureAwait(_configureAwait);
                            return (TOut)Convert.ChangeType(response.StatusCode, typeof(TOut));
                        default:
                            throw new HttpRequestException(
                                $"Requested method {method} not implemented in V1"
                            );
                    }

                    return await response.Content
                        .ReadAsAsync<TOut>(cancellationToken)
                        .ConfigureAwait(_configureAwait);
                }
                catch (HttpRequestException e)
                {
                    throw new MandaeApiException(requestObject.GetRequestEndPoint(), e);
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A Task&lt;System.String&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.InvalidOperationException">Unable to get the constants</exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public async Task<string> LoginAsync(
            string email,
            string password,
            CancellationToken cancellationToken
        )
        {
            if (
                _constants.Count == 0
                && !await GetConstants(cancellationToken).ConfigureAwait(_configureAwait)
            )
                throw new InvalidOperationException("Unable to get the constants");
            var request = new LoginRequest { Username = email, Password = password };
            var response = await Post<LoginResponse, LoginRequest>(request, cancellationToken)
                .ConfigureAwait(_configureAwait);
            if (!string.IsNullOrWhiteSpace(response.Erro))
                throw new InvalidOperationException(response.Erro);
            _apiAuthorization = response.Token;
            return _apiAuthorization;
        }

        /// <summary>
        /// Gets the specified request object.
        /// </summary>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>TOut.</returns>
        public async Task<TOut> Get<TOut, TIn>(TIn requestObject, CancellationToken token)
            where TIn : Request
            where TOut : BaseResponse
        {
            return await Execute<TOut, TIn>(ActionMethod.GET, requestObject, token)
                .ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Posts the specified request object.
        /// </summary>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>TOut.</returns>
        public async Task<TOut> Post<TOut, TIn>(TIn requestObject, CancellationToken token)
            where TIn : Request
            where TOut : BaseResponse
        {
            return await Execute<TOut, TIn>(ActionMethod.POST, requestObject, token)
                .ConfigureAwait(_configureAwait);
        }

        #endregion
    }
}