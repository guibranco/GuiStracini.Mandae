// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="Vehicles.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// This service makes it possible to verify that the Mandaê pickup service is available in a particular ZIP code and which vehicles are available for withdrawal. 
    /// Some addresses are serviced only by motorbikes, while others are serviced both by motorbike and by car. 
    /// Currently the pickup service is only available in the cities of São Paulo and Osasco. 
    /// See our service area on the map.
    /// </summary>
    /// <seealso cref="Request" />
    [RequestEndPoint("postalcodes/{PostalCode}/vehicles")]
    public sealed class VehiclesRequest : Request
    {
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }
}
