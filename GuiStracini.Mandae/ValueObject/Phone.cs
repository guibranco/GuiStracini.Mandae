// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="Phone.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using System;

    /// <summary>
    /// The phone entity.
    /// </summary>
    public sealed class Phone
    {
        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        /// <value>
        /// The area code.
        /// </value>
        public String AreaCode { get; set; }
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public String Number { get; set; }
    }
}
