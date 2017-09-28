// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="NewItem.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using Enums;
    using System;

    /// <summary>
    /// The new item class
    /// </summary>
    public sealed class NewItem
    {
        /// <summary>
        /// Gets or sets the recipient.
        /// </summary>
        /// <value>
        /// The recipient.
        /// </value>
        public Recipient Recipient { get; set; }

        /// <summary>
        /// Gets or sets the shipping service.
        /// </summary>
        /// <value>
        /// The shipping service.
        /// </value>
        public ShippingService ShippingService { get; set; }

        /// <summary>
        /// Gets or sets the value added services.
        /// </summary>
        /// <value>
        /// The value added services.
        /// </value>
        public ValueAddedService[] ValueAddedServices { get; set; }

        /// <summary>
        /// Gets or sets the observation.
        /// </summary>
        /// <value>
        /// The observation.
        /// </value>
        public String Observation { get; set; }

        /// <summary>
        /// Gets or sets the qr codes.
        /// </summary>
        /// <value>
        /// The qr codes.
        /// </value>
        public String[] QrCodes { get; set; }

        /// <summary>
        /// Gets or sets the partner item identifier.
        /// </summary>
        /// <value>
        /// The partner item identifier.
        /// </value>
        public String PartnerItemId { get; set; }
        /// <summary>
        /// Gets or sets the skus.
        /// </summary>
        /// <value>
        /// The skus.
        /// </value>
        public Sku[] Skus { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the tracking identifier.
        /// </summary>
        /// <value>
        /// The tracking identifier.
        /// </value>
        public String TrackingId { get; set; }

        /// <summary>
        /// Gets or sets the dimensions.
        /// </summary>
        /// <value>
        /// The dimensions.
        /// </value>
        public Dimensions Dimensions { get; set; }
    }
}
