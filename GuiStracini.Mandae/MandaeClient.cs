// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="MandaeClient.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae
{
    using System;
    using Utils;

    /// <summary>
    /// The unofficial Mandaê API client class.
    /// Implementation based on https://dev.mandae.com.br/api/index.html
    /// </summary>
    public sealed class MandaeClient
    {
        #region Private fields

        /// <summary>
        /// The service factory instance
        /// </summary>
        private readonly ServiceFactory _service;

        /// <summary>
        /// The Mandaê API token
        /// </summary>
        private readonly String _token;

        /// <summary>
        /// The configure await flag
        /// </summary>
        private readonly Boolean _configureAwait;

        #endregion

        #region ~Ctors

        public MandaeClient(
            String token,
            Enums.Environment environment = Enums.Environment.SANDBOX,
            Boolean configureAwait = true)
        {
            _token = token;
            _configureAwait = configureAwait;
            _service = new ServiceFactory(environment, _configureAwait);

        }

        #endregion

    }
}
