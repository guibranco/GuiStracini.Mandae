// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 03/10/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 03/10/2017
// ***********************************************************************
// <copyright file="OrderResponse.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Enums;
    using Newtonsoft.Json;
    using System;
    using ValueObject;

    /// <summary>
    /// The order response
    /// </summary>

    public sealed class OrderResponse : BaseResponse
    {
        /// <summary>
        /// The identifier
        /// </summary>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary>
        /// The customer identifier
        /// </summary>
        [JsonProperty("customerId")]
        public String CustomerId { get; set; }

        /// <summary>
        /// The scheduling date
        /// </summary>
        [JsonProperty("scheduling")]
        public DateTime Scheduling { get; set; }

        /// <summary>
        /// The items collection
        /// </summary>
        [JsonProperty("items")]
        public Item[] Items { get; set; }

        /// <summary>
        /// Gets or sets the sender data
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        [JsonProperty("sender")]
        public Sender Sender { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        [JsonProperty("label")]
        public Sender Label { get; set; }

        /// <summary>
        /// The observation
        /// </summary>
        [JsonProperty("observation")]
        public String Observation { get; set; }

        /// <summary>
        /// The pickup vehicle
        /// </summary>
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// The partner identifier
        /// </summary>
        [JsonProperty("partnerId")]
        public String PartnerId { get; set; }

        /// <summary>
        /// The partner order identifier
        /// </summary>
        [JsonProperty("partnerOrderId")]
        public String PartnerOrderId { get; set; }

        /// <summary>
        /// The pickup date
        /// </summary>
        [JsonProperty("pickupDate")]
        public DateTime PickupDate { get; set; }

        /// <summary>
        /// The processing date
        /// </summary>
        [JsonProperty("processingDate")]
        public DateTime ProcessingDate { get; set; }
    }
}
