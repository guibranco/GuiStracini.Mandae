// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 2017-10-03
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 2018-05-23
// ***********************************************************************
// <copyright file="OrderResponse.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 - 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Enums;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
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
        public int Id { get; set; }

        /// <summary>
        /// The customer identifier
        /// </summary>
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

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
        public string Observation { get; set; }

        /// <summary>
        /// The pickup vehicle
        /// </summary>
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// The partner identifier
        /// </summary>
        [JsonProperty("partnerId")]
        public string PartnerId { get; set; }

        /// <summary>
        /// The partner order identifier
        /// </summary>
        [JsonProperty("partnerOrderId")]
        public string PartnerOrderId { get; set; }

        /// <summary>
        /// The processing date
        /// </summary>
        [JsonIgnore]
        public DateTime? ProcessingDate { get; set; }

        [JsonProperty("processingDate")]
        public string ProcessingDateInternal
        {
            get => ProcessingDate?.ToString("yyyy-MM-dd");
            set
            {
                if (value == null)
                    return;
                if (DateTime.TryParseExact(value, "yyyy-MM-dd", null, DateTimeStyles.None, out var temp))
                {
                    ProcessingDate = temp;
                    return;
                }
                ProcessingDate = JsonConvert.DeserializeObject<DateTime>($@"""/Date({value})/""");
            }
        }
    }
}
