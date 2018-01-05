﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 05/01/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 05/01/2018
// ***********************************************************************
// <copyright file="SearchRequest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Attributes;
    using Enums;
    using System;


    /// <summary>
    /// The model for perform a search request in the Mandaê API V1
    /// </summary>
    /// <seealso cref="GuiStracini.Mandae.Transport.BaseRequestV1" />
    [RequestEndPoint("encomendas/historico?offset={Offset}&limit={Limit}&{Method}={Value}")]
    public sealed class SearchRequest : BaseRequestV1
    {
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        public SearchMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public String Value { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        public Int32 Offset { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        public Int32 Limit { get; set; }

    }
}
