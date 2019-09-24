// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="ShippingServices.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using Enums;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Represents the shipping services data. 
    /// </summary>
    public sealed class ShippingServices
    {

        #region Private fields

        /// <summary>
        /// The service
        /// </summary>
        private ShippingService _service;

        /// <summary>
        /// The service setted
        /// </summary>
        private bool _serviceSetted;

        #endregion

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <remarks>
        /// This field is not in the documentation, but it exists in the API response. 
        /// Currently, in all tests, it returns null
        /// </remarks>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the service
        /// </summary>
        /// <value>
        /// The shipping service
        /// </value>

        [JsonIgnore]
        public ShippingService Service
        {
            get => _service;
            set
            {
                _service = value;
                _serviceSetted = true;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name
        {
            get => _serviceSetted && _service == ShippingService.RAPIDO
                       ? "Rapido"
                       : "Economico";
            set
            {
                _service = value.Equals("Rápido", StringComparison.InvariantCultureIgnoreCase)
                               ? ShippingService.RAPIDO
                               : ShippingService.ECONOMICO;
                _serviceSetted = true;
            }
        }

        /// <summary>
        /// Gets or sets the quantity days.
        /// </summary>
        /// <remarks>
        /// Documentation says that the field/property name should be QuantityDays, buy actually the API response is "days" only
        /// </remarks>
        /// <value>
        /// The quantity days.
        /// </value>
        [JsonProperty("days")]
        public int Days { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
