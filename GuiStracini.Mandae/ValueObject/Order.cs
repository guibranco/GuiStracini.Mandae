// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 05/01/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 05/01/2018
// ***********************************************************************
// <copyright file="Order.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using Enums;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// The search response order class
    /// </summary>
    public sealed class Order
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the photo URL.
        /// </summary>
        /// <value>
        /// The photo URL.
        /// </value>
        [JsonProperty("urlFoto")]
        public String PhotoUrl { get; set; }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        [JsonProperty("referencia")]
        public String Reference { get; set; }

        /// <summary>
        /// Gets or sets the qr codes.
        /// </summary>
        /// <value>
        /// The qr codes.
        /// </value>
        [JsonProperty("qrCodes")]
        public String[] QrCodes { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        [JsonProperty("observacao")]
        public String Notes { get; set; }

        /// <summary>
        /// Gets or sets the identifier service order.
        /// </summary>
        /// <value>
        /// The identifier service order.
        /// </value>
        [JsonProperty("idOrdemServico")]
        public Int32? IdServiceOrder { get; set; }

        /// <summary>
        /// Gets or sets the service order.
        /// </summary>
        /// <value>
        /// The service order.
        /// </value>
        [JsonProperty("NumeroOrdemServico")]
        public String ServiceOrder { get; set; }

        /// <summary>
        /// Gets or sets the situation.
        /// </summary>
        /// <value>
        /// The situation.
        /// </value>
        [JsonProperty("situacao")]
        public ShippingSituation Situation { get; set; }

        /// <summary>
        /// Gets or sets the situation description.
        /// </summary>
        /// <value>
        /// The situation description.
        /// </value>
        [JsonProperty("codigoSituacao")]
        public String SituationDescription { get; set; }

        public Int32 Shipp
    }
}
