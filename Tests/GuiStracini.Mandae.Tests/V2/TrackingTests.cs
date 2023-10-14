// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 14/10/2023
// ***********************************************************************
// <copyright file="TrackingTest.cs" company="Guilherme Branco Stracini ME">
//     Copyright © 2017-2023 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************

using Xunit;

namespace GuiStracini.Mandae.Tests.V2;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Transport;

/// <summary>
/// The tracking test class
/// </summary>
public class TrackingTests
{
    /// <summary>
    /// Validates the get tracking method.
    /// </summary>
    [Fact]
    public void GetTracking()
    {
        var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
        var orderModel = MockOrdersRepository.GetSampleOrderModel();
        var order = client.CreateOrderCollectRequest(orderModel);
        var trackingId = AssertOrderResult(order);
        var tracking = client.GetTracking(trackingId);
        AssertTrackingResult(tracking, trackingId);
    }

    /// <summary>
    /// Validates the get tracking asynchronous method.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    [Fact]
    public async Task GetTrackingAsync()
    {
        var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
        var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
        var orderModel = MockOrdersRepository.GetSampleOrderModel();
        var order = await client.CreateOrderCollectRequestAsync(orderModel, source.Token);
        var trackingId = AssertOrderResult(order);
        var tracking = await client.GetTrackingAsync(trackingId, source.Token);
        AssertTrackingResult(tracking, trackingId);
    }

    /// <summary>
    /// Asserts the order result.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns>System.String.</returns>
    private static string AssertOrderResult(OrderResponse order)
    {
        Assert.Null(order.Error);
        Assert.True(order.Id > 0);
        Assert.True(order.Items.First().Id > 0);
        var item = order.Items.FirstOrDefault();
        if (item == null)
        {
            //Assert.Inconclusive("Invalid items returned");
            return string.Empty;
        }

        var trackingId = item.TrackingId;
        if (trackingId != null)
        {
            return trackingId;
        }

        //Assert.Inconclusive("Null tracking id");
        return string.Empty;
    }

    /// <summary>
    /// Asserts the tracking result.
    /// </summary>
    /// <param name="tracking">The tracking.</param>
    /// <param name="trackingId">The tracking identifier.</param>
    private static void AssertTrackingResult(TrackingResponse tracking, string trackingId)
    {
        Assert.Null(tracking.Error);
        Assert.Equal(trackingId, tracking.TrackingCode);
        Assert.Null(tracking.CarrierName);
        Assert.Null(tracking.CarrierCode);
        Assert.False(tracking.Events.Any());
    }
}
