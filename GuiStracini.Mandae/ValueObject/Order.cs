// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 05/01/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 05/01/2018
// ***********************************************************************
// <copyright file="Order.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.ValueObject
{
    using Enums;
    using Newtonsoft.Json;
    using System;
    using Utils;

    /// <summary>
    /// The search response order class
    /// </summary>
    public sealed class Order
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        /// <summary>
        /// Gets or sets the photo URL.
        /// </summary>
        /// <value>
        /// The photo URL.
        /// </value>
        [JsonProperty("urlFoto")]
        public String PhotoUrl { get; set; }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        [JsonProperty("referencia")]
        public String Reference { get; set; }

        /// <summary>
        /// Gets or sets the qr codes.
        /// </summary>
        /// <value>
        /// The qr codes.
        /// </value>
        [JsonProperty("qrCodes")]
        public String[] QrCodes { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        [JsonProperty("observacao")]
        public String Notes { get; set; }

        /// <summary>
        /// Gets or sets the identifier service order.
        /// </summary>
        /// <value>
        /// The identifier service order.
        /// </value>
        [JsonProperty("idOrdemServico")]
        public Int32? IdServiceOrder { get; set; }

        /// <summary>
        /// Gets or sets the service order.
        /// </summary>
        /// <value>
        /// The service order.
        /// </value>
        [JsonProperty("NumeroOrdemServico")]
        public String ServiceOrder { get; set; }

        /// <summary>
        /// Gets or sets the situation.
        /// </summary>
        /// <value>
        /// The situation.
        /// </value>
        [JsonProperty("situacao")]
        public ShippingSituation Situation { get; set; }

        /// <summary>
        /// Gets or sets the situation description.
        /// </summary>
        /// <value>
        /// The situation description.
        /// </value>
        [JsonProperty("codigoSituacao")]
        public String SituationDescription { get; set; }

        /// <summary>
        /// Gets or sets the shipping service.
        /// </summary>
        /// <value>
        /// The shipping service.
        /// </value>
        [JsonProperty("servicoEnvio")]
        public Int32 ShippingService { get; set; }

        /// <summary>
        /// Gets or sets the shipping service description.
        /// </summary>
        /// <value>
        /// The shipping service description.
        /// </value>
        [JsonProperty("codigoServicoEnvio")]
        public String ShippingServiceDescription { get; set; }

        /// <summary>
        /// Gets or sets the name of the shipping service.
        /// </summary>
        /// <value>
        /// The name of the shipping service.
        /// </value>
        [JsonProperty("nomeExibicaoServicoEnvio")]
        public String ShippingServiceName { get; set; }

        /// <summary>
        /// Gets or sets the lenght.
        /// </summary>
        /// <value>
        /// The lenght.
        /// </value>
        [JsonProperty("comprimento")]
        public Decimal? Lenght { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        [JsonProperty("height")]
        public Decimal? Height { get; set; }

        /// <summary>
        /// Gets or sets the diameter.
        /// </summary>
        /// <value>
        /// The diameter.
        /// </value>
        [JsonProperty("diametro")]
        public Decimal? Diameter { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        [JsonProperty("peso")]
        public Decimal? Weight { get; set; }

        /// <summary>
        /// Gets or sets the tracking code.
        /// </summary>
        /// <value>
        /// The tracking code.
        /// </value>
        [JsonProperty("codigoRastreamento")]
        public String TrackingCode { get; set; }

        /// <summary>
        /// Gets or sets the tracking code courier.
        /// </summary>
        /// <value>
        /// The tracking code courier.
        /// </value>
        [JsonProperty("codigoRastreioTransportadora")]
        public String TrackingCodeCourier { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [JsonProperty("valor")]
        public Decimal? Value { get; set; }

        /// <summary>
        /// Gets or sets the internal value.
        /// </summary>
        /// <value>
        /// The internal value.
        /// </value>
        [JsonProperty("custoInterno")]
        public Decimal? InternalValue { get; set; }

        /// <summary>
        /// Gets or sets the recipient.
        /// </summary>
        /// <value>
        /// The recipient.
        /// </value>
        [JsonProperty("destinatario")]
        public RecipientV1 Recipient { get; set; }

        /// <summary>
        /// Gets or sets the label URL.
        /// </summary>
        /// <value>
        /// The label URL.
        /// </value>
        [JsonProperty("urlEtiqueta")]
        public String LabelUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [acknowledgment receipt].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [acknowledgment receipt]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("ar")]
        public Boolean AcknowledgmentReceipt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [own hands].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [own hands]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("maoPropria")]
        public Boolean OwnHands { get; set; }

        /// <summary>
        /// Gets or sets the declared value.
        /// </summary>
        /// <value>
        /// The declared value.
        /// </value>
        [JsonProperty("valorDeclarado")]
        public Decimal? DeclaredValue { get; set; }

        /// <summary>
        /// Gets or sets the packing.
        /// </summary>
        /// <value>
        /// The packing.
        /// </value>
        [JsonProperty("embalagem")]
        public String Packing { get; set; }

        /// <summary>
        /// Gets or sets the packing code.
        /// </summary>
        /// <value>
        /// The packing code.
        /// </value>
        [JsonProperty("codigoEmbalagem")]
        public String PackingCode { get; set; }

        /// <summary>
        /// Gets or sets the shipping label.
        /// </summary>
        /// <value>
        /// The shipping label.
        /// </value>
        [JsonProperty("etiquetaEmbalagem")]
        public Int32? ShippingLabel { get; set; }

        /// <summary>
        /// Gets or sets the shipping label description.
        /// </summary>
        /// <value>
        /// The shipping label description.
        /// </value>
        [JsonProperty("codigoEtiquetaEnvio")]
        public String ShippingLabelDescription { get; set; }

        /// <summary>
        /// Gets or sets the tracking URL.
        /// </summary>
        /// <value>
        /// The tracking URL.
        /// </value>
        [JsonProperty("urlRastreamento")]
        public String TrackingUrl { get; set; }

        /// <summary>
        /// Gets or sets the date delivered.
        /// </summary>
        /// <value>
        /// The date delivered.
        /// </value>
        [JsonIgnore]
        public DateTime DateDelivered { get; set; }

        /// <summary>
        /// Gets or sets the date delivered internal.
        /// </summary>
        /// <value>
        /// The date delivered internal.
        /// </value>
        [JsonProperty("dataHoraEntrega")]
        public Int64? DateDeliveredInternal
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
        /// <value>
        /// The date lost.
        /// </value>
        [JsonIgnore]
        public DateTime DateLost { get; set; }

        /// <summary>
        /// Gets or sets the date lost internal.
        /// </summary>
        /// <value>
        /// The date lost internal.
        /// </value>
        [JsonProperty("dataHoraExtraviada")]
        public Int64? DateLostInternal
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
        /// <value>
        /// The date first attempt.
        /// </value>
        [JsonIgnore]
        public DateTime DateFirstAttempt { get; set; }

        /// <summary>
        /// Gets or sets the date first attempt internal.
        /// </summary>
        /// <value>
        /// The date first attempt internal.
        /// </value>
        [JsonProperty("dataHoraPrimeiraTentativaEntrega")]
        public Int64? DateFirstAttemptInternal
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
        /// <value>
        /// The date expected delivery.
        /// </value>
        [JsonIgnore]
        public DateTime DateExpectedDelivery { get; set; }

        /// <summary>
        /// Gets or sets the date expected delivery internal.
        /// </summary>
        /// <value>
        /// The date expected delivery internal.
        /// </value>
        [JsonProperty("dataPrevisaoEntrega")]
        public Int64? DateExpectedDeliveryInternal
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
        /// <value>
        /// The courier.
        /// </value>
        [JsonProperty("transportadora")]
        public String Courier { get; set; }

        /// <summary>
        /// Gets or sets the minimum delivery time.
        /// </summary>
        /// <value>
        /// The minimum delivery time.
        /// </value>
        [JsonProperty("prazoMinimo")]
        public Int32? MinDeliveryTime { get; set; }

        /// <summary>
        /// Gets or sets the maximum delivery time.
        /// </summary>
        /// <value>
        /// The maximum delivery time.
        /// </value>
        [JsonProperty("prazoMaximo")]
        public Int32? MaxDeliveryTime { get; set; }

        /// <summary>
        /// Gets or sets the quantity printed by client.
        /// </summary>
        /// <value>
        /// The quantity printed by client.
        /// </value>
        [JsonProperty("quantidadeImpressaPeloCliente")]
        public Int32? QuantityPrintedByClient { get; set; }
    }
}
