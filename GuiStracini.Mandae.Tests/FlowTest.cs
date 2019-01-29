﻿namespace GuiStracini.Mandae.Test
{
    using Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using System;
    using System.Linq;
    using ValueObject;

    /// <summary>
    /// Flow test validation class performs a full flow validations. 
    /// Validates the vehicle, the rates, the avaiable hours, register a order collect request and check the lastest order status
    /// </summary>
    [TestClass]
    public class FlowTest
    {
        /// <summary>
        /// Full flow validation.
        /// </summary>
        [TestMethod]
        public void FullFlowValidation()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            const String customerId = "182AC0ECDE0CA08A8B729733EBE8197D";
            var rnd = new Random();
            var ratesModel = new RatesModel
            {
                PostalCode = "22041080",
                DeclaredValue = new Decimal(215.15),
                Dimensions = new Dimensions
                {
                    Height = 60,
                    Length = 60,
                    Width = 40,
                    Weight = 1.3
                }
            };
            var rates = client.GetRates(ratesModel);
            Assert.IsNull(rates.Error);
            Assert.IsFalse(String.IsNullOrWhiteSpace(rates.PostalCode));
            Assert.AreEqual(2, rates.ShippingServices.Length);
            var cheapAndFastDelivery = rates.ShippingServices.OrderBy(r => r.Price).ThenBy(r => r.Days).First();
            var orderModel = new OrderModel
            {
                CustomerId = customerId,
                Vehicle = Vehicle.CAR,
                Observation = "Full flow validation test",
                Scheduling = DateTime.Now,
                PartnerOrderId = "1234567890",
                Sender = new Sender
                {
                    Address = new Address
                    {
                        Number = "527",
                        PostalCode = "03137020",
                        Neighborhood = "Vila Prudente",
                        City = "São Paulo",
                        State = "SP",
                        Street = "Rua Itanháem",
                        Country = "BR"
                    },
                    FullName = "Editora Inovação"
                },
                Items = new[]
                {
                    new Item
                    {
                        Id= rnd.Next(10000,99999),
                        Dimensions = ratesModel.Dimensions,
                        Observation = "Teste",
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
                            FullName = "Vitrine do Artesanato",
                            Email = "",
                            Phone = "+551133822031",
                            Document = "05944298000101"
                        },
                        PartnerItemId = "12345",
                        ShippingService = cheapAndFastDelivery.Name == "Rápido"
                                              ? ShippingService.RAPIDO
                                              : ShippingService.ECONOMICO,
                        Invoice = new Invoice
                        {
                            Id = "606620",
                            Key = "35170805944298000101550010006066201623434877"
                        },
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
                }

            };
            var order = client.CreateOrderCollectRequest(orderModel);
            Assert.IsNull(order.Error);
            Assert.IsTrue(order.Id > 0);
            Assert.IsTrue(order.Items.First().Id > 0);
            var status = client.GetLatestOrderCollectStatus(customerId);
            Assert.IsNull(status.Error);
            Assert.IsNotNull(status.Url);
        }
    }
}
