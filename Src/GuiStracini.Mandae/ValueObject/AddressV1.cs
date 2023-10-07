// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="AddressV1.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.ValueObject;

using Newtonsoft.Json;

/// <summary>
/// The address class
/// </summary>
public sealed class AddressV1
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    /// <value>The postal code.</value>
    [JsonProperty("cep")]
    public string PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the street.
    /// </summary>
    /// <value>The street.</value>
    [JsonProperty("logradouro")]
    public string Street { get; set; }

    /// <summary>
    /// Gets or sets the number.
    /// </summary>
    /// <value>The number.</value>
    [JsonProperty("numero")]
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the neighborhood.
    /// </summary>
    /// <value>The neighborhood.</value>
    [JsonProperty("bairro")]
    public string Neighborhood { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    /// <value>The city.</value>
    [JsonProperty("cidade")]
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the state initials.
    /// </summary>
    /// <value>The state initials.</value>
    [JsonProperty("uf")]
    public string StateInitials { get; set; }

    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    /// <value>The country.</value>
    [JsonProperty("pais")]
    public string Country { get; set; }
}