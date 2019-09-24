// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="RequestEndPoint.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Attributes
{
    using System;

    /// <summary>
    /// Class RequestEndPointAttribute. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RequestEndPointAttribute : Attribute
    {

        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestEndPointAttribute"/> class.
        /// </summary>
        /// <param name="endPoint">The end point path of the request.</param>
        public RequestEndPointAttribute(string endPoint)
        {
            EndPoint = endPoint;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value>The end point path.</value>
        public string EndPoint { get; }

        /// <summary>
        /// Gets or sets the custom base.
        /// </summary>
        /// <value>
        /// The custom base.
        /// </value>
        public string CustomBase { get; set; }
        #endregion

    }
}