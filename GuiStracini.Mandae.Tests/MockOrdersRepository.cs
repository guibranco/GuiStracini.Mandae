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
    using Enums;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using ValueObject;

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

        /// <summary>
        /// Gets the sample order model for test proposes.
        /// </summary>
        /// <returns>An <see cref="OrderModel"/> instance populated with fake information</returns>
        public static OrderModel GetSampleOrderModel()
        {
            return new OrderModel
            {
                CustomerId = "182AC0ECDE0CA08A8B729733EBE8197D",
                PartnerOrderId = "teste-123456789",
                Observation = "Test order - GuiStracini.Mandae.Test assembly",
                Sender = new Sender
                {
                    Address = new Address
                    {
                        PostalCode = "03137020",
                        Number = "527",
                        City = "São Paulo",
                        Country = "BR",
                        Neighborhood = "Vila Prudente",
                        State = "SP",
                        Street = "Rua Itanháem"
                    },
                    FullName = "Editora Inovação"
                },
                Items = new[]
                {
                    new Item
                    {
                        TrackingId = $"VTR{DateTime.Now:ddMMyyHHmmssffff}", //The VTR prefix must be registred with Mandaê (sending null trackingId will force Mandaê to use it's onw tracking id sequence)
                        Dimensions = new Dimensions
                        {
                            Length = 30,
                            Width = 30,
                            Weight = 2000,
                            Height = 30
                        },
                        Invoice = new Invoice
                        {
                            Id = "606620",
                            Key = "35170805944298000101550010006066201623434877"
                        },
                        PartnerItemId = "5607547",
                        Recipient = new Recipient
                        {
                            Address = new Address
                            {
                                PostalCode = "22041080",
                                Number = "110",
                                Neighborhood = "Copacabana",
                                City = "Rio de Janeiro",
                                State = "RJ",
                                Street = "Rua Anita Garibaild",
                                Country = "BR"
                            },
                            FullName = "João destinatário",
                            Email = "exemplo-contato@mandae.com.br",
                            Phone = "(11) 3382-2031",
                            Document = "24580580001"
                        },
                        Observation = "Sample order test - 5607547",
                        ShippingService = ShippingService.RAPIDO,
                        Skus = new[]
                        {
                            new Sku
                            {
                                Description = "Caneta Acrilpen",
                                Ean = "7891153044392",
                                Price = new Decimal(4.47),
                                Freight = new Decimal(1.2),
                                Quantity = 2,
                                SkuId = "3583"
                            },
                            new Sku
                            {
                                Description = "Tecido algodão crú sem risco",
                                Ean = "789100031550",
                                Price = new Decimal(15.43),
                                Freight = new Decimal(6.8),
                                Quantity = 2,
                                SkuId = "7522"
                            }
                        }
                    }
                },
                Vehicle = Vehicle.CAR,
                Scheduling = DateTime.Today.AddDays(1)
            };
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
            public Int32 Weight { get; set; }
            public Int32 Width { get; set; }
            public Int32 Height { get; set; }
            public Int32 Length { get; set; }
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
