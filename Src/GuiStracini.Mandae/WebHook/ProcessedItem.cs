// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="ProcessedItem.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.WebHook;

using ValueObject;

/// <summary>
/// The processed item web hook model
/// </summary>
public sealed class ProcessedItem
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the partner item identifier.
    /// </summary>
    /// <value>The partner item identifier.</value>
    public string PartnerItemId { get; set; }

    /// <summary>
    /// Gets or sets the tracking code.
    /// </summary>
    /// <value>The tracking code.</value>
    public string TrackingCode { get; set; }

    /// <summary>
    /// Gets or sets the tracking URL.
    /// </summary>
    /// <value>The tracking URL.</value>
    public string TrackingUrl { get; set; }

    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value>The price.</value>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the dimensions.
    /// </summary>
    /// <value>The dimensions.</value>
    public Dimensions Dimensions { get; set; }

    /// <summary>
    /// Gets or sets the reference.
    /// </summary>
    /// <value>The reference.</value>
    public string Reference { get; set; }

    /// <summary>
    /// Gets or sets the qr codes.
    /// </summary>
    /// <value>The qr codes.</value>
    public string[] QrCodes { get; set; }
}