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
    using Newtonsoft.Json;
    using System;
    using Utils;
    using ValueObject;

    /// <summary>
    /// This service allows you to create an order and request the collection of the previously registered customer. 
    /// The requested collection may have one or more items. 
    /// We consider the term items as each sale made, which may contain one or more products for the same recipient.
    /// </summary>
    /// <seealso cref="BaseRequest" />
    [RequestEndPoint("orders")]
    public sealed class OrderRequest : BaseRequest
    {
        #region Private fields 

        /// <summary>
        /// The vehicle
        /// </summary>
        private Vehicle _vehicle;

        #endregion

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OrderRequest"/> is asynchronous.
        /// </summary>
        /// <value>
        ///   <c>true</c> if asynchronous; otherwise, <c>false</c>.
        /// </value>
        [RequestAdditionalParameter(ActionMethod.POST, true)]
        [JsonProperty("async")]
        [JsonIgnore]
        public Boolean Async { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        [JsonProperty("customerId")]
        public String CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the scheduling.
        /// </summary>
        /// <value>
        /// The scheduling.
        /// </value>
        [JsonIgnore]
        public DateTime Scheduling { get; set; }

        /// <summary>
        /// Gets or sets the scheduling internal
        /// </summary>
        /// <value>
        /// The scheduling internal
        /// </value>

        [JsonProperty("scheduling")]
        public String SchedulingInternal => Scheduling != DateTime.MinValue
                                                ? Scheduling.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")
                                                : null;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        [JsonProperty("items")]
        public Item[] Items { get; set; }

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        [JsonProperty("sender")]
        public Sender Sender { get; set; }

        /// <summary>
        /// Gets or sets the vehicle.
        /// </summary>
        /// <value>
        /// The vehicle.
        /// </value>
        [JsonIgnore]
        public Vehicle Vehicle
        {
            get => _vehicle;
            set => _vehicle = value;
        }

        /// <summary>
        /// Gets or sets the vehicle internal.
        /// </summary>
        /// <value>
        /// The vehicle internal.
        /// </value>
        [JsonProperty("vehicle")]
        public String VehicleInternal
        {
            get => _vehicle.ToString().ToCamelCase();
            set => _vehicle = (Vehicle)Enum.Parse(typeof(Vehicle), value.ToUpper());
        }
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        [JsonProperty("label")]
        public Sender Label { get; set; }

        /// <summary>
        /// Gets or sets the observation.
        /// </summary>
        /// <value>
        /// The observation.
        /// </value>
        [JsonProperty("observation")]
        public String Observation { get; set; }

        /// <summary>
        /// Gets or sets the partner order identifier.
        /// </summary>
        /// <value>
        /// The partner order identifier.
        /// </value>
        [JsonProperty("partnerOrderId")]
        public String PartnerOrderId { get; set; }
    }
}
