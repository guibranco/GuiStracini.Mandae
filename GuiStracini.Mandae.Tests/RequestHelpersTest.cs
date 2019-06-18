// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="RequestHelpersTests" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Test
{
    using Enums;
    using GoodPractices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Transport;
    using Transport.V1;
    using Utils;

    /// <summary>
    /// The request helpers test class
    /// </summary>
    [TestClass]
    public class RequestHelpersTest
    {
        /// <summary>
        /// Validates the request end point.
        /// </summary>
        [TestMethod]
        public void RequestEndPoint()
        {
            const String expected = "trackings/SV123456789BR";
            var tracking = new TrackingRequest
            {
                TrackingCode = "SV123456789BR"
            };
            var result = tracking.GetRequestEndPoint();
            Assert.AreEqual(expected, result, "The endpoint was not resolves as expected");
        }

        /// <summary>
        /// Validates the request end point with multiple parameters.
        /// </summary>
        [TestMethod]
        public void RequestEndPointWithMultipleParameters()
        {
            const String expected = "orders/123456/items/987654";
            var cancelItem = new CancelItemRequest
            {
                ItemId = 987654,
                OrderId = 123456
            };
            var result = cancelItem.GetRequestEndPoint();
            Assert.AreEqual(expected, result, "The endpoint was not resolves as expected");
        }

        /// <summary>
        /// Validates the request end point with null values.
        /// </summary>
        [TestMethod]
        public void RequestEndPointWithNullValues()
        {
            const String expected = "trackings";
            var tracking = new TrackingRequest();
            var result = tracking.GetRequestEndPoint();
            Assert.AreEqual(expected, result, "The endpoint was not resolves as expected");
        }

        /// <summary>
        /// Validates the request end point with multiple parameters with invalid data.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidRequestEndPointException), "The endpoint was resolved with incorrect format")]
        public void RequestEndPointWithMultipleParametersWithInvalidData()
        {
            var cancelItem = new CancelItemRequest
            {
                ItemId = 987654
            };
            cancelItem.GetRequestEndPoint();
        }

        /// <summary>
        /// Requests the parameter default value.
        /// </summary>
        [TestMethod]
        public void RequestParameterDefaultValue()
        {
            const String expected = "v1/encomendas/historico?offset=0&limit=10&rastreamento=XYZ00001";
            var request = new SearchRequest
            {
                Method = SearchMethod.TRACKING_CODE,
                Value = "XYZ00001"
            };
            var result = request.GetRequestEndPoint();
            Assert.AreEqual(expected, result);
        }
    }
}
