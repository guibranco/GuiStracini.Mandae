﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="Tracking.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// This service allows you to get the complete listing of tracking events from the tracking code.
    /// </summary>
    /// <seealso cref="Request" />
    [ExtendedEndpointRoute("trackings/{TrackingCode}")]
    public sealed class TrackingRequest : Request
    {
        /// <summary>
        /// Gets or sets the tracking code.
        /// </summary>
        /// <value>
        /// The tracking code.
        /// </value>
        [JsonProperty("trackingCode")]
        public string TrackingCode { get; set; }
    }
}
