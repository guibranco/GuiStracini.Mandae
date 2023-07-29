// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 05/01/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="SearchResponse.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.Transport.V1
{
    using Newtonsoft.Json;
    using ValueObject;

    /// <summary>
    /// The V1 Search response class
    /// </summary>
    /// <seealso cref="GuiStracini.Mandae.Transport.BaseResponse" />
    public sealed class SearchResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        [JsonProperty("Total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        [JsonProperty("Pedidos")]
        public Order[] Orders { get; set; }
    }
}
