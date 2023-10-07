// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="ShippingServices.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.ValueObject;

using Newtonsoft.Json;

/// <summary>
/// Represents the shipping services data.
/// </summary>
public sealed class ShippingServices
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    /// <remarks>This field is not in the documentation, but it exists in the API response.
    /// Currently, in all tests, it returns null</remarks>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the quantity days.
    /// </summary>
    /// <value>The quantity days.</value>
    /// <remarks>Documentation says that the field/property name should be QuantityDays, buy actually the API response is "days" only</remarks>
    [JsonProperty("days")]
    public int Days { get; set; }

    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value>The price.</value>
    [JsonProperty("price")]
    public decimal Price { get; set; }
}