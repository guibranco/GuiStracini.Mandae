// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 12-26-2022
// ***********************************************************************
// <copyright file="BaseRequest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Newtonsoft.Json;
    using SDKBuilder;

    /// <summary>
    /// All classes that performs a direct request to the Mandaê API V2 or higher must inherit from this class.
    /// </summary>
    public abstract class Request : BaseRequest
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [JsonIgnore]
        public string Token { get; set; }
    }
}