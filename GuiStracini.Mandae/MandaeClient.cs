// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 05/01/2018
// ***********************************************************************
// <copyright file="MandaeClient.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae
{
    using Enums;
    using Models;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Transport;
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
        private readonly String _token;

        /// <summary>
        /// The configure await flag
        /// </summary>
        private readonly Boolean _configureAwait;

        /// <summary>
        /// The service factory (V1) instance
        /// </summary>
        private ServiceFactoryV1 _serviceV1;

        #endregion

        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="MandaeClient"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="configureAwait">if set to <c>true</c> [configure await].</param>
        public MandaeClient(
            String token,
            Enums.Environment environment = Enums.Environment.SANDBOX,
            Boolean configureAwait = true)
        {
            _token = token;
            _configureAwait = configureAwait;
            _service = new ServiceFactory(environment, _configureAwait);
        }

        #endregion

        #region Vehicles

        /// <summary>
        /// Gets the vehicles availables for the supplied postal code.
        /// </summary>
        /// <param name="postalCode">The postal code of the collect location.</param>
        /// <returns>A list of <see cref="GuiStracini.Mandae.Enums.Vehicle"/></returns>
        public List<Vehicle> GetVehicles(String postalCode)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return GetVehiclesAsync(postalCode, source.Token).Result;
        }

        /// <summary>
        /// Gets the vehicles availables for the supplied postal code asynchronous.
        /// </summary>
        /// <param name="postalCode">The postal code of the collect location.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task of list of <see cref="GuiStracini.Mandae.Enums.Vehicle"/></returns>
        public async Task<List<Vehicle>> GetVehiclesAsync(String postalCode, CancellationToken token)
        {
            var data = new VehiclesRequest
            {
                Token = _token,
                PostalCode = postalCode
            };
            var result = await _service.Get<Object, VehiclesRequest>(data, token).ConfigureAwait(_configureAwait);
            var array = JArray.Parse(result.ToString());
            return array.Select(v => (Vehicle)Enum.Parse(typeof(Vehicle), v.ToString().ToUpper())).ToList();
        }

        #endregion

        #region Rates

        /// <summary>
        /// Gets the rates for a specified postal code destination and package dimensions.
        /// </summary>
        /// <param name="model">The rates model.</param>
        /// <returns><see cref="RatesResponse"/></returns>
        public RatesResponse GetRates(RatesModel model)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return GetRatesAsync(model, source.Token).Result;
        }

        /// <summary>
        /// Gets the rates for a specified postal code destination and package dimensions asynchronous.
        /// </summary>
        /// <param name="model">The rates model.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task of <see cref="RatesResponse"/></returns>
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
            return await _service.Post<RatesResponse, RatesRequest>(data, token).ConfigureAwait(_configureAwait);
        }

        #endregion

        #region Schedulings 

        /// <summary>
        /// Gets the available hours.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public AvailableHoursResponse GetAvailableHours(DateTime date)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return GetAvailableHoursAsync(date, source.Token).Result;
        }

        /// <summary>
        /// Gets the available hours for collect request asynchronous.
        /// </summary>
        /// <param name="date">The date of the collect.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task of <see cref="AvailableHoursResponse"/></returns>
        public async Task<AvailableHoursResponse> GetAvailableHoursAsync(DateTime date, CancellationToken token)
        {
            var data = new AvailableHoursRequest
            {
                Token = _token,
                Date = date.ToString("yyyy-MM-dd")
            };
            return await _service.Get<AvailableHoursResponse, AvailableHoursRequest>(data, token).ConfigureAwait(_configureAwait);
        }

        #endregion

        #region Orders 

        /// <summary>
        /// Creates the order collect request.
        /// </summary>
        /// <param name="model">The order collect model.</param>
        /// <returns>The <see cref="OrderResponse"/> with the property id populated</returns>
        public OrderResponse CreateOrderCollectRequest(OrderModel model)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return CreateOrderCollectRequestAsync(model, source.Token).Result;
        }

        /// <summary>
        /// Creates the order collect request asynchronous.
        /// </summary>
        /// <param name="model">The order collect model.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task with the <see cref="OrderResponse"/> with the property id populated</returns>
        public async Task<OrderResponse> CreateOrderCollectRequestAsync(OrderModel model, CancellationToken token)
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
            return await _service.Post<OrderResponse, OrderRequest>(data, token).ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Creates the large order collect request.
        /// This executes an asynchronous method inside the Mandaê API too, so the response is just a job identifier that will be sent to the order created web hook later
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The job identifier</returns>
        public Guid CreateLargeOrderCollectRequest(OrderModel model)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return CreateLargeOrderCollectRequestAsync(model, source.Token).Result;
        }

        /// <summary>
        /// Creates the large order collect request asynchronous.
        /// This executes an asynchronous method inside the Mandaê API too, so the response is just a job identifier that will be sent to the order created web hook later
        /// </summary>
        /// <param name="model">The order collect request model.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task with the <see cref="Guid"/> job identifier></returns>
        public async Task<Guid> CreateLargeOrderCollectRequestAsync(OrderModel model, CancellationToken token)
        {
            var data = new LargeOrderRequest
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
            var response = await _service.Post<LargeOrderResponse, OrderRequest>(data, token).ConfigureAwait(_configureAwait);
            return response.JobId;
        }

        /// <summary>
        /// Gets the latest order collect status.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns><see cref="LatestResponse"/></returns>
        public LatestResponse GetLatestOrderCollectStatus(String customerId)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return GetLatestOrderCollectStatusAsync(customerId, source.Token).Result;
        }

        /// <summary>
        /// Gets the latest collect order status asynchronous.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>A task of <see cref="LatestResponse"/></returns>
        public async Task<LatestResponse> GetLatestOrderCollectStatusAsync(String customerId, CancellationToken token)
        {
            var data = new LatestRequest
            {
                Token = _token,
                CustomerId = customerId
            };
            return await _service.Get<LatestResponse, LatestRequest>(data, token).ConfigureAwait(_configureAwait);
        }

        /// <summary>
        /// Cancels the order collect request.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns><c>true</c> if the order collect request was cancelled, otherwise <c>false</c></returns>
        public Boolean CancelOrderCollectRequest(Int64 orderId)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return CancelOrderCollectRequestAsync(orderId, source.Token).Result;
        }

        /// <summary>
        /// Cancels the order collect request asynchronous.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task of <see cref="Boolean"/> indicating whetever the order collect request was canceled or not</returns>
        public async Task<Boolean> CancelOrderCollectRequestAsync(Int64 orderId, CancellationToken token)
        {
            var data = new CancelOrderRequest
            {
                Token = _token,
                OrderId = orderId
            };
            var response = await _service.Delete<Int32, CancelOrderRequest>(data, token).ConfigureAwait(_configureAwait);
            return response == 204;
        }

        /// <summary>
        /// Cancels the order item collect request.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <returns><c>true</c> if the order item collect request was cancelled, otherwise <c>false</c></returns>
        public Boolean CancelOrderItemCollectRequest(Int64 orderId, Int64 itemId)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return CancelOrderItemCollectRequestAsync(orderId, itemId, source.Token).Result;
        }

        /// <summary>
        /// Cancels the order item collect request asynchronous.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task of <see cref="Boolean"/> indicating whetever the order item collect request was canceled or not</returns>
        public async Task<Boolean> CancelOrderItemCollectRequestAsync(Int64 orderId, Int64 itemId, CancellationToken token)
        {
            var data = new CancelItemRequest
            {
                Token = _token,
                OrderId = orderId,
                ItemId = itemId
            };
            var response = await _service.Delete<Int32, CancelItemRequest>(data, token).ConfigureAwait(_configureAwait);
            return response == 204;
        }

        #endregion

        #region Tracking

        /// <summary>
        /// Gets the order tracking by the tracking code.
        /// </summary>
        /// <param name="trackingCode">The tracking code.</param>
        /// <returns><see cref="TrackingResponse"/></returns>
        public TrackingResponse GetTracking(String trackingCode)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return GetTrackingAsync(trackingCode, source.Token).Result;
        }

        /// <summary>
        /// Gets the tracking by the tracking code asynchronous.
        /// </summary>
        /// <param name="trackingCode">The tracking code.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>A task of <see cref="TrackingResponse"/></returns>
        public async Task<TrackingResponse> GetTrackingAsync(String trackingCode, CancellationToken token)
        {
            var data = new TrackingRequest
            {
                Token = _token,
                TrackingCode = trackingCode
            };
            return await _service.Get<TrackingResponse, TrackingRequest>(data, token).ConfigureAwait(_configureAwait);
        }

        #endregion

        #region Authentication (V1)

        /// <summary>
        /// Configures the v1 authentication.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        public void ConfigureV1Authentication(String email, String password)
        {
            _serviceV1 = new ServiceFactoryV1(_configureAwait);
            var tokenSource = new CancellationTokenSource(new TimeSpan(0, 1, 0));
            _serviceV1.LoginAsync(email, password, tokenSource.Token).Wait(tokenSource.Token);
        }

        #endregion

        #region Search (V1)

        /// <summary>
        /// Searches the specified method for the specified value.
        /// </summary>
        /// <param name="method">The searched method/parameter.</param>
        /// <param name="value">The searched value.</param>
        /// <param name="limit">The results limit per page.</param>
        /// <param name="offset">The pagination offset (zero based index).</param>
        /// <returns>
        /// The search result
        /// </returns>
        public SearchResponse Search(SearchMethod method, String value, Int32 limit = 10, Int32 offset = 0)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return SearchAsync(method, value, source.Token, limit, offset).Result;
        }

        /// <summary>
        /// Searches the specified method for the specified value asynchronous.
        /// </summary>
        /// <param name="method">The searched method/parameter.</param>
        /// <param name="value">The searched value.</param>
        /// <param name="token">The cancellation token</param>
        /// <param name="limit">The results limit per page.</param>
        /// <param name="offset">The pagination offset (zero based index).</param>
        /// <returns></returns>
        public async Task<SearchResponse> SearchAsync(
            SearchMethod method,
            String value,
            CancellationToken token,
            Int32 limit = 10,
            Int32 offset = 0)
        {
            var data = new SearchRequest
            {
                Method = method,
                Value = value,
                Limit = limit,
                Offset = offset,
            };

            return await _serviceV1.Get<SearchResponse, SearchRequest>(data, token);
        }

        #endregion

        #region Occurrences (V1)

        #endregion

        #region Reverses (V1)

        /// <summary>
        /// Searches the reverse.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="value">The value.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        public SearchReverseResponse SearchReverse(ReverseSearchMethod method, String value, Int32 limit = 10, Int32 offset = 0)
        {
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            return SearchReverseAsync(method, value, source.Token, limit, offset).Result;
        }

        /// <summary>
        /// Searches the reverse asynchronous.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="value">The value.</param>
        /// <param name="token">The token.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        public async Task<SearchReverseResponse> SearchReverseAsync(ReverseSearchMethod method,
                                                         String value,
                                                         CancellationToken token,
                                                         Int32 limit = 10,
                                                         Int32 offset = 0)
        {
            var data = new SearchReverseRequest
            {
                Method = method,
                Value = value,
                Limit = limit,
                Offset = offset
            };

            return await _serviceV1.Get<SearchReverseResponse, SearchReverseRequest>(data, token);
        }

        #endregion
    }
}