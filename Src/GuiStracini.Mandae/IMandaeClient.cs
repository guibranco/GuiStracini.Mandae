// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 29/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="IMandaeClient.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
Task<OccurrenceResponse> QueryOccurrencesAsync(OccurrenceRequest request);
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae
{
    using System.Threading;
    using System.Threading.Tasks;
    using Enums;
    using Models;
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
        /// <returns>RatesResponse.</returns>
        RatesResponse GetRates(RatesModel model);

        /// <summary>
        /// Gets the rates asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;RatesResponse&gt;.</returns>
        Task<RatesResponse> GetRatesAsync(RatesModel model, CancellationToken token);

        /// <summary>
        /// Creates the order collect request.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>OrderResponse.</returns>
        OrderResponse CreateOrderCollectRequest(OrderModel model);

        /// <summary>
        /// Creates the order collect request asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;OrderResponse&gt;.</returns>
        Task<OrderResponse> CreateOrderCollectRequestAsync(
            OrderModel model,
            CancellationToken token
        );

        /// <summary>
        /// Gets the tracking.
        /// </summary>
        /// <param name="trackingCode">The tracking code.</param>
        /// <returns>TrackingResponse.</returns>
        TrackingResponse GetTracking(string trackingCode);

        /// <summary>
        /// Gets the tracking asynchronous.
        /// </summary>
        /// <param name="trackingCode">The tracking code.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;TrackingResponse&gt;.</returns>
        Task<TrackingResponse> GetTrackingAsync(string trackingCode, CancellationToken token);

        #endregion V2

        #region V1

        /// <summary>
        /// Configures the v1 authentication.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> ConfigureV1Authentication(string email, string password);

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
        /// <returns>Task&lt;SearchResponse&gt;.</returns>
        Task<SearchResponse> SearchAsync(
            SearchMethod method,
            string value,
            CancellationToken token,
            int limit,
            int offset
        );

        /// <summary>
        /// Searches the reverse.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="value">The value.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>SearchReverseResponse.</returns>
        SearchReverseResponse SearchReverse(
            ReverseSearchMethod method,
            string value,
            int limit,
            int offset
        );

        /// <summary>
        /// Searches the reverse asynchronous.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="value">The value.</param>
        /// <param name="token">The token.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>Task&lt;SearchReverseResponse&gt;.</returns>
        Task<SearchReverseResponse> SearchReverseAsync(
            ReverseSearchMethod method,
            string value,
            CancellationToken token,
            int limit,
            int offset
        );

        #endregion V1
    }
}
