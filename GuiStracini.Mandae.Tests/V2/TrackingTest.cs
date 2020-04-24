// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="TrackingTest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuiStracini.Mandae.Test.V2
{
    /// <summary>
    /// The tracking test class
    /// </summary>
    [TestClass]
    public class TrackingTest
    {
        /// <summary>
        /// Validates the get tracking method.
        /// </summary>
        [TestMethod]
        public void GetTracking()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var orderModel = MockOrdersRepository.GetSampleOrderModel();
            var order = client.CreateOrderCollectRequest(orderModel);
            Assert.IsNull(order.Error);
            Assert.IsTrue(order.Id > 0);
            Assert.IsTrue(order.Items.First().Id > 0);
            var tracking = client.GetTracking(orderModel.Items.First().TrackingId);
            Assert.IsNull(tracking.Error);
            Assert.AreEqual(orderModel.Items.First().TrackingId, tracking.TrackingCode);
            Assert.AreEqual("Indefinido", tracking.CarrierName);
            Assert.IsNull(tracking.CarrierCode);
            Assert.IsTrue(tracking.Events.Any());
            var firstEvent = tracking.Events.Single();
            Assert.IsNull(firstEvent.Name);
            Assert.AreEqual("Nenhuma atualização disponível ainda.", firstEvent.Description);
        }

        /// <summary>
        /// Validates the get tracking asynchronous method.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetTrackingAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var orderModel = MockOrdersRepository.GetSampleOrderModel();
            var order = await client.CreateOrderCollectRequestAsync(orderModel, source.Token);
            Assert.IsNull(order.Error);
            Assert.IsTrue(order.Id > 0);
            Assert.IsTrue(order.Items.First().Id > 0);
            var tracking = await client.GetTrackingAsync(orderModel.Items.First().TrackingId, source.Token);
            Assert.IsNull(tracking.Error);
            Assert.AreEqual(orderModel.Items.First().TrackingId, tracking.TrackingCode);
            Assert.AreEqual("Indefinido", tracking.CarrierName);
            Assert.IsNull(tracking.CarrierCode);
            Assert.IsTrue(tracking.Events.Any());
            var firstEvent = tracking.Events.Single();
            Assert.IsNull(firstEvent.Name);
            Assert.AreEqual("Nenhuma atualização disponível ainda.", firstEvent.Description);
        }
    }
}
