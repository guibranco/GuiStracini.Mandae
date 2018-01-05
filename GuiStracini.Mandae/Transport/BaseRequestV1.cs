// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 05/01/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 05/01/2018
// ***********************************************************************
// <copyright file="BaseTransportV1.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// All classes that performs a direct request to the Mandaê API V1 must inherit from this class
    /// </summary>
    public abstract class BaseRequestV1 : BaseRequest
    {
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        [JsonIgnore]
        public String APIKey { get; set; }
    }
}
