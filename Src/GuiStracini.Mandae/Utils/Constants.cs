// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 23/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="Constants.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.Utils
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class Constants. This class cannot be inherited.
    /// </summary>
    internal abstract class Constants
    {
        /// <summary>
        /// The user agent
        /// </summary>
        public const string UserAgent = @"GuiStracini.Mandae/7.0.0";

        /// <summary>
        /// The sandbox environment service endpoint base address
        /// </summary>
        public const string SandboxServiceEndpoint = "https://sandbox.api.mandae.com.br/v2/";

        /// <summary>
        /// The production environment service endpoint base address
        /// </summary>
        public const string ProductionServiceEndpoint = "https://api.mandae.com.br/v2/";

        /// <summary>
        /// The dashboard endpoint
        /// </summary>
        public const string DashboardEndpoint = "https://app.mandae.com.br/";

        /// <summary>
        /// The constants pattern
        /// </summary>
        public static readonly Regex PathPattern = new Regex(
            @"(main\.(?:.+?)\.js)",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
            TimeSpan.FromMilliseconds(100)
        );

        /// <summary>
        /// The constants js pattern
        /// </summary>
        public static readonly Regex JsPattern = new Regex(
            "angularJSconstants: {(?<constants>.+?)},?",
            RegexOptions.Compiled
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnoreCase
                | RegexOptions.Singleline,
            TimeSpan.FromMilliseconds(100)
        );

        /// <summary>
        /// The constant pattern
        /// </summary>
        public static readonly Regex Pattern = new Regex(
            @"(?:[\s|\t]*)(?<key>.+?)\:\s?'(?<value>.+?)',?",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
            TimeSpan.FromMilliseconds(100)
        );
    }
}
