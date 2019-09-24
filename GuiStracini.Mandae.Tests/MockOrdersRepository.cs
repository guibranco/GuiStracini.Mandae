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
    using ValueObject;

    /// <summary>
    /// The mock orders repository
    /// </summary>
    internal sealed class MockOrdersRepository
    {
        /// <summary>
        /// The orders
        /// </summary>
        private readonly MockOrders _orders;

        /// <summary>
        /// The orders items
        /// </summary>
        private readonly MockOrdersItems _ordersItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockOrdersRepository"/> class.
        /// </summary>
        public MockOrdersRepository()
        {
            _orders = JsonConvert.DeserializeObject<MockOrders>(File.ReadAllText("orders.json"));
            _ordersItems = JsonConvert.DeserializeObject<MockOrdersItems>(File.ReadAllText("items.json"));
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public MockOrder GetOrder(int orderId)
        {
            return _orders.Orders.SingleOrDefault(o => o.OrderId == orderId);
        }

        /// <summary>
        /// Gets the order items.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public IEnumerable<MockOrderItem> GetOrderItems(int orderId)
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
                        Id= new Random().Next(10000,99999),
                        TrackingId = $"VTR{DateTime.Now:ddMMyyHHmmssffff}", //The VTR prefix must be registred with Mandaê (sending null trackingId will force Mandaê to use it's onw tracking id sequence)
                        Dimensions = new Dimensions
                        {
                            Length = 30,
                            Width = 30,
                            Weight = 2.6,
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
                                Price = new decimal(4.47),
                                Freight = new decimal(1.2),
                                Quantity = 2,
                                SkuId = "3583"
                            },
                            new Sku
                            {
                                Description = "Tecido algodão crú sem risco",
                                Ean = "789100031550",
                                Price = new decimal(15.43),
                                Freight = new decimal(6.8),
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

        /// <summary>
        /// The mock orders class
        /// </summary>
        public sealed class MockOrders
        {
            /// <summary>
            /// Gets or sets the orders.
            /// </summary>
            /// <value>
            /// The orders.
            /// </value>
            public MockOrder[] Orders { get; set; }
        }

        /// <summary>
        /// The mock orders items class
        /// </summary>
        public sealed class MockOrdersItems
        {
            /// <summary>
            /// Gets or sets the items.
            /// </summary>
            /// <value>
            /// The items.
            /// </value>
            public MockOrderItem[] Items { get; set; }
        }
        /// <summary>
        /// The mock order class
        /// </summary>
        public sealed class MockOrder
        {
            /// <summary>
            /// Gets or sets the order identifier.
            /// </summary>
            /// <value>
            /// The order identifier.
            /// </value>
            public int OrderId { get; set; }
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>
            /// The value.
            /// </value>
            public decimal Value { get; set; }
            /// <summary>
            /// Gets or sets the invoice number.
            /// </summary>
            /// <value>
            /// The invoice number.
            /// </value>
            public string InvoiceNumber { get; set; }
            /// <summary>
            /// Gets or sets the invoice key.
            /// </summary>
            /// <value>
            /// The invoice key.
            /// </value>
            public string InvoiceKey { get; set; }
            /// <summary>
            /// Gets or sets the weight.
            /// </summary>
            /// <value>
            /// The weight.
            /// </value>
            public int Weight { get; set; }
            /// <summary>
            /// Gets or sets the width.
            /// </summary>
            /// <value>
            /// The width.
            /// </value>
            public int Width { get; set; }
            /// <summary>
            /// Gets or sets the height.
            /// </summary>
            /// <value>
            /// The height.
            /// </value>
            public int Height { get; set; }
            /// <summary>
            /// Gets or sets the length.
            /// </summary>
            /// <value>
            /// The length.
            /// </value>
            public int Length { get; set; }
            /// <summary>
            /// Gets or sets the full name.
            /// </summary>
            /// <value>
            /// The full name.
            /// </value>
            public string FullName { get; set; }
            /// <summary>
            /// Gets or sets the document.
            /// </summary>
            /// <value>
            /// The document.
            /// </value>
            public string Document { get; set; }
            /// <summary>
            /// Gets or sets the telephone.
            /// </summary>
            /// <value>
            /// The telephone.
            /// </value>
            public string Telephone { get; set; }
            /// <summary>
            /// Gets or sets the email.
            /// </summary>
            /// <value>
            /// The email.
            /// </value>
            public string Email { get; set; }
            /// <summary>
            /// Gets or sets the zip code.
            /// </summary>
            /// <value>
            /// The zip code.
            /// </value>
            public string ZipCode { get; set; }
            /// <summary>
            /// Gets or sets the street.
            /// </summary>
            /// <value>
            /// The street.
            /// </value>
            public string Street { get; set; }
            /// <summary>
            /// Gets or sets the neighborhood.
            /// </summary>
            /// <value>
            /// The neighborhood.
            /// </value>
            public string Neighborhood { get; set; }
            /// <summary>
            /// Gets or sets the number.
            /// </summary>
            /// <value>
            /// The number.
            /// </value>
            public int Number { get; set; }
            /// <summary>
            /// Gets or sets the complement.
            /// </summary>
            /// <value>
            /// The complement.
            /// </value>
            public string Complement { get; set; }
            /// <summary>
            /// Gets or sets the city.
            /// </summary>
            /// <value>
            /// The city.
            /// </value>
            public string City { get; set; }
            /// <summary>
            /// Gets or sets the state initials.
            /// </summary>
            /// <value>
            /// The state initials.
            /// </value>
            public string StateInitials { get; set; }
        }
        /// <summary>
        /// The mock order item class
        /// </summary>
        public sealed class MockOrderItem
        {
            /// <summary>
            /// Gets or sets the order identifier.
            /// </summary>
            /// <value>
            /// The order identifier.
            /// </value>
            public int OrderId { get; set; }
            /// <summary>
            /// Gets or sets the sku identifier.
            /// </summary>
            /// <value>
            /// The sku identifier.
            /// </value>
            public int SkuId { get; set; }
            /// <summary>
            /// Gets or sets the price.
            /// </summary>
            /// <value>
            /// The price.
            /// </value>
            public decimal Price { get; set; }
            /// <summary>
            /// Gets or sets the price freight.
            /// </summary>
            /// <value>
            /// The price freight.
            /// </value>
            public decimal PriceFreight { get; set; }
            /// <summary>
            /// Gets or sets the ean.
            /// </summary>
            /// <value>
            /// The ean.
            /// </value>
            public string Ean { get; set; }
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>
            /// The name.
            /// </value>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the quantity.
            /// </summary>
            /// <value>
            /// The quantity.
            /// </value>
            public int Quantity { get; set; }
        }
    }
}
