// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="Address.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// The address class
    /// </summary>
    public sealed class Address
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
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        [JsonProperty("street")]
        public String Street { get; set; }
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [JsonProperty("number")]
        public Int32 Number { get; set; }
        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>
        /// The address line2.
        /// </value>
        [JsonProperty("addressLine2")]
        public String AddressLine2 { get; set; }
        /// <summary>
        /// Gets or sets the neighborhood.
        /// </summary>
        /// <value>
        /// The neighborhood.
        /// </value>
        [JsonProperty("neighborhood")]
        public String Neighborhood { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [JsonProperty("city")]
        public String City { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [JsonProperty("state")]
        public String State { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [JsonProperty("country")]
        public String Country { get; set; }
        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        [JsonProperty("reference")]
        public String Reference { get; set; }
    }
}
