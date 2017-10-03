// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 29/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 03/10/2017
// ***********************************************************************
// <copyright file="" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae
{
    using Enums;
    using GoodPractices;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Transport;
    using ValueObject;

    /// <summary>
    /// The order builder is used to facilitate the collection request process.
    /// Each instance is responsbile to create a new order collect request in the Mandaê APi.
    /// This builder allows you set data in separated moments.
    /// You can create a builder, and each package/order (item) can be processed by a diferent thread, and the end calls the build method to send the request to Mandaê
    /// </summary>

    public sealed class OrderBuilder : IOrderBuilder
    {
        #region Private fields

        /// <summary>
        /// The model
        /// </summary>
        private readonly OrderModel _model;
        /// <summary>
        /// The client
        /// </summary>
        private readonly IMandaeClient _client;
        /// <summary>
        /// The items
        /// </summary>
        private readonly ICollection<ItemModel> _items;
        /// <summary>
        /// Flag indicating whetever the order was already built or not
        /// </summary>
        private Boolean _built;

        #endregion

        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBuilder"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public OrderBuilder(IMandaeClient client)
        {
            _client = client;
            _model = new OrderModel();
            _items = new List<ItemModel>();
        }

        #endregion

        #region Implementation of IOrderBuilder

        /// <summary>
        /// Sets the customer id of the pickup request
        /// </summary>
        /// <param name="customerId">The customer id, where the order (packages/items) will be pickuped</param>
        public void SetCustomerId(String customerId)
        {
            _model.CustomerId = customerId;
        }

        /// <summary>
        /// Sets the sender of the order
        /// </summary>
        /// <param name="sender">The sender information</param>
        public void SetSender(Sender sender)
        {
            _model.Sender = sender;
        }

        /// <summary>
        /// Sets the vehicle for the pickup in the customer distribution center / hub
        /// </summary>
        /// <param name="vehicle"><see cref="Vehicle"/> enumeration</param>
        public void SetVehicle(Vehicle vehicle)
        {
            _model.Vehicle = vehicle;
        }

        /// <summary>
        /// Sets the collect date
        /// </summary>
        /// <param name="date">The date when the Mandaê will pickup the packages/orders in the Hub/storage/distribution center of the requester</param>
        public void SetCollectDate(DateTime date)
        {
            _model.Scheduling = date;
        }

        /// <summary>
        /// Sets the order observation
        /// </summary>
        /// <param name="observation">A observation to the Mandaê staff</param>
        public void SetObservation(String observation)
        {
            _model.Observation = observation;
        }

        /// <summary>
        /// Adds a item (package/order) to the collect request.
        /// Each item can have one or many SKU.
        /// You can pass the skus by the model, in the Sku property, or add later passing the <see cref="Guid"/> returned by this method to the 
        /// AddSku method
        /// </summary>
        /// <param name="model">The item model. Includes de delivery information, the shipping method and optionally the sku list of itens in this package</param>
        /// <returns>Returns a <see cref="Guid"/> that allows you add Sku to this package later</returns>
        public Guid AddItem(Item model)
        {
            var item = new ItemModel
            {
                Id = Guid.NewGuid(),
                Item = model
            };
            _items.Add(item);
            return item.Id;
        }

        /// <summary>
        /// Adds a <see cref="Sku"/> to the <see cref="Item"/> (package/order) created at the AddItem method.
        /// Uses the <see cref="Guid"/> returned by the AddItem method to identify the item in this method.
        /// </summary>
        /// <param name="sku">The <see cref="Sku"/> to be added to the item (package/order)</param>
        /// <param name="id">The <see cref="Guid"/> identifing the <see cref="Item"/> returned by the AddItem method</param>
        public void AddSku(Sku sku, Guid id)
        {
            var item = _items.Single(i => i.Id == id);
            var skuList = item.Item.Skus.ToList();
            skuList.Add(sku);
            item.Item.Skus = skuList.ToArray();
        }

        /// <summary>
        /// Builds the order immediately, returning an instance of <see cref="OrderRequest"/> with the OrderId property populated
        /// </summary>
        /// <returns>An instance of <see cref="OrderRequest"/> with order details and the order id in the Mandaê platform</returns>
        /// <exception cref="OrderBuiltException">Throws when the order of this instance of <see cref="OrderBuilder"/> was already built</exception>
        public OrderResponse Build()
        {
            if (_built)
                throw new OrderBuiltException();
            PrepareModel();
            return _client.CreateOrderCollectRequest(_model);
        }

        /// <summary>
        /// Builds the order using the async parameter to the Mandaê API, wich creates a JobId (<see cref="Guid"/>) that will be web hooked later by the Mandaê API when ther order is created at Mandaê side.
        /// </summary>
        /// <returns>Returns the JobId as <see cref="Guid"/> of the job in the Mandaê API. This will be passed as reference in the web hook when the job/order creation if finished in the Mandaê side</returns>
        /// <exception cref="OrderBuiltException">Throws when the order of this instance of <see cref="OrderBuilder"/> was already built</exception>
        public Guid BuildDelayed()
        {
            if (_built)
                throw new OrderBuiltException();
            PrepareModel();
            return _client.CreateLargeOrderCollectRequest(_model);
        }

        /// <summary>
        /// Prepares the model, inserting all OrderBuilder items to the model items property.
        /// </summary>
        private void PrepareModel()
        {
            _model.Items = _items.Select(i => i.Item).ToArray();
            _built = true;
        }

        #endregion
    }
}