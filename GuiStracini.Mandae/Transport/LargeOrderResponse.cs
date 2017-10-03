// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 03/10/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 03/10/2017
// ***********************************************************************
// <copyright file="LargeOrderResponse.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Transport
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// The large order collect response
    /// </summary>
    public sealed class LargeOrderResponse : BaseResponse
    {
        /// <summary>
        /// The job identifier
        /// </summary>
        [JsonProperty("jobId")]
        public Guid JobId { get; set; }
    }
}
