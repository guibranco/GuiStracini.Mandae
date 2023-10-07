// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 26/03/2023
// ***********************************************************************
// <copyright file="ExtendedEndpointRouteAttribute.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.Attributes
{
    using System;
    using SDKBuilder.Routing;

    /// <summary>
    /// Class ExtendedEndpointRouteAttribute. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ExtendedEndpointRouteAttribute : EndpointRouteAttribute
    {
        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedEndpointRouteAttribute" /> class.
        /// </summary>
        /// <param name="endPoint">The end point path of the request.</param>
        public ExtendedEndpointRouteAttribute(string endPoint)
            : base(endPoint) { }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the custom base.
        /// </summary>
        /// <value>The custom base.</value>
        public string CustomBase { get; set; }

        #endregion
    }
}