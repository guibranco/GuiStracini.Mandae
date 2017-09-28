using Microsoft.VisualStudio.TestTools.UnitTesting;
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
namespace GuiStracini.Mandae.Tests
{
    using Enums;
    using GoodPractices;
    using System;
    using Transport;
    using Utils;

    /// <summary>
    /// Performs tests in the <see cref="GuiStracini.Mandae.Utils.RequestHelpers"/> class method's
    /// </summary>
    [TestClass]
    public class RequestHelpersTests
    {
        /// <summary>
        /// Validates the request end point.
        /// </summary>
        public void ValidateRequestEndPoint()
        {
            const String expected = "tracking/SV123456789BR";
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
        public void ValidateRequestEndPointWithMultipleParameters()
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
        public void ValidateRequestEndPointWithNullValues()
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
        public void ValidateRequestEndPointWithMultipleParametersWithInvalidData()
        {
            var cancelItem = new CancelItemRequest
            {
                ItemId = 987654
            };
            cancelItem.GetRequestEndPoint();
        }

        [TestMethod]
        public void ValidateRequestAdditionalParameter()
        {
            const String expected = "/123456789";
            var order = new OrderRequest
            {
                OrderId = 123456789

            };
            var result = order.GetRequestAdditionalParameter(ActionMethod.DELETE);
            Assert.AreEqual(expected, result, "");
        }

        /// <summary>
        /// Validates the request additional parameter as query string.
        /// </summary>
        [TestMethod]
        public void ValidateRequestAdditionalParameterAsQueryString()
        {
            const String expected = "/?async=true";
            var order = new OrderRequest
            {
                Async = true
            };
            var result = order.GetRequestAdditionalParameter(ActionMethod.POST);
            Assert.AreEqual(expected, result, "The additional parameter should be query string");
        }

        /// <summary>
        /// Validates the request additional parameter incorrect action method.
        /// </summary>
        [TestMethod]
        public void ValidateRequestAdditionalParameterIncorrectActionMethod()
        {
            var order = new OrderRequest
            {
                Async = true,
                OrderId = 123456789
            };
            var result = order.GetRequestAdditionalParameter(ActionMethod.GET);
            Assert.AreEqual(String.Empty, result);
        }
    }
}
