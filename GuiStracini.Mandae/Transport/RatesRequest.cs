﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="Rates.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// This entity allows a simulation of the value of a freight for a given ZIP code. 
    /// Return is a list of shipping forms offered for the simulated zip code.
    /// </summary>
    /// <seealso cref="Request" />
    [RequestEndPoint("/postalcodes/{PostalCode}/rates")]
    public sealed class RatesRequest : Request
    {
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        /// <summary>
        /// Gets or sets the declared value.
        /// </summary>
        /// <value>
        /// The declared value.
        /// </value>
        [JsonProperty("declaredValue")]
        public string DeclaredValue { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        [JsonProperty("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        [JsonProperty("height")]
        public string Height { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        [JsonProperty("width")]
        public string Width { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        [JsonProperty("length")]
        public string Length { get; set; }
    }
}
