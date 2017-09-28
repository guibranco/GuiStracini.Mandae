// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="Recipient.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using System;

    /// <summary>
    /// Thre Recipient class
    /// </summary>
    public sealed class Recipient
    {
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public String FullName { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public Address Address { get; set; }
        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>
        /// The document.
        /// </value>
        public String Document { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public String Phone { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public String Email { get; set; }
    }
}
