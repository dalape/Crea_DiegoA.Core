using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crea_DiegoA.Core.Reposity.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crea_DiegoA.Core.DTOs;
using Crea_DiegoA.CoreTests;

namespace Crea_DiegoA.Core.Reposity.Workers.Tests
{
    [TestClass()]
    public class CustomerWorkerTests : TestBase
    {
        [TestMethod()]
        public void Create()
        {
            // Arrange
            ICustomerWorker customerWorker = new CustomerWorker();
            string document = GenerateRandomNumber().ToString();
            CustomerDto customerDto = new CustomerDto()
            {
                Document = document,
                Email = "uncorreo@correo.com",
                FirtsName = "Peter",
                LastName = "Parker",
                Phone = "10101010"
            };

            // ACT
            customerWorker.Create(customerDto);

            // Assert
            var custumer = customerWorker.Search(document);
            Assert.AreEqual(custumer.FirtsName, customerDto.FirtsName, "No se inserto correctamente");
        }

        [TestMethod()]
        public void Update()
        {
            // Arrange
            ICustomerWorker customerWorker = new CustomerWorker();
            string document = GenerateRandomNumber().ToString();
            CustomerDto customerDto = new CustomerDto()
            {
                Document = document,
                Email = "otrocorreo@correo.com",
                FirtsName = "Luisa",
                LastName = "Lane",
                Phone = "222222222"
            };

            // ACT
            customerWorker.Create(customerDto);
            customerDto.Phone = "3333333";
            customerWorker.Update(customerDto);

            // Assert
            var custumer = customerWorker.Search(document);
            Assert.AreEqual(custumer.Phone, customerDto.Phone, "No se actualizo correctamente");
        }

        [TestMethod()]
        public void ChangeState()
        {
            // Arrange
            ICustomerWorker customerWorker = new CustomerWorker();
            string document = GenerateRandomNumber().ToString();
            CustomerDto customerDto = new CustomerDto()
            {
                Document = document,
                Email = "nuevocorreo@correo.com",
                FirtsName = "Laura",
                LastName = "Lopez",
                Phone = "1239303"
            };

            // ACT
            customerWorker.Create(customerDto);
            customerWorker.ChangeState(customerDto.Document, false);

            // Assert
            var custumer = customerWorker.Search(document);
            Assert.AreEqual(custumer.Enable, customerDto.Enable, "No se cambio el estado correctamente");
        }

        [TestMethod()]
        public void Search()
        {
            // Arrange
            ICustomerWorker customerWorker = new CustomerWorker();
            string document = GenerateRandomNumber().ToString();
            CustomerDto customerDto = new CustomerDto()
            {
                Document = document,
                Email = "correocorreo@correo.com",
                FirtsName = "Carl",
                LastName = "Sagan",
                Phone = "7889"
            };

            // ACT
            customerWorker.Create(customerDto);
            var custumer = customerWorker.Search(document);

            // Assert
            Assert.AreEqual(custumer.FirtsName, customerDto.FirtsName, "No se encontró el cliente");
        }
    }
}