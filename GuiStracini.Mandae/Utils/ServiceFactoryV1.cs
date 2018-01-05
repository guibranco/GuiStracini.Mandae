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
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
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
        /// The production service end point
        /// </summary>
        private const String ProductionServiceEndPoint = "https://wtu1w6w2ll.execute-api.us-east-1.amazonaws.com/prd_app_mandae_com_br/v1/";

        /// <summary>
        /// The configure await flag.
        /// </summary>
        private readonly Boolean _configureAwait;

        #endregion

        #region Private methods

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
            where TIn : BaseRequestV1
            where TOut : BaseResponse
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ProductionServiceEndPoint);
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!String.IsNullOrWhiteSpace(requestObject.APIKey))
                    client.DefaultRequestHeaders.Add("API-TOKEN", requestObject.APIKey);
                if (!String.IsNullOrWhiteSpace(requestObject.Token))
                    client.DefaultRequestHeaders.Add("Authorization", requestObject.Token);
                var endpoint = String.Concat(requestObject.GetRequestEndPoint(), requestObject.GetRequestAdditionalParameter(method));
                try
                {
                    HttpResponseMessage response;
                    switch (method)
                    {
                        case ActionMethod.GET:
                            response = await client.GetAsync(endpoint, cancellationToken).ConfigureAwait(_configureAwait);
                            break;
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
        /// Gets the specified request object.
        /// </summary>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <typeparam name="TIn">The type of the in.</typeparam>
        /// <param name="requestObject">The request object.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public async Task<TOut> Get<TOut, TIn>(TIn requestObject, CancellationToken token) where TIn : BaseRequestV1 where TOut : BaseResponse
        {
            return await Execute<TOut, TIn>(ActionMethod.GET, requestObject, token).ConfigureAwait(_configureAwait);
        }

        #endregion
    }
}
