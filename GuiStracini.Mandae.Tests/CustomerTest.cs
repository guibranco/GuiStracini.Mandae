// ***********************************************************************
// Assembly         : GuiStracini.Mandae
// Author           : Guilherme Branco Stracini
// Created          : 28/09/2017
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/09/2017
// ***********************************************************************
// <copyright file="CustomerTest.cs" company="Guilherme Branco Stracini">
//     Copyright © 2017 Guilherme Branco Stracini
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GuiStracini.Mandae.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ValueObject;

    /// <summary>
    /// The customer test class
    /// </summary>
    [TestClass]
    public class CustomerTest
    {
        /// <summary>
        /// Validates the register customer.
        /// </summary>
        [TestMethod]
        public void RegisterCustomer()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");

            var customerModel = new CustomerModel
            {
                Document = "92463006000113",
                Email = "guilherme@example.com",
                FullName = "Guilherme Branco Stracini",
                Phone = new Phone
                {
                    AreaCode = "11",
                    Number = "33822030"
                },
                Store = new Store
                {
                    Name = "Sample store",
                    Url = "https://www.example.com.br"
                }
            };
            var customer = client.RegisterCustomer(customerModel);
            Assert.IsNull(customer.Error);
            Assert.IsNotNull(customer.Id);
        }


        /// <summary>
        /// Validates the register customer asynchronous.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task RegisterCustomerAsync()
        {
            var client = new MandaeClient("0b5e2c6410cf0ac087ae7ace111dbd42");

            var customerModel = new CustomerModel
            {
                Document = "92463006000113",
                Email = "guilherme@example.com",
                FullName = "Guilherme Branco Stracini",
                Phone = new Phone
                {
                    AreaCode = "11",
                    Number = "33822030"
                },
                Store = new Store
                {
                    Name = "Sample store",
                    Url = "https://www.example.com.br"
                }
            };

            var source = new CancellationTokenSource(new TimeSpan(0, 5, 0));
            var customer = await client.RegisterCustomerAsync(customerModel, source.Token);
            Assert.IsNull(customer.Error);
            Assert.IsNotNull(customer.Id);
        }
    }
}
