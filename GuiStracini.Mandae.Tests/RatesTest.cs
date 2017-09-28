// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="RatesTest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ValueObject;

    /// <summary>
    /// The rates test class
    /// </summary>
    [TestClass]
    public class RatesTest
    {
        /// <summary>
        /// Valiudates the get rates method.
        /// </summary>
        [TestMethod]
        public void GetRates()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");

            var ratesModel = new RatesModel
            {
                PostalCode = "22041080",
                DeclaredValue = new Decimal(215.15),
                Dimensions = new Dimensions
                {
                    Height = 60,
                    Length = 60,
                    Width = 40,
                    Weight = new Decimal(1.2)
                }
            };

            var rates = client.GetRates(ratesModel);

            Assert.IsFalse(String.IsNullOrWhiteSpace(rates.PostalCode));
            Assert.AreEqual(2, rates.ShippingServices.Length);
            var fast = rates.ShippingServices.SingleOrDefault(r => r.Id.Equals("Rápido", StringComparison.InvariantCultureIgnoreCase));
            var slow = rates.ShippingServices.SingleOrDefault(r => r.Id.Equals("Econômico", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsNotNull(fast);
            Assert.IsNotNull(slow);
            Assert.IsTrue(fast.Days < slow.Days);
        }

        /// <summary>
        /// Validate the get rates asynchronous method.
        /// </summary>
        /// <returns></returns>
        public async Task GetRatesAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");

            var ratesModel = new RatesModel
            {
                PostalCode = "22041080",
                DeclaredValue = new Decimal(215.15),
                Dimensions = new Dimensions
                {
                    Height = 60,
                    Length = 60,
                    Width = 40,
                    Weight = new Decimal(1.2)
                }
            };

            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var rates = await client.GetRatesAsync(ratesModel, source.Token);

            Assert.IsFalse(String.IsNullOrWhiteSpace(rates.PostalCode));
            Assert.AreEqual(2, rates.ShippingServices.Length);
            var fast = rates.ShippingServices.SingleOrDefault(r => r.Id.Equals("Rápido", StringComparison.InvariantCultureIgnoreCase));
            var slow = rates.ShippingServices.SingleOrDefault(r => r.Id.Equals("Econômico", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsNotNull(fast);
            Assert.IsNotNull(slow);
            Assert.IsTrue(fast.Days < slow.Days);
        }
    }
}
