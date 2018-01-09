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
    public sealed class AddressV1
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
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        [JsonProperty("cep")]
        public String PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        [JsonProperty("logradouro")]
        public String Street { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [JsonProperty("numero")]
        public String Number { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood.
        /// </summary>
        /// <value>
        /// The neighborhood.
        /// </value>
        [JsonProperty("bairro")]
        public String Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [JsonProperty("cidade")]
        public String City { get; set; }

        /// <summary>
        /// Gets or sets the state initials.
        /// </summary>
        /// <value>
        /// The state initials.
        /// </value>
        [JsonProperty("uf")]
        public String StateInitials { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [JsonProperty("pais")]
        public String Country { get; set; }
    }
}