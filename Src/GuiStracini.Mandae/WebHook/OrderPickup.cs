// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 23/01/2023
// ***********************************************************************
// <copyright file="OrderPickup.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.WebHook
{
    using System;

    /// <summary>
    /// The order pickup web hook model
    /// </summary>
    public sealed class OrderPickup
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public long OrderId { get; set; }

        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        public Guid JobId { get; set; }

        /// <summary>
        /// Gets or sets the partner order identifier.
        /// </summary>
        /// <value>The partner order identifier.</value>
        public string PartnerOrderId { get; set; }
    }
}
