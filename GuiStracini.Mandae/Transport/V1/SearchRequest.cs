// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 2018-01-05
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="SearchRequest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport.V1
{
    using Attributes;
    using Enums;
    using GuiStracini.SDKBuilder.Routing;

    /// <summary>
    /// The model for perform a search request in the Mandaê API V1
    /// </summary>
    /// <seealso cref="Request" />
    [ExtendedEndpointRoute(
        "v1/encomendas/historico?offset={Offset}&limit={Limit}&{Method}={Value}"
    )]
    public sealed class SearchRequest : Request
    {
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>The method.</value>
        public SearchMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        [DefaultRouteValue("0")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>The limit.</value>
        [DefaultRouteValue("10")]
        public int Limit { get; set; }
    }
}
