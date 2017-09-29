// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="AvailableHours.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Attributes;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// This service gets the collection hours available for the informed day.
    /// </summary>
    /// <seealso cref="BaseRequest" />
    [RequestEndPoint("schedulings/available-hours/{Date}")]
    public sealed class AvailableHoursRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [JsonProperty("date")]
        public String Date { get; set; }
    }
}
