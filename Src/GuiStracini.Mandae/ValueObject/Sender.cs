// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="Sender.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;

namespace GuiStracini.Mandae.ValueObject
{
    /// <summary>
    /// The sender class
    /// </summary>
    public sealed class Sender
    {
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
