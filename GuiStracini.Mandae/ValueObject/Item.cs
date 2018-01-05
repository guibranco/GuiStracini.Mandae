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
    using System.Globalization;
    using Utils;

    /// <summary>
    /// The new item class
    /// </summary>
    public sealed class Item
    {
        #region Private fields 

        /// <summary>
        /// The shipping service
        /// </summary>
        private ShippingService _shippingService;

        /// <summary>
        /// The total value
        /// </summary>
        private Decimal _totalValue;

        /// <summary>
        /// The total freight
        /// </summary>
        private Decimal _totalFreight;

        #endregion

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        /// <value>
        /// The identifier
        /// </value>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

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
            set
            {
                var val = value.ToUpper().Replace("MANDAEEXPRESS", "RAPIDO").Replace("MANDAEECONOMICO", "ECONOMICO").ToUpper();
                _shippingService = (ShippingService)Enum.Parse(typeof(ShippingService), val);
            }
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

        /// <summary>
        /// Gets or sets the channel
        /// </summary>
        /// <value>
        /// The sales channel (eg.: e-commerce, telemarketing, crm, etc)
        /// </value>
        [JsonProperty("channel")]
        public String Channel { get; set; }


        /// <summary>
        /// Gets or sets the store name
        /// </summary>
        /// <value>The store name</value>
        [JsonProperty("store")]
        public String Store { get; set; }

        /// <summary>
        /// Gets or sets the total value internally
        /// </summary>
        /// <value>The total value of the item/order without freight value</value>
        [JsonProperty("totalValue")]
        public String TotalValueInternal
        {
            get => _totalValue.ToString(CultureInfo.InvariantCulture);
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    return;
                if (Decimal.TryParse(value, out var v))
                    _totalValue = v;
            }
        }

        /// <summary>
        /// Gets or sets the total value 
        /// </summary>
        /// <value>The total value of the item/order without freight value</value>
        [JsonIgnore]
        public Decimal TotalValue
        {
            get => _totalValue;
            set => _totalValue = value;
        }

        /// <summary>
        /// Gets or sets the total freight value internally
        /// </summary>
        /// <value>The total freight value</value>
        /// <remarks>
        /// If the <see cref="Sku"/> has freight declared, this should be the sum of all sku's freights values.
        /// </remarks>
        [JsonProperty("totalFreight")]
        public String TotalFreightInternal
        {
            get => _totalFreight.ToString(CultureInfo.InvariantCulture);
            set
            {
                if (value == null)
                    return;
                if (Decimal.TryParse(value, out var v))
                    _totalFreight = v;
            }
        }

        /// <summary>
        /// Gets or sets the total freight value
        /// </summary>
        /// <value>The total freight value</value>
        /// <remarks>
        /// If the <see cref="Sku"/> has freight declared, this should be the sum of all sku's freights values.
        /// </remarks>

        [JsonIgnore]
        public Decimal TotalFreight
        {
            get => _totalFreight;
            set => _totalFreight = value;
        }

    }
}
