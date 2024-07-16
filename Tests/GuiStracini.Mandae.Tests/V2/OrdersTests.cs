// ﻿// ***********************************************************************
// // Assembly         : GuiStracini.Mandae
// // Author           : Guilherme Branco Stracini
// // Created          : 28/09/2017
// //
// // Last Modified By : Guilherme Branco Stracini
// // Last Modified On : 14/10/2023
// // ***********************************************************************
// // <copyright file="OrdersTest.cs" company="Guilherme Branco Stracini ME">
// //     Copyright © 2017-2023 Guilherme Branco Stracini
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

// using Xunit;

// namespace GuiStracini.Mandae.Tests.V2;

// using System.Threading;
// using System.Threading.Tasks;

// /// <summary>
// /// The orders test class
// /// </summary>
// public class OrdersTests
// {
//     /// <summary>
//     /// Validates register order collect request method.
//     /// </summary>
//     [SkippableFact]
//     public void RegisterOrderCollectRequest()
//     {
//         var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
//         var orderModel = MockOrdersRepository.GetSampleOrderModel();
//         var order = client.CreateOrderCollectRequest(orderModel);
//         Assert.Null(order.Error);
//         Assert.True(order.Id > 0);
//         Assert.True(order.Items[0].Id > 0);
//     }

//     /// <summary>
//     /// Validates register order collect request asynchronous method.
//     /// </summary>
//     /// <returns>A Task representing the asynchronous operation.</returns>
//     [SkippableFact]
//     public async Task RegisterOrderCollectRequestAsync()
//     {
//         var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");
//         var orderModel = MockOrdersRepository.GetSampleOrderModel();
//         var order = await client.CreateOrderCollectRequestAsync(orderModel, CancellationToken.None);
//         Assert.Null(order.Error);
//         Assert.True(order.Id > 0);
//         Assert.True(order.Items[0].Id > 0);
//     }
// }
