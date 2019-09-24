﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="Lastest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// This service allows you to check the status of the last collection requested by the customer. 
    /// In the address returned in the url attribute it is possible to monitor the situation of the collection in real time, including to visualize in a map the location of the driver of the Mandaê who will make the collection
    /// </summary>
    /// <seealso cref="Request" />
    [RequestEndPoint("customers/{CustomerId}/orders/latest")]
    public sealed class LatestRequest : Request
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }
    }
}
