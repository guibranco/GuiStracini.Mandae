// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="ServiceFactory.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Utils
{
    using Enums;
    using GoodPractices;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Transport;
    using Environment = Enums.Environment;

    /// <summary>
    /// This class is a utility helper that performs the request to the API using an inherited <see cref = "BaseRequest" /> class
    /// </summary>
    internal sealed class ServiceFactory
    {
        /// <summary>
        /// The API environment
        /// </summary>
        private readonly Environment _environment;

        /// <summary>
        /// The sandbox environment service end point base address
        /// </summary>
        private const String SandboxServiceEndPoint = "https://sandbox.api.mandae.com.br/v2/";

        /// <summary>
        /// The production environment service end point base address
        /// </summary>
        private const String ProductionServiceEndPoint = "https://api.mandae.com.br/v2/";

        /// <summary>
        /// The configure await flag.
        /// </summary>
        private readonly Boolean _configureAwait;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFactory"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="configureAwait">The value used for <see cref="Task.ConfigureAwait"/> method.</param>
        public ServiceFactory(Environment environment, Boolean configureAwait = false)
        {
            _environment = environment;
            _configureAwait = configureAwait;
        }

        /// <summary>
        /// Executes the request in the specified HTTP <paramref name="method"/>.
        /// </summary>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <param name="method">The request HTTP method.</param>
        /// <param name="requestObject">The request object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns the response as <typeparamref name="TOut"/></returns>
        private async Task<TOut> Execute<TOut, TIn>(ActionMethod method, TIn requestObject, CancellationToken cancellationToken) where TIn : BaseRequest
        {
            var baseEndPoint = _environment == Environment.PRODUCTION
                                   ? ProductionServiceEndPoint
                                   : SandboxServiceEndPoint;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseEndPoint);
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!String.IsNullOrEmpty(requestObject.Token))
                    client.DefaultRequestHeaders.Add("X-LISTADECOMPRAS-KEY", requestObject.Token);

                var endpoint = String.Concat(requestObject.GetRequestEndPoint(), requestObject.GetRequestAdditionalParameter(method));
                try
                {
                    HttpResponseMessage response;
                    switch (method)
                    {
                        case ActionMethod.GET:
                            response = await client.GetAsync(endpoint, cancellationToken).ConfigureAwait(_configureAwait);
                            break;
                        case ActionMethod.POST:
                            response = await client.PostAsJsonAsync(endpoint, requestObject, cancellationToken).ConfigureAwait(_configureAwait);
                            break;
                        case ActionMethod.PUT:
                            response = await client.PutAsJsonAsync(endpoint, requestObject, cancellationToken).ConfigureAwait(_configureAwait);
                            break;
                        case ActionMethod.DELETE:
                            response = await client.DeleteAsync(endpoint, cancellationToken).ConfigureAwait(_configureAwait);
                            return (TOut)Convert.ChangeType(response.StatusCode, typeof(TOut));
                        default:
                            throw new HttpRequestException("Requested method not implemented");
                    }
                    return await response.Content.ReadAsAsync<TOut>(cancellationToken).ConfigureAwait(_configureAwait);
                }
                catch (HttpRequestException e)
                {
                    throw new MandaeAPIException(requestObject.GetRequestEndPoint(), e);
                }
            }
        }

        /// <summary>
        /// Gets the specified request object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> Get<T>(T requestObject, CancellationToken token) where T : BaseRequest
        {
            return await Execute<T, T>(ActionMethod.GET, requestObject, token).ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Gets the specified request object.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <typeparam name="TIn">The type of the t in.</typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        public async Task<TOut> Get<TOut, TIn>(TIn requestObject, CancellationToken token) where TIn : BaseRequest
        {
            return await Execute<TOut, TIn>(ActionMethod.GET, requestObject, token).ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Posts the specified request object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> Post<T>(T requestObject, CancellationToken token) where T : BaseRequest
        {
            return await Execute<T, T>(ActionMethod.POST, requestObject, token).ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Posts the specified request object.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <typeparam name="TIn">The type of the t in.</typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        public async Task<TOut> Post<TOut, TIn>(TIn requestObject, CancellationToken token) where TIn : BaseRequest
        {
            return await Execute<TOut, TIn>(ActionMethod.POST, requestObject, token).ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Puts the specified request object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> Put<T>(T requestObject, CancellationToken token) where T : BaseRequest
        {
            return await Execute<T, T>(ActionMethod.PUT, requestObject, token).ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Puts the specified request object.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <typeparam name="TIn">The type of the t in.</typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        public async Task<TOut> Put<TOut, TIn>(TIn requestObject, CancellationToken token) where TIn : BaseRequest
        {
            return await Execute<TOut, TIn>(ActionMethod.PUT, requestObject, token).ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Deletes the specified request object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> Delete<T>(T requestObject, CancellationToken token) where T : BaseRequest
        {
            return await Execute<T, T>(ActionMethod.DELETE, requestObject, token).ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Deletes the specified request object.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <typeparam name="TIn">The type of the t in.</typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        public async Task<TOut> Delete<TOut, TIn>(TIn requestObject, CancellationToken token) where TIn : BaseRequest
        {
            return await Execute<TOut, TIn>(ActionMethod.DELETE, requestObject, token).ConfigureAwait(_configureAwait);
        }
    }
}
