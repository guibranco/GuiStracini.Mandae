// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="SchedulingTest.cs" company="Guilherme Branco Stracini">
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
    /// The scheduling test class
    /// </summary>
    [TestClass]
    public class SchedulingTest
    {
        /// <summary>
        /// Validates the get available hours method
        /// </summary>
        [TestMethod]
        public void GetAvailableHours()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var date = DateTime.Now.AddDays(1);
            var availableHours = client.GetAvailableHours(date);
            Assert.IsNull(availableHours.Error);
            Assert.IsTrue(availableHours.Hours.Any());

        }

        /// <summary>
        /// Validates the get avaialble hours asynchronous method.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetAvailableHoursAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
            var date = DateTime.Now.AddDays(1);
            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var availableHours = await client.GetAvailableHoursAsync(date, source.Token);
            Assert.IsNull(availableHours.Error);
            Assert.IsTrue(availableHours.Hours.Any());
        }
    }
}
