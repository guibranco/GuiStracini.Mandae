// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="Sku.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// The Stock keeping unit class
    /// </summary>
    public sealed class Sku
    {
        /// <summary>
        /// Gets or sets the sku identifier.
        /// </summary>
        /// <value>
        /// The sku identifier.
        /// </value>
        [JsonProperty("skuId")]
        public String SkuId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public String Description { get; set; }
        /// <summary>
        /// Gets or sets the ean.
        /// </summary>
        /// <value>
        /// The ean.
        /// </value>
        [JsonProperty("ean")]
        public String Ean { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [JsonProperty("price")]
        public Decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the freight.
        /// </summary>
        /// <value>
        /// The freight.
        /// </value>
        [JsonProperty("freight")]
        public Decimal Freight { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [JsonProperty("quantity")]
        public Decimal Quantity { get; set; }
    }
}
