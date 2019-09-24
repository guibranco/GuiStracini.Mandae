// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="RatesModel.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Models
{
    using ValueObject;

    /// <summary>
    /// The rates model
    /// </summary>
    public sealed class RatesModel
    {
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode { get; set; }
        /// <summary>
        /// Gets or sets the declared value.
        /// </summary>
        /// <value>
        /// The declared value.
        /// </value>
        public decimal DeclaredValue { get; set; }
        /// <summary>
        /// Gets or sets the dimensions.
        /// </summary>
        /// <value>
        /// The dimensions.
        /// </value>
        public Dimensions Dimensions { get; set; }
    }
}
