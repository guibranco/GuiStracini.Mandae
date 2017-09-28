// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2107
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2107
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
    internal sealed class RequestEndPointAttribute : Attribute
    {
        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value>The end point path.</value>
        public String EndPoint { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestEndPointAttribute"/> class.
        /// </summary>
        /// <param name="endPoint">The end point path of the request.</param>
        public RequestEndPointAttribute(String endPoint)
        {
            EndPoint = endPoint;
        }
    }
}