// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="RatesResponse.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Newtonsoft.Json;
    using ValueObject;

    /// <summary>
    /// Represents the rates response. With the postal code and the rates available for that postal code
    /// </summary>
    public sealed class RatesResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        /// <summary>
        /// Gets or sets the shipping services.
        /// </summary>
        /// <value>The shipping services.</value>
        [JsonProperty("shippingServices")]
        public ShippingServices[] ShippingServices { get; set; }
    }
}
