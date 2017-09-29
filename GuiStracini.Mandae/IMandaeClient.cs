// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 29/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 29/09/2017
// ***********************************************************************
// <copyright file="IMandaeClient.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae
{
    using Enums;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Transport;

    /// <summary>
    /// The Mandaê API interface
    /// </summary>
    public interface IMandaeClient
    {
        CustomerResponse RegisterCustomer(CustomerModel model);
        /// <summary>
        /// Registers the customer asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<CustomerResponse> RegisterCustomerAsync(CustomerModel model, CancellationToken token);
        /// <summary>
        /// Gets the vehicles.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <returns></returns>
        List<Vehicle> GetVehicles(String postalCode);
        /// <summary>
        /// Gets the vehicles asynchronous.
        /// </summary>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<List<Vehicle>> GetVehiclesAsync(String postalCode, CancellationToken token);
        /// <summary>
        /// Gets the rates.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        RatesResponse GetRates(RatesModel model);
        /// <summary>
        /// Gets the rates asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<RatesResponse> GetRatesAsync(RatesModel model, CancellationToken token);
        /// <summary>
        /// Gets the available hours.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        AvailableHoursResponse GetAvailableHours(DateTime date);
        /// <summary>
        /// Gets the available hours asynchronous.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<AvailableHoursResponse> GetAvailableHoursAsync(DateTime date, CancellationToken token);
        /// <summary>
        /// Creates the order collect request.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        OrderRequest CreateOrderCollectRequest(OrderModel model);
        /// <summary>
        /// Creates the order collect request asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<OrderRequest> CreateOrderCollectRequestAsync(OrderModel model, CancellationToken token);
        Guid CreateLargeOrderCollectRequest(OrderModel model);
        /// <summary>
        /// Creates the large order collect request asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<Guid> CreateLargeOrderCollectRequestAsync(OrderModel model, CancellationToken token);
        /// <summary>
        /// Gets the latest order collect status.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        LatestResponse GetLatestOrderCollectStatus(String customerId);
        /// <summary>
        /// Gets the latest order collect status asynchronous.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<LatestResponse> GetLatestOrderCollectStatusAsync(String customerId, CancellationToken token);
        /// <summary>
        /// Cancels the order collect request.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        Boolean CancelOrderCollectRequest(Int64 orderId);
        /// <summary>
        /// Cancels the order collect request asynchronous.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<Boolean> CancelOrderCollectRequestAsync(Int64 orderId, CancellationToken token);
        /// <summary>
        /// Cancels the order item collect request.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <returns></returns>
        Boolean CancelOrderItemCollectRequest(Int64 orderId, Int64 itemId);
        /// <summary>
        /// Cancels the order item collect request asynchronous.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<Boolean> CancelOrderItemCollectRequestAsync(Int64 orderId, Int64 itemId, CancellationToken token);
        /// <summary>
        /// Gets the tracking.
        /// </summary>
        /// <param name="trackingCode">The tracking code.</param>
        /// <returns></returns>
        TrackingResponse GetTracking(String trackingCode);
        /// <summary>
        /// Gets the tracking asynchronous.
        /// </summary>
        /// <param name="trackingCode">The tracking code.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<TrackingResponse> GetTrackingAsync(String trackingCode, CancellationToken token);
    }
}
