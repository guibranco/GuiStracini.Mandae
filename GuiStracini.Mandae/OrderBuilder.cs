namespace GuiStracini.Mandae
{
    using Enums;
    using Models;
    using System;
    using Transport;
    using ValueObject;

    public sealed class OrderBuilder : IOrderBuilder
    {
        #region Private fields

        /// <summary>
        /// The model
        /// </summary>
        private OrderModel _model;
        /// <summary>
        /// The client
        /// </summary>
        private IMandaeClient _client;

        #endregion

        #region ~Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBuilder"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public OrderBuilder(IMandaeClient client)
        {
            _client = client;
        }

        #endregion

        #region Implementation of IOrderBuilder

        public void SetSender(Sender sender)
        {
            throw new NotImplementedException();
        }

        public void SetVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public RatesResponse GetRates(RatesModel model)
        {
            throw new NotImplementedException();
        }

        public Guid AddItem(ItemModel model)
        {
            throw new NotImplementedException();
        }

        public void AddSku(Sku sku, Guid guid)
        {
            throw new NotImplementedException();
        }

        public OrderRequest Build()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
