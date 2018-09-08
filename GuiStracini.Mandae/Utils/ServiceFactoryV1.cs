// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 05/01/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 05/01/2018
// ***********************************************************************
// <copyright file="ServiceFactoryV1.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Utils
{
    using Enums;
    using GoodPractices;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Transport;

    /// <summary>
    /// This class is a utility helper that performs the request to the API using an inherited <see cref = "BaseRequest" /> class
    /// </summary>
    public sealed class ServiceFactoryV1
    {
        #region Private fields

        /// <summary>
        /// The constants
        /// </summary>
        private readonly Dictionary<String, String> _constants;

        /// <summary>
        /// The configure await flag.
        /// </summary>
        private readonly Boolean _configureAwait;

        /// <summary>
        /// The constants pattern
        /// </summary>
        private readonly Regex _constantsPathPattern = new Regex(@"(\/app\/(?:.+?)\.constants\.js)", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        /// <summary>
        /// The constant pattern
        /// </summary>
        private readonly Regex _constantsPattern = new Regex(@"\.constant\(\'(?<key>.+?)\',\s?\'(?<value>.+?)\'\)", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        /// <summary>
        /// The API authorization
        /// </summary>
        private String _apiAuthorization;

        #endregion

        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFactoryV1"/> class.
        /// </summary>
        /// <param name="configureAwait">if set to <c>true</c> [configure await].</param>
        public ServiceFactoryV1(Boolean configureAwait = true)
        {
            _configureAwait = configureAwait;
            _constants = new Dictionary<String, String>();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Gets the constants.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// Cannot get the constants path
        /// or
        /// Cannot get the constants
        /// </exception>
        private async Task<Boolean> GetConstants(CancellationToken cancellationToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://app.mandae.com.br/");
                client.DefaultRequestHeaders.ExpectContinue = false;
                var response = await client.GetAsync("login", cancellationToken).ConfigureAwait(_configureAwait);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(_configureAwait);
                if (!_constantsPathPattern.IsMatch(content))
                    throw new InvalidOperationException("Cannot get the constants path");
                var match = _constantsPathPattern.Match(content);
                response = await client.GetAsync(match.Value, cancellationToken).ConfigureAwait(_configureAwait);
                content = await response.Content.ReadAsStringAsync().ConfigureAwait(_configureAwait);
                if (!_constantsPattern.IsMatch(content))
                    throw new InvalidOperationException("Cannot get the constants");
                var matches = _constantsPattern.Matches(content);
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
        /// <returns></returns>
        private async Task<TOut> Execute<TOut, TIn>(
            ActionMethod method,
            TIn requestObject,
            CancellationToken cancellationToken)
            where TIn : BaseRequest
            where TOut : BaseResponse
        {
            var endpoint = String.Concat(requestObject.GetRequestEndPoint(), requestObject.GetRequestAdditionalParameter(method));
            var baseEndpoint = "https://pedido.api.mandae.com.br";
            if (_constants.ContainsKey("URLAPIPEDIDO_NGINX"))
                baseEndpoint = _constants["URLAPIPEDIDO_NGINX"];
            var attribute = requestObject.GetRequestEndPointAttribute();
            if (attribute != null &&
                !String.IsNullOrWhiteSpace(attribute.CustomBase) &&
                _constants.ContainsKey(attribute.CustomBase))
                baseEndpoint = _constants[attribute.CustomBase];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseEndpoint);
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.ParseAdd(@"GuiStracini.Mandae/3.0.0");
                client.DefaultRequestHeaders.Referrer = new Uri(_constants["URL_SITE"]);
                client.DefaultRequestHeaders.Add("API-TOKEN", _constants["API_TOKEN"]);
                if (!String.IsNullOrWhiteSpace(_apiAuthorization))
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
                            response = await client.GetAsync(endpoint, cancellationToken).ConfigureAwait(_configureAwait);
                            break;
                        case ActionMethod.POST:
                            response = await client.PostAsync(endpoint, requestObject, formatter, cancellationToken).ConfigureAwait(_configureAwait);
                            break;
                        case ActionMethod.PUT:
                            response = await client.PutAsync(endpoint, requestObject, formatter, cancellationToken).ConfigureAwait(_configureAwait);
                            break;
                        case ActionMethod.DELETE:
                            response = await client.DeleteAsync(endpoint, cancellationToken).ConfigureAwait(_configureAwait);
                            return (TOut)Convert.ChangeType(response.StatusCode, typeof(TOut));
                        default:
                            throw new HttpRequestException($"Requested method {method} not implemented in V1");
                    }
                    return await response.Content.ReadAsAsync<TOut>(cancellationToken).ConfigureAwait(_configureAwait);
                }
                catch (HttpRequestException e)
                {
                    throw new MandaeAPIException(requestObject.GetRequestEndPoint(), e);
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
        public async Task<String> LoginAsync(String email, String password, CancellationToken cancellationToken)
        {
            if (_constants.Count == 0 && !await GetConstants(cancellationToken).ConfigureAwait(_configureAwait))
                throw new InvalidOperationException("Unable to get the constants");
            var request = new LoginRequest
            {
                Username = email,
                Password = password
            };
            var response = await Post<LoginResponse, LoginRequest>(request, cancellationToken).ConfigureAwait(_configureAwait);
            if(!String.IsNullOrWhiteSpace(response.Erro))
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
        /// <returns></returns>
        public async Task<TOut> Get<TOut, TIn>(TIn requestObject, CancellationToken token) where TIn : BaseRequest where TOut : BaseResponse
        {
            return await Execute<TOut, TIn>(ActionMethod.GET, requestObject, token).ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Posts the specified request object.
        /// </summary>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public async Task<TOut> Post<TOut, TIn>(TIn requestObject, CancellationToken token) where TIn : BaseRequest where TOut : BaseResponse
        {
            return await Execute<TOut, TIn>(ActionMethod.POST, requestObject, token).ConfigureAwait(_configureAwait);
        }

        #endregion
    }
}
