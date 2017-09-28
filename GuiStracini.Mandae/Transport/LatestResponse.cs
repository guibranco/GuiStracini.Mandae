// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="LatestResponse.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using System;

    /// <summary>
    /// The latest response
    /// </summary>
    public sealed class LatestResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Int32 Id { get; set; }
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public String Number { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public String Url { get; set; }
    }
}
