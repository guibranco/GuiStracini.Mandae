// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="TrackingResponse.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using System;
    using ValueObject;

    /// <summary>
    /// The tracking response class
    /// </summary>
    public sealed class TrackingResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the tracking code.
        /// </summary>
        /// <value>
        /// The tracking code.
        /// </value>
        public String TrackingCode { get; set; }
        /// <summary>
        /// Gets or sets the carrier code.
        /// </summary>
        /// <value>
        /// The carrier code.
        /// </value>
        public String CarrierCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the carrier.
        /// </summary>
        /// <value>
        /// The name of the carrier.
        /// </value>
        public String CarrierName { get; set; }
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public Event[] Events { get; set; }
    }
}
