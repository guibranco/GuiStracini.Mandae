﻿// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="VehicleTest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Test
{
    using Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The vehicles test class
    /// </summary>
    [TestClass]
    public class VehiclesTest
    {

        /// <summary>
        /// Validates the get vehicles method.
        /// </summary>
        [TestMethod]
        public void GetVehicles()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");

            var vehicles = client.GetVehicles("03137020");

            Assert.IsTrue(vehicles.Count == 2);
            Assert.IsTrue(vehicles.Any(v => v == Vehicle.CAR));
            Assert.IsTrue(vehicles.Any(v => v == Vehicle.MOTORCYCLE));
        }

        /// <summary>
        /// Validates the get vehicles asynchronous method.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetVehiclesAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");

            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var vehicles = await client.GetVehiclesAsync("03137020", source.Token);

            Assert.IsTrue(vehicles.Count == 2);
            Assert.IsTrue(vehicles.Any(v => v == Vehicle.CAR));
            Assert.IsTrue(vehicles.Any(v => v == Vehicle.MOTORCYCLE));
        }
    }
}
