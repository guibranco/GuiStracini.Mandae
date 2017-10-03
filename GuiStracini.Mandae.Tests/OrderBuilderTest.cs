// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 03/10/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 03/10/2017
// ***********************************************************************
// <copyright file="OrderBuilderTest" company="Guilherme Branco Stracini">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ValueObject;

    /// <summary>
    /// The order builder test class
    /// </summary>

    [TestClass]
    public class OrderBuilderTest
    {
        /// <summary>
        /// order builder validation
        /// </summary>
        [TestMethod]
        public async void OrderBuilderValidation()
        {
            var random = new Random();
            var ordersRepository = new MockOrdersRepository();
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var builder = new OrderBuilder(client);
            builder.SetCustomerId("182AC0ECDE0CA08A8B729733EBE8197D");
            builder.SetObservation("GuiStracini.Mandae.Test.OrderBuilderTest.OrderBuilderValidation - Sandbox");
            var source = new CancellationTokenSource(new TimeSpan(0, 10, 0));

            var vehiclesTask = client
                .GetVehiclesAsync("03137020", source.Token)
                .ContinueWith(vehicles =>
                              {
                                  Console.WriteLine("Setting vehicle");
                                  builder.SetVehicle(vehicles.Result.Any(v => v == Vehicle.CAR) ? Vehicle.CAR : vehicles.Result.First());
                              },
                              source.Token);
            var availableHoursTask = client
                .GetAvailableHoursAsync(DateTime.Today, source.Token)
                .ContinueWith(availableHours =>
                              {
                                  Console.WriteLine("Setting collect date");
                                  builder.SetCollectDate(availableHours.Result.Hours.Last());
                              },
                              source.Token);
            var tasksSkus = new List<Task>();
            var ordersIdsTask = ordersRepository
                .GetOrdersIdsPendingShippingAsync()
                .ContinueWith(ordersIds =>
                              {
                                  foreach (var orderId in ordersIds.Result)
                                  {
                                      Console.WriteLine("Getting order {0}", orderId);
                                      var order = ordersRepository.GetOrder(orderId);
                                      var ratesModel = new RatesModel
                                      {
                                          DeclaredValue = order.Value,
                                          Dimensions = new Dimensions
                                          {
                                              Length = order.Length,
                                              Width = order.Width,
                                              Weight = order.Weight,
                                              Height = order.Height
                                          },
                                          PostalCode = order.ZipCode
                                      };
                                      var shippingRates = client.GetRates(ratesModel);
                                      var shippingService = shippingRates.ShippingServices.OrderBy(s => s.Price).ThenBy(s => s.Days).First();
                                      if (random.Next() % 2 == 0)
                                          shippingService = shippingRates.ShippingServices.OrderBy(s => s.Days).First();
                                      var model = new Item
                                      {
                                          Dimensions = ratesModel.Dimensions,
                                          PartnerItemId = order.OrderId.ToString(),
                                          Recipient = new Recipient
                                          {
                                              Address = new Address
                                              {
                                                  PostalCode = order.ZipCode,
                                                  Street = order.Street,
                                                  Number = order.Number,
                                                  Reference = order.Complement,
                                                  Neighborhood = order.Neighborhood,
                                                  City = order.City,
                                                  State = order.StateInitials,
                                                  Country = "BR"
                                              },
                                              FullName = order.FullName,
                                              Document = order.Document,
                                              Email = order.Email,
                                              Phone = order.Telephone
                                          },
                                          ShippingService = shippingService.Service,
                                          Invoice = new Invoice
                                          {
                                              Id = order.InvoiceNumber,
                                              Key = order.InvoiceKey
                                          }
                                      };
                                      var id = builder.AddItem(model);
                                      Parallel.ForEach(ordersRepository.GetOrderItems(orderId),
                                                       sku =>
                                                       {
                                                           tasksSkus.Add(Task.Factory.StartNew(() =>
                                                           {
                                                               builder.AddSku(new Sku
                                                               {
                                                                   SkuId = sku.SkuId.ToString(),
                                                                   Description = sku.Name,
                                                                   Ean = sku.Ean,
                                                                   Quantity = sku.Quantity,
                                                                   Freight = sku.PriceFreight,
                                                                   Price = sku.Price

                                                               }, id);
                                                           }, source.Token));
                                                       });
                                  }
                              },
                             source.Token);


            await Task.WhenAll(vehiclesTask, availableHoursTask, ordersIdsTask); //await the main tasks
            await Task.WhenAll(tasksSkus.ToArray()); //await the sku tasks

            var response = builder.Build(); //builds the order and get the response

            Assert.IsNull(response.Error);
            Assert.IsTrue(response.Id > 0);
        }
    }
}
