﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 2018-07-27
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="ReverseSearchMethod.cs" company="Guilherme Branco Stracini ME">
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
    public enum ReverseSearchMethod
    {
        /// <summary>
        /// The tracking code.
        /// </summary>
        [EnumRouteValue("rastreamento")]
        TRACKING_CODE,

        /// <summary>
        /// The sender name.
        /// </summary>
        [EnumRouteValue("nomeRemetente")]
        SENDER_NAME,

        /// <summary>
        /// The postal code.
        /// </summary>
        [EnumRouteValue("cepRemetente")]
        POSTAL_CODE,

        /// <summary>
        /// The order code.
        /// </summary>
        [EnumRouteValue("pedido")]
        ORDER_CODE,

        /// <summary>
        /// The carrier code.
        /// </summary>
        [EnumRouteValue("codigoTransportadora")]
        CARRIER_CODE,
    }
}
