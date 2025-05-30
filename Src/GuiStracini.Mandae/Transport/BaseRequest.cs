﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="BaseRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using GuiStracini.SDKBuilder;
using Newtonsoft.Json;

namespace GuiStracini.Mandae.Transport
{
    /// <summary>
    /// All classes that performs a direct request to the Mandaê API V2 or higher must inherit from this class.
    /// </summary>
    public abstract class Request : IBaseRequest
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [JsonIgnore]
        public string Token { get; set; }
    }
}
