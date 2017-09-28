
// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="OrderModel.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Models
{
    using Enums;
    using System;
    using ValueObject;

    /// <summary>
    /// The order collect request model
    /// </summary>
    public sealed class OrderModel
    {
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
        public DateTime Scheduling { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public Item[] Items { get; set; }

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
