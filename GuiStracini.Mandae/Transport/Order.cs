// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="Order.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Attributes;
    using Enums;
    using System;
    using ValueObject;

    /// <summary>
    /// This service allows you to create an order and request the collection of the previously registered customer. 
    /// The requested collection may have one or more items. 
    /// We consider the term items as each sale made, which may contain one or more products for the same recipient.
    /// </summary>
    /// <seealso cref="GuiStracini.Mandae.Transport.BaseTransport" />
    [RequestEndPoint("orders")]
    public sealed class Order : BaseTransport
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Order"/> is asynchronous.
        /// </summary>
        /// <value>
        ///   <c>true</c> if asynchronous; otherwise, <c>false</c>.
        /// </value>
        [RequestAdditionalParameter(ActionMethod.POST)]
        public Boolean Async { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Int64 Id { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        [RequestAdditionalParameter(ActionMethod.DELETE)]
        public Int64 OrderId { get; set; }

        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>
        /// The job identifier.
        /// </value>
        public Guid JobId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public String CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the scheduling.
        /// </summary>
        /// <value>
        /// The scheduling.
        /// </value>
        public String Scheduling { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public NewItem[] Items { get; set; }

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        public Sender Sender { get; set; }

        /// <summary>
        /// Gets or sets the vehicle.
        /// </summary>
        /// <value>
        /// The vehicle.
        /// </value>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public Sender Label { get; set; }

        /// <summary>
        /// Gets or sets the observation.
        /// </summary>
        /// <value>
        /// The observation.
        /// </value>
        public String Observation { get; set; }

        /// <summary>
        /// Gets or sets the partner order identifier.
        /// </summary>
        /// <value>
        /// The partner order identifier.
        /// </value>
        public String PartnerOrderId { get; set; }
    }
}
