// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 26/03/2023
// ***********************************************************************
// <copyright file="TrackingTest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.Test.V2
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

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
            var item = orderModel.Items.FirstOrDefault();
            if(item == null)
            {
                Assert.Inconclusive("Invalid items returned");
                return;
            }
            var trackingId = item.TrackingId;
            if(trackingId == null)
            {
                Assert.Inconclusive("Null tracking id");
                return;
            }
            var tracking = client.GetTracking(trackingId);
            Assert.IsNotNull(tracking.Error);
            Assert.AreEqual("404", tracking.Error.Code);
            Assert.AreEqual("br.com.mandae.rastreamento.domain.model.Encomenda not found", tracking.Error.Message);
            Assert.IsNull(tracking.TrackingCode);
            Assert.IsNull(tracking.CarrierName);
            Assert.IsNull(tracking.CarrierCode);
            Assert.IsNull(tracking.Events);
            Assert.IsNull(tracking.Message);
        }

        /// <summary>
        /// Validates the get tracking asynchronous method.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
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
            var item = orderModel.Items.FirstOrDefault();
            if(item == null)
            {
                Assert.Inconclusive("Invalid items returned");
                return;
                
            }
            var trackingId = item.TrackingId;
            if(trackingId == null)
            {
                Assert.Inconclusive("Null tracking id");
                return;
            }
            var tracking = await client.GetTrackingAsync(trackingId, source.Token);
            Assert.IsNotNull(tracking.Error);
            Assert.AreEqual("404", tracking.Error.Code);
            Assert.AreEqual("br.com.mandae.rastreamento.domain.model.Encomenda not found", tracking.Error.Message);
            Assert.IsNull(tracking.TrackingCode);
            Assert.IsNull(tracking.CarrierName);
            Assert.IsNull(tracking.CarrierCode);
            Assert.IsNull(tracking.Events);
            Assert.IsNull(tracking.Message);
        }
    }
}
