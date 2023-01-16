// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 05/01/2018
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 12-26-2022
// ***********************************************************************
// <copyright file="ShippingSituation.cs" company="Guilherme Branco Stracini">
//     Copyright © 2018 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Enums
{
    /// <summary>
    /// The shipping situation
    /// </summary>
    public enum ShippingSituation
    {
        /// <summary>
        /// The none
        /// </summary>
        NONE = 0,
        /// <summary>
        /// The new
        /// </summary>
        NEW = 1,
        /// <summary>
        /// The processing
        /// </summary>
        PROCESSING = 2,
        /// <summary>
        /// The sent
        /// </summary>
        SENT = 4,
        /// <summary>
        /// The lost
        /// </summary>
        LOST = 5,
        /// <summary>
        /// The delivered
        /// </summary>
        DELIVERED = 6,
        /// <summary>
        /// The waiting withdrawal
        /// </summary>
        WAITING_WITHDRAWAL = 7,
        /// <summary>
        /// The canceled
        /// </summary>
        CANCELED = 8,
        /// <summary>
        /// The returning
        /// </summary>
        RETURNING = 9,
        /// <summary>
        /// The returned
        /// </summary>
        RETURNED = 10,
        /// <summary>
        /// The returned to sender
        /// </summary>
        RETURNED_TO_SENDER = 11,
        /// <summary>
        /// The not collect
        /// </summary>
        NOT_COLLECT = 12
    }
}
