// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 03/10/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 03/10/2017
// ***********************************************************************
// <copyright file="MockOrdersRepository.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Test
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class MockOrdersRepository
    {
        private MockOrders _orders;

        private MockOrdersItems _ordersItems;

        public MockOrdersRepository()
        {
            _orders = JsonConvert.DeserializeObject<MockOrders>(File.ReadAllText("orders.json"));
            _ordersItems = JsonConvert.DeserializeObject<MockOrdersItems>(File.ReadAllText("items.json"));
        }

        public async Task<IEnumerable<Int32>> GetOrdersIdsPendingShippingAsync()
        {
            await Task.Delay(5000);
            return new[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10
            };
        }

        public MockOrder GetOrder(Int32 orderId)
        {
            return _orders.Orders.SingleOrDefault(o => o.OrderId == orderId);
        }

        public IEnumerable<MockOrderItem> GetOrderItems(Int32 orderId)
        {
            return _ordersItems.Items.Where(i => i.OrderId == orderId);
        }

        public sealed class MockOrders
        {
            public MockOrder[] Orders { get; set; }
        }

        public sealed class MockOrdersItems
        {
            public MockOrderItem[] Items { get; set; }
        }

        public sealed class MockOrder
        {
            public Int32 OrderId { get; set; }
            public Decimal Value { get; set; }
            public String InvoiceNumber { get; set; }
            public String InvoiceKey { get; set; }
            public Decimal Weight { get; set; }
            public Decimal Width { get; set; }
            public Decimal Height { get; set; }
            public Decimal Length { get; set; }
            public String FullName { get; set; }
            public String Document { get; set; }
            public String Telephone { get; set; }
            public String Email { get; set; }
            public String ZipCode { get; set; }
            public String Street { get; set; }
            public String Neighborhood { get; set; }
            public Int32 Number { get; set; }
            public String Complement { get; set; }
            public String City { get; set; }
            public String StateInitials { get; set; }
        }

        public sealed class MockOrderItem
        {
            public Int32 OrderId { get; set; }
            public Int32 SkuId { get; set; }
            public Decimal Price { get; set; }
            public Decimal PriceFreight { get; set; }
            public String Ean { get; set; }
            public String Name { get; set; }
            public Int32 Quantity { get; set; }
        }
    }
}
