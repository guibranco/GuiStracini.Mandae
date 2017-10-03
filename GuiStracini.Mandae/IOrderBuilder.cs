// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 29/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 03/10/2017
// ***********************************************************************
// <copyright file="IOrderBuilder.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae
{
    using Enums;
    using System;
    using Transport;
    using ValueObject;

    /// <summary>
    /// The order builder interface
    /// </summary>
    public interface IOrderBuilder
    {
        /// <summary>
        /// Sets the customer id of the pickup request
        /// </summary>
        /// <param name="customerId">The customer id, where the order (packages/items) will be pickuped</param>
        void SetCustomerId(String customerId);

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
        /// Sets the collect date
        /// </summary>
        /// <param name="date">The date when the Mandaê will pickup the packages/orders in the Hub/storage/distribution center of the requester</param>
        void SetCollectDate(DateTime date);

        /// <summary>
        /// Sets the order observation
        /// </summary>
        /// <param name="observation">A observation to the Mandaê staff</param>
        void SetObservation(String observation);

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Guid AddItem(Item model);

        /// <summary>
        /// Adds the sku.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <param name="id">The unique identifier.</param>
        void AddSku(Sku sku, Guid id);

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        OrderResponse Build();

        /// <summary>
        /// Builds this instance delayed.
        /// </summary>
        /// <returns></returns>
        Guid BuildDelayed();
    }
}
