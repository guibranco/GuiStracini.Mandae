﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 05/01/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="SearchMethod.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using GuiStracini.SDKBuilder.Routing;

namespace GuiStracini.Mandae.Enums
{
    /// <summary>
    /// The search method (API V1) enumeration
    /// </summary>
    public enum SearchMethod
    {
        /// <summary>
        /// The tracking code.
        /// </summary>
        [EnumRouteValue("rastreamento")]
        TRACKING_CODE,

        /// <summary>
        /// The receiver name.
        /// </summary>
        [EnumRouteValue("nomeDestinatario")]
        RECEIVER_NAME,

        /// <summary>
        /// The postal code.
        /// </summary>
        [EnumRouteValue("cepDestinatario")]
        POSTAL_CODE,

        /// <summary>
        /// The service order.
        /// </summary>
        [EnumRouteValue("numeroPedido")]
        SERVICE_ORDER,

        /// <summary>
        /// The label status.
        /// </summary>
        [EnumRouteValue("jaFoiImpressa")]
        LABEL_STATUS,

        /// <summary>
        /// The parcel status.
        /// </summary>
        [EnumRouteValue("situacaoPedido")]
        PARCEL_STATUS,

        /// <summary>
        /// The carrier tracking code.
        /// </summary>
        [EnumRouteValue("codigoRastreioTransportadora")]
        CARRIER_TRACKING_CODE,

        /// <summary>
        /// The QR code.
        /// </summary>
        [EnumRouteValue("qrCode")]
        QR_CODE,

        /// <summary>
        /// The reference.
        /// </summary>
        [EnumRouteValue("referencia")]
        REFERENCE,
    }
}
