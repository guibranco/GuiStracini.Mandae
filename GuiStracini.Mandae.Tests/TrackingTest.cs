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
namespace GuiStracini.Mandae.Test
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
            var status = client.GetLatestOrderCollectStatus("182AC0ECDE0CA08A8B729733EBE8197D");
            Assert.IsNull(status.Error);
            Assert.IsNotNull(status.Url);
            var tracking = client.GetTracking("12345979");
            Assert.IsNull(tracking.Error);
            Assert.IsNotNull(tracking.CarrierName);
            Assert.IsNotNull(tracking.CarrierCode);
            Assert.IsTrue(tracking.Events.Any());
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
            var status = await client.GetLatestOrderCollectStatusAsync("182AC0ECDE0CA08A8B729733EBE8197D", source.Token);
            var tracking = await client.GetTrackingAsync("123456789", source.Token);
            Assert.IsNull(tracking.Error);
            Assert.IsNotNull(tracking.CarrierName);
            Assert.IsNotNull(tracking.CarrierCode);
            Assert.IsTrue(tracking.Events.Any());
        }
    }
}
