// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 05/01/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="Order.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.ValueObject;

using Enums;
using System;
using Newtonsoft.Json;
using Utils;

/// <summary>
/// The search response order class
/// </summary>
public sealed class Order
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the photo URL.
    /// </summary>
    /// <value>The photo URL.</value>
    [JsonProperty("urlFoto")]
    public string PhotoUrl { get; set; }

    /// <summary>
    /// Gets or sets the reference.
    /// </summary>
    /// <value>The reference.</value>
    [JsonProperty("referencia")]
    public string Reference { get; set; }

    /// <summary>
    /// Gets or sets the notes.
    /// </summary>
    /// <value>The notes.</value>
    [JsonProperty("observacao")]
    public string Notes { get; set; }

    /// <summary>
    /// Gets or sets the identifier service order.
    /// </summary>
    /// <value>The identifier service order.</value>
    [JsonProperty("idOrdemServico")]
    public int? IdServiceOrder { get; set; }

    /// <summary>
    /// Gets or sets the service order.
    /// </summary>
    /// <value>The service order.</value>
    [JsonProperty("NumeroOrdemServico")]
    public string ServiceOrder { get; set; }

    /// <summary>
    /// Gets or sets the situation.
    /// </summary>
    /// <value>The situation.</value>
    [JsonProperty("situacao")]
    public ShippingSituation Situation { get; set; }

    /// <summary>
    /// Gets or sets the situation description.
    /// </summary>
    /// <value>The situation description.</value>
    [JsonProperty("codigoSituacao")]
    public string SituationDescription { get; set; }

    /// <summary>
    /// Gets or sets the shipping service.
    /// </summary>
    /// <value>The shipping service.</value>
    [JsonProperty("servicoEnvio")]
    public int ShippingService { get; set; }

    /// <summary>
    /// Gets or sets the shipping service description.
    /// </summary>
    /// <value>The shipping service description.</value>
    [JsonProperty("codigoServicoEnvio")]
    public string ShippingServiceDescription { get; set; }

    /// <summary>
    /// Gets or sets the name of the shipping service.
    /// </summary>
    /// <value>The name of the shipping service.</value>
    [JsonProperty("nomeExibicaoServicoEnvio")]
    public string ShippingServiceName { get; set; }

    /// <summary>
    /// Gets or sets the lenght.
    /// </summary>
    /// <value>The lenght.</value>
    [JsonProperty("comprimento")]
    public decimal? Lenght { get; set; }

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    /// <value>The height.</value>
    [JsonProperty("height")]
    public decimal? Height { get; set; }

    /// <summary>
    /// Gets or sets the diameter.
    /// </summary>
    /// <value>The diameter.</value>
    [JsonProperty("diametro")]
    public decimal? Diameter { get; set; }

    /// <summary>
    /// Gets or sets the weight.
    /// </summary>
    /// <value>The weight.</value>
    [JsonProperty("peso")]
    public decimal? Weight { get; set; }

    /// <summary>
    /// Gets or sets the tracking code.
    /// </summary>
    /// <value>The tracking code.</value>
    [JsonProperty("codigoRastreamento")]
    public string TrackingCode { get; set; }

    /// <summary>
    /// Gets or sets the tracking code courier.
    /// </summary>
    /// <value>The tracking code courier.</value>
    [JsonProperty("codigoRastreioTransportadora")]
    public string TrackingCodeCourier { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    [JsonProperty("valor")]
    public decimal? Value { get; set; }

    /// <summary>
    /// Gets or sets the internal value.
    /// </summary>
    /// <value>The internal value.</value>
    [JsonProperty("custoInterno")]
    public decimal? InternalValue { get; set; }

    /// <summary>
    /// Gets or sets the recipient.
    /// </summary>
    /// <value>The recipient.</value>
    [JsonProperty("destinatario")]
    public RecipientV1 Recipient { get; set; }

    /// <summary>
    /// Gets or sets the label URL.
    /// </summary>
    /// <value>The label URL.</value>
    [JsonProperty("urlEtiqueta")]
    public string LabelUrl { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [acknowledgment receipt].
    /// </summary>
    /// <value><c>true</c> if [acknowledgment receipt]; otherwise, <c>false</c>.</value>
    [JsonProperty("ar")]
    public bool AcknowledgmentReceipt { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [own hands].
    /// </summary>
    /// <value><c>true</c> if [own hands]; otherwise, <c>false</c>.</value>
    [JsonProperty("maoPropria")]
    public bool OwnHands { get; set; }

    /// <summary>
    /// Gets or sets the declared value.
    /// </summary>
    /// <value>The declared value.</value>
    [JsonProperty("valorDeclarado")]
    public decimal? DeclaredValue { get; set; }

    /// <summary>
    /// Gets or sets the packing.
    /// </summary>
    /// <value>The packing.</value>
    [JsonProperty("embalagem")]
    public string Packing { get; set; }

    /// <summary>
    /// Gets or sets the packing code.
    /// </summary>
    /// <value>The packing code.</value>
    [JsonProperty("codigoEmbalagem")]
    public string PackingCode { get; set; }

    /// <summary>
    /// Gets or sets the shipping label.
    /// </summary>
    /// <value>The shipping label.</value>
    [JsonProperty("etiquetaEmbalagem")]
    public int? ShippingLabel { get; set; }

    /// <summary>
    /// Gets or sets the shipping label description.
    /// </summary>
    /// <value>The shipping label description.</value>
    [JsonProperty("codigoEtiquetaEnvio")]
    public string ShippingLabelDescription { get; set; }

    /// <summary>
    /// Gets or sets the tracking URL.
    /// </summary>
    /// <value>The tracking URL.</value>
    [JsonProperty("urlRastreamento")]
    public string TrackingUrl { get; set; }

    /// <summary>
    /// Gets or sets the date delivered.
    /// </summary>
    /// <value>The date delivered.</value>
    [JsonIgnore]
    public DateTime DateDelivered { get; set; }

    /// <summary>
    /// Gets or sets the date delivered internal.
    /// </summary>
    /// <value>The date delivered internal.</value>
    [JsonProperty("dataHoraEntrega")]
    public long? DateDeliveredInternal
    {
        get => DateDelivered.ToUnixTimeStamp();
        set
        {
            if (value != null)
                DateDelivered = Convert.ToInt32(value.Value / 1000).FromUnixTimeStamp();
        }
    }

    /// <summary>
    /// Gets or sets the date lost.
    /// </summary>
    /// <value>The date lost.</value>
    [JsonIgnore]
    public DateTime DateLost { get; set; }

    /// <summary>
    /// Gets or sets the date lost internal.
    /// </summary>
    /// <value>The date lost internal.</value>
    [JsonProperty("dataHoraExtraviada")]
    public long? DateLostInternal
    {
        get => DateLost.ToUnixTimeStamp();
        set
        {
            if (value != null)
                DateLost = Convert.ToInt32(value.Value / 1000).FromUnixTimeStamp();
        }
    }

    /// <summary>
    /// Gets or sets the date first attempt.
    /// </summary>
    /// <value>The date first attempt.</value>
    [JsonIgnore]
    public DateTime DateFirstAttempt { get; set; }

    /// <summary>
    /// Gets or sets the date first attempt internal.
    /// </summary>
    /// <value>The date first attempt internal.</value>
    [JsonProperty("dataHoraPrimeiraTentativaEntrega")]
    public long? DateFirstAttemptInternal
    {
        get => DateFirstAttempt.ToUnixTimeStamp();
        set
        {
            if (value != null)
                DateFirstAttempt = Convert.ToInt32(value.Value / 1000).FromUnixTimeStamp();
        }
    }

    /// <summary>
    /// Gets or sets the date expected delivery.
    /// </summary>
    /// <value>The date expected delivery.</value>
    [JsonIgnore]
    public DateTime DateExpectedDelivery { get; set; }

    /// <summary>
    /// Gets or sets the date expected delivery internal.
    /// </summary>
    /// <value>The date expected delivery internal.</value>
    [JsonProperty("dataPrevisaoEntrega")]
    public long? DateExpectedDeliveryInternal
    {
        get => DateExpectedDelivery.ToUnixTimeStamp();
        set
        {
            if (value != null)
                DateExpectedDelivery = Convert.ToInt32(value.Value / 1000).FromUnixTimeStamp();
        }
    }

    /// <summary>
    /// Gets or sets the courier.
    /// </summary>
    /// <value>The courier.</value>
    [JsonProperty("transportadora")]
    public string Courier { get; set; }

    /// <summary>
    /// Gets or sets the minimum delivery time.
    /// </summary>
    /// <value>The minimum delivery time.</value>
    [JsonProperty("prazoMinimo")]
    public int? MinDeliveryTime { get; set; }

    /// <summary>
    /// Gets or sets the maximum delivery time.
    /// </summary>
    /// <value>The maximum delivery time.</value>
    [JsonProperty("prazoMaximo")]
    public int? MaxDeliveryTime { get; set; }

    /// <summary>
    /// Gets or sets the quantity printed by client.
    /// </summary>
    /// <value>The quantity printed by client.</value>
    [JsonProperty("quantidadeImpressaPeloCliente")]
    public int? QuantityPrintedByClient { get; set; }
}