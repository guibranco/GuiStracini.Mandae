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
        /// The identifier
        /// </summary>
        private Int64 _id;
        /// <summary>
        /// The identifier setted
        /// </summary>
        private Boolean _idSetted;
        /// <summary>
        /// The job identifier
        /// </summary>
        private Guid _jobId;

        /// <summary>
        /// The job identifier setted
        /// </summary>
        private Boolean _jobIdSetted;

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
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public Int64 Id
        {
            set
            {
                _id = value;
                _idSetted = true;
            }
        }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        [RequestAdditionalParameter(ActionMethod.DELETE)]
        [JsonIgnore]
        public Int64 OrderId
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Gets or sets the order identifier internal.
        /// </summary>
        /// <value>
        /// The order identifier internal.
        /// </value>
        [JsonProperty("orderId")]
        public String OrderIdInternal
        {
            get => _idSetted ? _id.ToString() : null;
            set
            {
                _id = Int64.Parse(value);
                _idSetted = true;
            }
        }

        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>
        /// The job identifier.
        /// </value>
        [JsonIgnore]
        public Guid JobId
        {
            get => _jobId;
            set
            {
                _jobId = value;
                _jobIdSetted = true;
            }
        }

        /// <summary>
        /// Gets or sets the job identifier internal.
        /// </summary>
        /// <value>
        /// The job identifier internal.
        /// </value>
        [JsonProperty("jobId")]
        public String JobIdInternal
        {
            get => _jobIdSetted ? _jobId.ToString() : null;
            set
            {
                _jobId = new Guid(value);
                _jobIdSetted = true;
            }
        }

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
        [JsonProperty("scheduling")]
        public String Scheduling { get; set; }

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
