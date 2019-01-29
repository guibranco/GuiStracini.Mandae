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
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The orders test class
    /// </summary>
    [TestClass]
    public class OrdersTest
    {

        /// <summary>
        /// Validates register order collect request method.
        /// </summary>
        [TestMethod]
        public void RegisterOrderCollectRequest()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var orderModel = MockOrdersRepository.GetSampleOrderModel();
            var order = client.CreateOrderCollectRequest(orderModel);
            Assert.IsNull(order.Error);
            Assert.IsTrue(order.Id > 0);
            Assert.IsTrue(order.Items.First().Id > 0);
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
            var orderModel = MockOrdersRepository.GetSampleOrderModel();
            var order = await client.CreateOrderCollectRequestAsync(orderModel, source.Token);
            Assert.IsNull(order.Error);
            Assert.IsTrue(order.Id > 0);
            Assert.IsTrue(order.Items.First().Id > 0);
        }

        /// <summary>
        /// Validates register large order collect request method.
        /// </summary>
        [TestMethod]
        public void RegisterLargeOrderCollectRequest()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var orderModel = MockOrdersRepository.GetSampleOrderModel();
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
            var orderModel = MockOrdersRepository.GetSampleOrderModel();
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
            Assert.IsNull(status.Error);
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
            Assert.IsNull(status.Error);
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
            var orderModel = MockOrdersRepository.GetSampleOrderModel();
            var order = client.CreateOrderCollectRequest(orderModel);
            Assert.IsNull(order.Error);
            Assert.IsTrue(order.Id > 0);
            Assert.IsTrue(order.Items.First().Id > 0);
            client.CancelOrderItemCollectRequest(order.Id, order.Items.First().Id);
            //Commented beacuse the client token is not valid anymore, so this request becomes invalid in sandbox
            //Assert.IsTrue(canceled);
        }

        /// <summary>
        /// Validates cancel order item collect request asynchronous method.
        /// </summary>
        [TestMethod]
        public async Task CancelOrderItemCollectRequestAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var orderModel = MockOrdersRepository.GetSampleOrderModel();
            var order = await client.CreateOrderCollectRequestAsync(orderModel, source.Token);
            Assert.IsNull(order.Error);
            Assert.IsTrue(order.Id > 0);
            Assert.IsTrue(order.Items.First().Id > 0);
            await client.CancelOrderItemCollectRequestAsync(order.Id, order.Items.First().Id, source.Token);
            //Commented beacuse the client token is not valid anymore, so this request becomes invalid in sandbox
            //Assert.IsTrue(canceled);
        }
    }
}
