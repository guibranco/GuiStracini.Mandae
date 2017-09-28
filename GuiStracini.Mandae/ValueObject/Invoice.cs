// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="Invoice.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using System;

    /// <summary>
    /// The invoice class
    /// </summary>
    public sealed class Invoice
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public String Id { get; set; }
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public String Key { get; set; }
    }
}
