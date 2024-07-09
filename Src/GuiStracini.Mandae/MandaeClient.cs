// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="MandaeClient.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae
public async Task<OccurrenceResponse> QueryOccurrencesAsync(OccurrenceRequest request) {
    // Implement API call logic here
    return await Task.FromResult(new OccurrenceResponse());
}
{
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Enums;
    using Models;
    using Transport;
    using Transport.V1;
    using Utils;

    /// <summary>
    /// The unofficial Mandaê API client class.
    /// Implementation based on https://dev.mandae.com.br/api/index.html
    /// </summary>
    public sealed class MandaeClient : IMandaeClient
    {
        #region Private fields

        /// <summary>
        /// The service factory instance
        /// </summary>
        private readonly ServiceFactory _service;

        /// <summary>
        /// The Mandaê API token
        /// </summary>
        private readonly string _token;

        /// <summary>
        /// The configure await flag
        /// </summary>
        private readonly bool _configureAwait;

        /// <summary>
        /// The service factory (V1) instance
        /// </summary>
        private ServiceFactoryV1 _serviceV1;

        #endregion Private fields

        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="MandaeClient" /> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="configureAwait">if set to <c>true</c> [configure await].</param>
        public MandaeClient(
            string token,
            Environment environment = Environment.SANDBOX,
            bool configureAwait = true
        )
        {
            _token = token;
            _configureAwait = configureAwait;
            _service = new ServiceFactory(environment, _configureAwait);
        }

        #endregion ~Ctor

        #region Rates

        /// <summary>
        /// Gets the rates for a specified postal code destination and package dimensions.
        /// </summary>
        /// <param name="model">The rates model.</param>
        /// <returns><see cref="RatesResponse" /></returns>
        public RatesResponse GetRates(RatesModel model)
        {
            return GetRatesAsync(model, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the rates for a specified postal code destination and package dimensions asynchronous.
        /// </summary>
        /// <param name="model">The rates model.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task of <see cref="RatesResponse" /></returns>
        public async Task<RatesResponse> GetRatesAsync(RatesModel model, CancellationToken token)
        {
            var data = new RatesRequest
            {
                Token = _token,
                PostalCode = model.PostalCode,
                DeclaredValue = model.DeclaredValue.ToString(CultureInfo.InvariantCulture),
                Height = model.Dimensions.Height.ToString(CultureInfo.InvariantCulture),
                Length = model.Dimensions.Length.ToString(CultureInfo.InvariantCulture),
                Weight = model.Dimensions.Weight.ToString(CultureInfo.InvariantCulture),
                Width = model.Dimensions.Width.ToString(CultureInfo.InvariantCulture)
            };
            return await _service
                .Post<RatesResponse, RatesRequest>(data, token)
                .ConfigureAwait(_configureAwait);
        }

        #endregion Rates

        #region Orders

        /// <summary>
        /// Creates the order collect request.
        /// </summary>
        /// <param name="model">The order collect model.</param>
        /// <returns>The <see cref="OrderResponse" /> with the property id populated</returns>
        public OrderResponse CreateOrderCollectRequest(OrderModel model)
        {
            return CreateOrderCollectRequestAsync(model, CancellationToken.None).Result;
        }

        /// <summary>
        /// Creates the order collect request asynchronous.
        /// </summary>
        /// <param name="model">The order collect model.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task with the <see cref="OrderResponse" /> with the property id populated</returns>
        public async Task<OrderResponse> CreateOrderCollectRequestAsync(
            OrderModel model,
            CancellationToken token
        )
        {
            var data = new OrderRequest
            {
                Token = _token,
                CustomerId = model.CustomerId,
                Items = model.Items,
                Label = model.Label,
                Observation = model.Observation,
                PartnerOrderId = model.PartnerOrderId,
                Scheduling = model.Scheduling,
                Sender = model.Sender,
                Vehicle = model.Vehicle
            };
            return await _service
                .Post<OrderResponse, OrderRequest>(data, token)
                .ConfigureAwait(_configureAwait);
        }

        #endregion Orders

        #region Tracking

        /// <summary>
        /// Gets the order tracking by the tracking code.
        /// </summary>
        /// <param name="trackingCode">The tracking code.</param>
        /// <returns><see cref="TrackingResponse" /></returns>
        public TrackingResponse GetTracking(string trackingCode)
        {
            return GetTrackingAsync(trackingCode, CancellationToken.None).Result;
        }

        /// <summary>
        /// Gets the tracking by the tracking code asynchronous.
        /// </summary>
        /// <param name="trackingCode">The tracking code.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task of <see cref="TrackingResponse" /></returns>
        public async Task<TrackingResponse> GetTrackingAsync(
            string trackingCode,
            CancellationToken token
        )
        {
            var data = new TrackingRequest { Token = _token, TrackingCode = trackingCode };
            return await _service
                .Get<TrackingResponse, TrackingRequest>(data, token)
                .ConfigureAwait(_configureAwait);
        }

        #endregion Tracking

        #region Authentication (V1)

        /// <summary>
        /// Configures the v1 authentication.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>System.String.</returns>
        public async Task<string> ConfigureV1Authentication(string email, string password)
        {
            _serviceV1 = new ServiceFactoryV1(_configureAwait);
            return await _serviceV1
                .LoginAsync(email, password, CancellationToken.None)
                .ConfigureAwait(_configureAwait);
        }

        #endregion Authentication (V1)

        #region Search (V1)

        /// <summary>
        /// Searches the specified method for the specified value.
        /// </summary>
        /// <param name="method">The searched method/parameter.</param>
        /// <param name="value">The searched value.</param>
        /// <param name="limit">The results limit per page.</param>
        /// <param name="offset">The pagination offset (zero based index).</param>
        /// <returns>The search result</returns>
        public SearchResponse Search(
            SearchMethod method,
            string value,
            int limit = 10,
            int offset = 0
        )
        {
            return SearchAsync(method, value, CancellationToken.None, limit, offset).Result;
        }

        /// <summary>
        /// Searches the specified method for the specified value asynchronous.
        /// </summary>
        /// <param name="method">The searched method/parameter.</param>
        /// <param name="value">The searched value.</param>
        /// <param name="token">The cancellation token</param>
        /// <param name="limit">The results limit per page.</param>
        /// <param name="offset">The pagination offset (zero based index).</param>
        /// <returns>A Task&lt;SearchResponse&gt; representing the asynchronous operation.</returns>
        public async Task<SearchResponse> SearchAsync(
            SearchMethod method,
            string value,
            CancellationToken token,
            int limit = 10,
            int offset = 0
        )
        {
            var data = new SearchRequest
            {
                Method = method,
                Value = value,
                Limit = limit,
                Offset = offset,
            };

            return await _serviceV1
                .Get<SearchResponse, SearchRequest>(data, token)
                .ConfigureAwait(_configureAwait);
        }

        #endregion Search (V1)

        #region Occurrences (V1)

        //TODO

        #endregion Occurrences (V1)

        #region Reverses (V1)

        /// <summary>
        /// Searches the reverse.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="value">The value.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>SearchReverseResponse.</returns>
        public SearchReverseResponse SearchReverse(
            ReverseSearchMethod method,
            string value,
            int limit = 10,
            int offset = 0
        )
        {
            return SearchReverseAsync(method, value, CancellationToken.None, limit, offset).Result;
        }

        /// <summary>
        /// Searches the reverse asynchronous.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="value">The value.</param>
        /// <param name="token">The token.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>A Task&lt;SearchReverseResponse&gt; representing the asynchronous operation.</returns>
        public async Task<SearchReverseResponse> SearchReverseAsync(
            ReverseSearchMethod method,
            string value,
            CancellationToken token,
            int limit = 10,
            int offset = 0
        )
        {
            var data = new SearchReverseRequest
            {
                Method = method,
                Value = value,
                Limit = limit,
                Offset = offset
            };

            return await _serviceV1
                .Get<SearchReverseResponse, SearchReverseRequest>(data, token)
                .ConfigureAwait(_configureAwait);
        }

        #endregion Reverses (V1)
    }
}
