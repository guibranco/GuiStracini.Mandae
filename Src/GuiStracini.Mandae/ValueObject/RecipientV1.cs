// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="RecipientV1.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.ValueObject;

using Newtonsoft.Json;

/// <summary>
/// Thre Recipient class
/// </summary>
public sealed class RecipientV1
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [JsonProperty("nome")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the document.
    /// </summary>
    /// <value>The document.</value>
    [JsonProperty("cpf")]
    public string Document { get; set; }

    /// <summary>
    /// Gets or sets the telephone.
    /// </summary>
    /// <value>The telephone.</value>
    [JsonProperty("telefone")]
    public string Telephone { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("endereco")]
    public AddressV1 Address { get; set; }
}