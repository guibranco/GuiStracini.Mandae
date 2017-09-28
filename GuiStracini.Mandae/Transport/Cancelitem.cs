// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="CancelItem.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Attributes;
    using System;

    /// <summary>
    /// This service allows a collection item to be canceled. 
    /// Items that have already been withdrawn by the Mandaê can not be canceled. 
    /// If all items in a collection are canceled, the collection will automatically be canceled.
    /// </summary>
    /// <seealso cref="GuiStracini.Mandae.Transport.BaseTransport" />
    [RequestEndPoint("orders/{OrderId}/items/{ItemId}")]
    public sealed class CancelItem : BaseTransport
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public Int64 OrderId { get; set; }

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public Int64 ItemId { get; set; }
    }
}
