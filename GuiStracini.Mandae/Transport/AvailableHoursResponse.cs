// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="AvailableHoursResponse.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using System;

    /// <summary>
    /// The available hours response class
    /// </summary>
    public sealed class AvailableHoursResponse
    {
        /// <summary>
        /// Gets or sets the hours.
        /// </summary>
        /// <value>
        /// The hours.
        /// </value>
        public DateTime[] Hours { get; set; }
    }
}
