// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="TrackingResponse.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace GuiStracini.Mandae.Transport
{
    using ValueObject;

    /// <summary>
    /// The tracking response class
    /// </summary>
    public sealed class TrackingResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the tracking code.
        /// </summary>
        /// <value>The tracking code.</value>
        [JsonProperty("trackingCode")]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Gets or sets the carrier code.
        /// </summary>
        /// <value>The carrier code.</value>
        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the carrier.
        /// </summary>
        /// <value>The name of the carrier.</value>
        [JsonProperty("carrierName")]
        public string CarrierName { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        [JsonProperty("events")]
        public Event[] Events { get; set; }
    }
}
