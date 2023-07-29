// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="Item.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.ValueObject
{
    using System.Globalization;
    using Newtonsoft.Json;

    /// <summary>
    /// The new item class
    /// </summary>
    public sealed class Item
    {
        #region Private fields

        /// <summary>
        /// The total value
        /// </summary>
        private decimal _totalValue;

        /// <summary>
        /// The total freight
        /// </summary>
        private decimal _totalFreight;

        #endregion

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        /// <value>The identifier</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the recipient.
        /// </summary>
        /// <value>The recipient.</value>
        [JsonProperty("recipient")]
        public Recipient Recipient { get; set; }

        /// <summary>
        /// Gets or sets the shipping service.
        /// </summary>
        /// <value>The shipping service.</value>
        [JsonProperty("shippingService")]
        public string ShippingService => "Frete-Mandae";

        /// <summary>
        /// Gets or sets the value added services.
        /// </summary>
        /// <value>The value added services.</value>
        [JsonProperty("valueAddedServices")]
        public ValueAddedService[] ValueAddedServices { get; set; }

        /// <summary>
        /// Gets or sets the observation.
        /// </summary>
        /// <value>The observation.</value>
        [JsonProperty("observation")]
        public string Observation { get; set; }

        /// <summary>
        /// Gets or sets the partner item identifier.
        /// </summary>
        /// <value>The partner item identifier.</value>
        [JsonProperty("partnerItemId")]
        public string PartnerItemId { get; set; }

        /// <summary>
        /// Gets or sets the skus.
        /// </summary>
        /// <value>The skus.</value>
        [JsonProperty("skus")]
        public Sku[] Skus { get; set; }

        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>The invoice.</value>
        [JsonProperty("invoice")]
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the tracking identifier.
        /// </summary>
        /// <value>The tracking identifier.</value>
        [JsonProperty("trackingId")]
        public string TrackingId { get; set; }

        /// <summary>
        /// Gets or sets the dimensions.
        /// </summary>
        /// <value>The dimensions.</value>
        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }

        /// <summary>
        /// Gets or sets the channel
        /// </summary>
        /// <value>The sales channel (eg.: e-commerce, telemarketing, crm, etc)</value>
        [JsonProperty("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the store name
        /// </summary>
        /// <value>The store name</value>
        [JsonProperty("store")]
        public string Store { get; set; }

        /// <summary>
        /// Gets or sets the total value internally
        /// </summary>
        /// <value>The total value of the item/order without freight value</value>
        [JsonProperty("totalValue")]
        public string TotalValueInternal
        {
            get => _totalValue.ToString(CultureInfo.InvariantCulture);
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    return;
                if (decimal.TryParse(value, out var v))
                    _totalValue = v;
            }
        }

        /// <summary>
        /// Gets or sets the total value
        /// </summary>
        /// <value>The total value of the item/order without freight value</value>
        [JsonIgnore]
        public decimal TotalValue
        {
            get => _totalValue;
            set => _totalValue = value;
        }

        /// <summary>
        /// Gets or sets the total freight value internally
        /// </summary>
        /// <value>The total freight value</value>
        /// <remarks>If the <see cref="Sku" /> has freight declared, this should be the sum of all sku's freights values.</remarks>
        [JsonProperty("totalFreight")]
        public string TotalFreightInternal
        {
            get => _totalFreight.ToString(CultureInfo.InvariantCulture);
            set
            {
                if (value == null)
                    return;
                if (decimal.TryParse(value, out var v))
                    _totalFreight = v;
            }
        }

        /// <summary>
        /// Gets or sets the total freight value
        /// </summary>
        /// <value>The total freight value</value>
        /// <remarks>If the <see cref="Sku" /> has freight declared, this should be the sum of all sku's freights values.</remarks>

        [JsonIgnore]
        public decimal TotalFreight
        {
            get => _totalFreight;
            set => _totalFreight = value;
        }
    }
}
