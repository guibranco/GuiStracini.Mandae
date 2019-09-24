// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="ValueAddedService.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using Enums;
    using Newtonsoft.Json;

    /// <summary>
    /// The value added service class.
    /// Allows to add a valuable service to the item
    /// </summary>
    public sealed class ValueAddedService
    {
        /// <summary>
        /// Gets or sets the service name.
        /// </summary>
        /// <value>
        /// The service name.
        /// </value>
        [JsonProperty("name")]
        public Service Name { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
