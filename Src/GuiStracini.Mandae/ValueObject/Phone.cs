﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="Phone.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace GuiStracini.Mandae.ValueObject
{
    /// <summary>
    /// The phone entity.
    /// </summary>
    public sealed class Phone
    {
        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        /// <value>The area code.</value>
        [JsonProperty("areaCode")]
        public string AreaCode { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
