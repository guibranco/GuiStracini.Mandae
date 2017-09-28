// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="InvalidRequestEndPointException.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.GoodPractices
{

    using System;

    /// <summary>
    /// Throws when a invalid request end point pattern is found while resolving the request endpoint
    /// </summary>
    /// <seealso cref="System.Exception" />
    public sealed class InvalidRequestEndPointException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRequestEndPointException"/> class.
        /// </summary>
        /// <param name="endpointPattern">The endpoint pattern.</param>
        /// <param name="endpointResolved">The endpoint resolved.</param>
        public InvalidRequestEndPointException(String endpointPattern, String endpointResolved)
            : base($"The endpoint {endpointResolved} is not valid for the pattern {endpointPattern}")
        { }
    }
}