// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 2018-07-27
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 12-26-2022
// ***********************************************************************
// <copyright file="ReverseSearchMethod.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Enums
{
    using SDKBuilder.Routing;

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
