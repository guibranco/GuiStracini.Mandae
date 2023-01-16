// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 12-26-2022
// ***********************************************************************
// <copyright file="ExtendedEndpointRouteAttribute.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Attributes
{
    using SDKBuilder.Routing;
    using System;

    /// <summary>
    /// Class ExtendedEndpointRouteAttribute. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ExtendedEndpointRouteAttribute : EndpointRouteAttribute
    {
        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedEndpointRouteAttribute" /> class.C:\Repositórios\GuiStracini.Mandae\GuiStracini.Mandae\Attributes\RequestEndPoint.cs
        /// </summary>
        /// <param name="endPoint">The end point path of the request.</param>
        public ExtendedEndpointRouteAttribute(string endPoint)
            : base(endPoint)
        { }

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