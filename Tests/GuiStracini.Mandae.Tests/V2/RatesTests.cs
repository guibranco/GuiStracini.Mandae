// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 14/10/2023
// ***********************************************************************
// <copyright file="RatesTest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using Xunit;

namespace GuiStracini.Mandae.Tests.V2;

using Models;
using ValueObject;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The rates test class
/// </summary>
public class RatesTests
{
    /// <summary>
    /// Validates the get rates method.
    /// </summary>
    [Fact]
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
        Assert.Null(rates.Error);
        Assert.False(string.IsNullOrWhiteSpace(rates.PostalCode));
        //Assert.True(rates.ShippingServices.Any());
    }

    /// <summary>
    /// Validate the get rates asynchronous method.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    [Fact]
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

        Assert.False(string.IsNullOrWhiteSpace(rates.PostalCode));
        //Assert.True(rates.ShippingServices.Any());
    }
}
