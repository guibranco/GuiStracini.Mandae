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

        private readonly ICollection<ItemModel> _items;

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

        public void SetSender(Sender sender)
        {
            _model.Sender = sender;
        }

        public void SetVehicle(Vehicle vehicle)
        {
            _model.Vehicle = vehicle;
        }

        public RatesResponse GetRates(RatesModel model)
        {
            return _client.GetRates(model);
        }

        public Guid AddItem(Item model)
        {
            var item = new ItemModel
            {
                Identifier = Guid.NewGuid(),
                Item = model
            };
            _items.Add(item);
            return item.Identifier;
        }

        public void AddSku(Sku sku, Guid guid)
        {
            var item = _items.Single(i => i.Identifier == guid);
            var skuList = item.Item.Skus.ToList();
            skuList.Add(sku);
            item.Item.Skus = skuList.ToArray();
        }

        public OrderRequest Build()
        {
            if (_built)
                throw new OrderBuiltException();
            PrepareModel();
            return _client.CreateOrderCollectRequest(_model);
        }


        public Guid BuildDelayed()
        {
            if (_built)
                throw new OrderBuiltException();
            PrepareModel();
            return _client.CreateLargeOrderCollectRequest(_model);
        }

        private void PrepareModel()
        {
            _model.Items = _items.Select(i => i.Item).ToArray();
            _built = true;
        }

        #endregion
    }
}
