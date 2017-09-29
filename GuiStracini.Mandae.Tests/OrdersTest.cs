// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="OrdersTest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Test
{
    using Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ValueObject;

    /// <summary>
    /// The orders test class
    /// </summary>
    [TestClass]
    public class OrdersTest
    {
        /// <summary>
        /// Gets the sample order model for test proposes.
        /// </summary>
        /// <returns>An <see cref="OrderModel"/> instance populated with fake information</returns>
        private OrderModel GetSampleOrderModel()
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
                        Number = 527,
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
                        Dimensions = new Dimensions
                        {
                            Length = 30,
                            Width = 30,
                            Weight = 2,
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
                                Number = 110,
                                Neighborhood = "Copacabana",
                                City = "Rio de Janeiro",
                                State = "RJ",
                                Street = "Rua Anita Garibaild",
                                Country = "BR"
                            },
                            FullName = "Vitrine do Artesanato",
                            Email = "",
                            Phone = "+551133822031",
                            Document = "05944298000101"
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
                                Quantity = 2,
                                SkuId = "3583"
                            },
                            new Sku
                            {
                                Description = "Tecido algodão crú sem risco",
                                Ean = String.Empty,
                                Price = new Decimal(15.43),
                                Quantity = 2,
                                SkuId = "7522"
                            }
                        }
                    }
                },
                Vehicle = Vehicle.CAR,
                Scheduling = DateTime.Now.AddDays(1)
            };
        }

        /// <summary>
        /// Validates register order collect request method.
        /// </summary>
        [TestMethod]
        public void RegisterOrderCollectRequest()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var orderModel = GetSampleOrderModel();
            var order = client.CreateOrderCollectRequest(orderModel);
            Assert.IsNotNull(order.OrderId);
            Assert.IsTrue(order.OrderId > 0);
        }

        /// <summary>
        /// Validates register order collect request asynchronous method.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task RegisterOrderCollectRequestAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var orderModel = GetSampleOrderModel();
            var order = await client.CreateOrderCollectRequestAsync(orderModel, source.Token);
            Assert.IsNotNull(order.OrderId);
            Assert.IsTrue(order.OrderId > 0);
        }


        /// <summary>
        /// Validates register large order collect request method.
        /// </summary>
        [TestMethod]
        public void RegisterLargeOrderCollectRequest()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var orderModel = GetSampleOrderModel();
            var jobId = client.CreateLargeOrderCollectRequest(orderModel);
            Assert.IsNotNull(jobId);
            Assert.AreNotEqual(new Guid(), jobId);

        }

        /// <summary>
        /// Validates register large order collect request asynchronous meethod.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task RegisterLargeOrderCollectRequestAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var orderModel = GetSampleOrderModel();
            var jobId = await client.CreateLargeOrderCollectRequestAsync(orderModel, source.Token);
            Assert.IsNotNull(jobId);
            Assert.AreNotEqual(new Guid(), jobId);
        }

        /// <summary>
        /// Validates get latest order collect status method.
        /// </summary>
        [TestMethod]
        public void GetLatestOrderCollectStatus()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var status = client.GetLatestOrderCollectStatus("182AC0ECDE0CA08A8B729733EBE8197D");
            Assert.IsNotNull(status.Url);
        }


        /// <summary>
        /// Validates Get latest order collect status asynchronous method.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetLatestOrderCollectStatusAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var status = await client.GetLatestOrderCollectStatusAsync("182AC0ECDE0CA08A8B729733EBE8197D", source.Token);
            Assert.IsNotNull(status.Url);
        }

        /// <summary>
        /// Validates cancel order collect request method.
        /// </summary>
        [TestMethod]
        public void CancelOrderCollectRequest()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var status = client.GetLatestOrderCollectStatus("182AC0ECDE0CA08A8B729733EBE8197D");
            var canceled = client.CancelOrderCollectRequest(status.Id);
            Assert.IsTrue(canceled);
        }

        /// <summary>
        /// Validates cancel order collect request asynchronous method.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CancelOrderCollectRequestAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var status = await client.GetLatestOrderCollectStatusAsync("182AC0ECDE0CA08A8B729733EBE8197D", source.Token);
            var canceled = await client.CancelOrderCollectRequestAsync(status.Id, source.Token);
            Assert.IsTrue(canceled);
        }


        /// <summary>
        /// Validates cancels the order item collect request method.
        /// </summary>
        [TestMethod]
        public void CancelOrderItemCollectRequest()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var status = client.GetLatestOrderCollectStatus("182AC0ECDE0CA08A8B729733EBE8197D");
            var canceled = client.CancelOrderItemCollectRequest(status.Id, 123456);
            Assert.IsTrue(canceled);
        }

        /// <summary>
        /// Validates cancel order item collect request asynchronous method.
        /// </summary>
        [TestMethod]
        public async Task CancelOrderItemCollectRequestAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var status = await client.GetLatestOrderCollectStatusAsync("182AC0ECDE0CA08A8B729733EBE8197D", source.Token);
            var canceled = await client.CancelOrderItemCollectRequestAsync(status.Id, 123456, source.Token);
            Assert.IsTrue(canceled);
        }
    }
}
