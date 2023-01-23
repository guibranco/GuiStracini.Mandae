// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 12-26-2022
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="Reverse.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Class Reverse. This class cannot be inherited.
    /// </summary>
    public sealed class Reverse
    {
        /// <summary>
        /// Gets or sets the postage authorization.
        /// </summary>
        /// <value>The postage authorization.</value>
        [JsonProperty("autorizacaoPostagem")]
        public string PostageAuthorization { get; set; }

        /// <summary>
        /// Gets or sets the delivery notification.
        /// </summary>
        /// <value>The delivery notification.</value>
        [JsonProperty("avisorecebimento")]
        public bool? DeliveryNotification { get; set; }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        /// <value>The channel.</value>
        [JsonProperty("canal")]
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the tracking code.
        /// </summary>
        /// <value>The tracking code.</value>
        [JsonProperty("codigoRastreamento")]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Gets or sets the tracking code courier.
        /// </summary>
        /// <value>The tracking code courier.</value>
        [JsonProperty("codigoRastreioTransportadora")]
        public string TrackingCodeCourier { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [with packing].
        /// </summary>
        /// <value><c>true</c> if [with packing]; otherwise, <c>false</c>.</value>
        [JsonProperty("comEmbalagem")]
        public bool WithPacking { get; set; }

        /// <summary>
        /// Gets or sets the internal cost.
        /// </summary>
        /// <value>The internal cost.</value>
        [JsonProperty("custoInterno")]
        public decimal InternalCost { get; set; }

        /// <summary>
        /// Gets or sets the canceled date.
        /// </summary>
        /// <value>The canceled date.</value>
        [JsonProperty("dataHoraCancelada")]
        public DateTime? CanceledDate { get; set; }


    }
}
