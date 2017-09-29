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
    using Newtonsoft.Json;
    using System;
    using Utils;

    /// <summary>
    /// The new item class
    /// </summary>
    public sealed class Item
    {
        #region Private fields 

        private ShippingService _shippingService;

        #endregion

        /// <summary>
        /// Gets or sets the recipient.
        /// </summary>
        /// <value>
        /// The recipient.
        /// </value>
        [JsonProperty("recipient")]
        public Recipient Recipient { get; set; }

        /// <summary>
        /// Gets or sets the shipping service.
        /// </summary>
        /// <value>
        /// The shipping service.
        /// </value>
        [JsonIgnore]
        public ShippingService ShippingService
        {
            get => _shippingService;
            set => _shippingService = value;
        }

        /// <summary>
        /// Gets or sets the shipping service internal.
        /// </summary>
        /// <value>
        /// The shipping service internal.
        /// </value>
        [JsonProperty("shippingService")]
        public String ShippingServiceInternal
        {
            get => _shippingService.ToString().ToCamelCase();
            set => _shippingService = (ShippingService)Enum.Parse(typeof(ShippingService), value.ToUpper());
        }

        /// <summary>
        /// Gets or sets the value added services.
        /// </summary>
        /// <value>
        /// The value added services.
        /// </value>
        [JsonProperty("valueAddedServices")]
        public ValueAddedService[] ValueAddedServices { get; set; }

        /// <summary>
        /// Gets or sets the observation.
        /// </summary>
        /// <value>
        /// The observation.
        /// </value>
        [JsonProperty("observation")]
        public String Observation { get; set; }

        /// <summary>
        /// Gets or sets the qr codes.
        /// </summary>
        /// <value>
        /// The qr codes.
        /// </value>
        [JsonProperty("qrCodes")]
        public String[] QrCodes { get; set; }

        /// <summary>
        /// Gets or sets the partner item identifier.
        /// </summary>
        /// <value>
        /// The partner item identifier.
        /// </value>
        [JsonProperty("partnerItemId")]
        public String PartnerItemId { get; set; }
        /// <summary>
        /// Gets or sets the skus.
        /// </summary>
        /// <value>
        /// The skus.
        /// </value>
        [JsonProperty("skus")]
        public Sku[] Skus { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        [JsonProperty("invoice")]
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the tracking identifier.
        /// </summary>
        /// <value>
        /// The tracking identifier.
        /// </value>
        [JsonProperty("trackingId")]
        public String TrackingId { get; set; }

        /// <summary>
        /// Gets or sets the dimensions.
        /// </summary>
        /// <value>
        /// The dimensions.
        /// </value>
        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }
    }
}
