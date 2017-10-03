// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 03/10/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 03/10/2017
// ***********************************************************************
// <copyright file="CancelOrderRequest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Attributes;
    using System;

    /// <summary>
    /// This service allows the whole collection to be canceled. 
    /// </summary>
    /// <seealso cref="BaseRequest" />
    [RequestEndPoint("orders/{OrderId}")]
    public class CancelOrderRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public Int64 OrderId { get; set; }
    }
}
