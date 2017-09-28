// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="RequestEndPointBadFormatException" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ListaDeCompras.Commons.GoodPractices
{
    using System;

    /// <summary>
    /// Throws when a request format is in a bad format
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class RequestEndPointBadFormatException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestEndPointBadFormatException"/> class.
        /// </summary>
        /// <param name="endpointFormat">The endpoint format.</param>
        public RequestEndPointBadFormatException(String endpointFormat)
            : base($"Unable to resolve the endpoint format {endpointFormat}")
        { }

    }
}