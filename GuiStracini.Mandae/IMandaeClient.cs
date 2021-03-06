﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 29/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 05/01/2018
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
    using System.Threading;
    using System.Threading.Tasks;
    using Transport;
    using Transport.V1;

    /// <summary>
    /// The Mandaê API interface (also implements V1 methods - currently only Search supported)
    /// </summary>
    public interface IMandaeClient
    {
        #region V2

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
        /// Creates the order collect request.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        OrderResponse CreateOrderCollectRequest(OrderModel model);

        /// <summary>
        /// Creates the order collect request asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<OrderResponse> CreateOrderCollectRequestAsync(OrderModel model, CancellationToken token);

        /// <summary>
        /// Gets the tracking.
        /// </summary>
        /// <param name="trackingCode">The tracking code.</param>
        /// <returns></returns>
        TrackingResponse GetTracking(string trackingCode);

        /// <summary>
        /// Gets the tracking asynchronous.
        /// </summary>
        /// <param name="trackingCode">The tracking code.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<TrackingResponse> GetTrackingAsync(string trackingCode, CancellationToken token);

        #endregion

        #region V1

        /// <summary>
        /// Configures the v1 authentication.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="token">The token.</param>
        Task<string> ConfigureV1Authentication(string apiKey, string token);

        /// <summary>
        /// Searches the specified method for the specified value.
        /// </summary>
        /// <param name="method">The searched method/parameter.</param>
        /// <param name="value">The searched value.</param>
        /// <param name="limit">The results limit per page.</param>
        /// <param name="offset">The pagination offset (zero based index).</param>
        /// <returns>The search result</returns>
        SearchResponse Search(SearchMethod method, string value, int limit, int offset);

        /// <summary>
        /// Searches the specified method for the specified value asynchronous.
        /// </summary>
        /// <param name="method">The searched method/parameter.</param>
        /// <param name="value">The searched value.</param>
        /// <param name="token">The cancellation token</param>
        /// <param name="limit">The results limit per page.</param>
        /// <param name="offset">The pagination offset (zero based index).</param>
        /// <returns></returns>
        Task<SearchResponse> SearchAsync(
            SearchMethod method,
            string value,
            CancellationToken token,
            int limit,
            int offset);

        /// <summary>
        /// Searches the reverse.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="value">The value.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        SearchReverseResponse SearchReverse(ReverseSearchMethod method, string value, int limit, int offset);

        /// <summary>
        /// Searches the reverse asynchronous.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="value">The value.</param>
        /// <param name="token">The token.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        Task<SearchReverseResponse> SearchReverseAsync(ReverseSearchMethod method,
                                                       string value,
                                                       CancellationToken token,
                                                       int limit,
                                                       int offset);


        #endregion
    }
}
