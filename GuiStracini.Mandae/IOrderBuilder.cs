// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 29/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 29/09/2017
// ***********************************************************************
// <copyright file="IOrderBuilder.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae
{
    using Enums;
    using Models;
    using System;
    using Transport;
    using ValueObject;

    /// <summary>
    /// The order builder interface
    /// </summary>
    public interface IOrderBuilder
    {
        /// <summary>
        /// Sets the sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        void SetSender(Sender sender);

        /// <summary>
        /// Sets the vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle.</param>
        void SetVehicle(Vehicle vehicle);

        /// <summary>
        /// Gets the rates.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        RatesResponse GetRates(RatesModel model);

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Guid AddItem(ItemModel model);

        /// <summary>
        /// Adds the sku.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <param name="guid">The unique identifier.</param>
        void AddSku(Sku sku, Guid guid);

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        OrderRequest Build();
    }
}
