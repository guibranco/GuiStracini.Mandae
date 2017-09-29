// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="RatesResponse" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Newtonsoft.Json;
    using System;
    using ValueObject;

    /// <summary>
    /// Represents the rates response. With the postal code and the rates available for that postal code
    /// </summary>
    public sealed class RatesResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        [JsonProperty("postalCode")]
        public String PostalCode { get; set; }
        /// <summary>
        /// Gets or sets the shipping services.
        /// </summary>
        /// <value>
        /// The shipping services.
        /// </value>
        [JsonProperty("shippingServices")]
        public ShippingServices[] ShippingServices { get; set; }
    }
}
