// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 26/12/2022
// ***********************************************************************
// <copyright file="RatesTest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace GuiStracini.Mandae.Test.V2
{
    using GuiStracini.Mandae.Models;
    using GuiStracini.Mandae.ValueObject;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System;
    using System.Threading;
    using System.Threading.Tasks;

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
                DeclaredValue = new decimal(215.15),
                Dimensions = new Dimensions
                {
                    Height = 60,
                    Length = 60,
                    Width = 40,
                    Weight = 1
                }
            };

            var rates = client.GetRates(ratesModel);
            Assert.IsNull(rates.Error);
            Assert.IsFalse(string.IsNullOrWhiteSpace(rates.PostalCode));
            //Assert.IsTrue(rates.ShippingServices.Any());
        }

        /// <summary>
        /// Validate the get rates asynchronous method.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        [TestMethod]
        public async Task GetRatesAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");

            var ratesModel = new RatesModel
            {
                PostalCode = "22041080",
                DeclaredValue = new decimal(215.15),
                Dimensions = new Dimensions
                {
                    Height = 60,
                    Length = 60,
                    Width = 40,
                    Weight = 1
                }
            };

            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var rates = await client.GetRatesAsync(ratesModel, source.Token);

            Assert.IsFalse(string.IsNullOrWhiteSpace(rates.PostalCode));
            //Assert.IsTrue(rates.ShippingServices.Any());
        }
    }
}
