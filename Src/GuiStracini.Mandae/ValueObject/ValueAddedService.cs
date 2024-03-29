﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="ValueAddedService.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace GuiStracini.Mandae.ValueObject
{
    using Enums;

    /// <summary>
    /// The value added service class.
    /// Allows to add a valuable service to the item
    /// </summary>
    public sealed class ValueAddedService
    {
        /// <summary>
        /// Gets or sets the service name.
        /// </summary>
        /// <value>The service name.</value>
        [JsonProperty("name")]
        public Service Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
