// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 12-26-2022
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="SearchReverseResponse.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.Transport.V1
{
    using ValueObject;

    /// <summary>
    /// The reverse response class.
    /// </summary>
    /// <seealso cref="GuiStracini.Mandae.Transport.BaseResponse" />
    public sealed class SearchReverseResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the reverses.
        /// </summary>
        /// <value>The reverses.</value>
        public Reverse[] Reverses { get; set; }
    }
}