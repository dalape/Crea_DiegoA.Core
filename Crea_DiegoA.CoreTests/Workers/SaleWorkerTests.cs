using Crea_DiegoA.Core.DTOs;
using Crea_DiegoA.Core.Reposity.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Crea_DiegoA.CoreTests.Workers
{
    [TestClass]
    public class SaleWorkerTests
    {
        [TestMethod()]
        public void Create()
        {
            // Arrange
            ISaleWorker SaleWorker = new SaleWorker();
            Guid salesId = Guid.NewGuid();
            SaleDto saleDto = new SaleDto()
            {
                CustomerID = 1,
                ProductID = 1,
                Quantity = 1,
                SaleDate = DateTime.Now,
                SalesGuid = salesId
            };

            // ACT
            SaleWorker.Create(saleDto);

            // Assert
            var sale = SaleWorker.Search(salesId);
            Assert.AreEqual(sale.SalesGuid, saleDto.SalesGuid, "No se inserto correctamente");
        }

        [TestMethod()]
        public void Update()
        {
            // Arrange
            ISaleWorker SaleWorker = new SaleWorker();
            Guid salesId = Guid.NewGuid();
            SaleDto saleDto = new SaleDto()
            {
                CustomerID = 1,
                ProductID = 2,
                Quantity = 3,
                SaleDate = DateTime.Now,
                SalesGuid = salesId
            };

            // ACT
            SaleWorker.Create(saleDto);
            saleDto.Quantity = 7;
            var salesById = SaleWorker.Search(salesId);
            saleDto.ID = salesById.ID;
            SaleWorker.Update(saleDto);

            // Assert
            var sale = SaleWorker.Search(salesId);
            Assert.AreEqual(sale.Quantity, saleDto.Quantity, "No se actualizo correctamente");
        }

        [TestMethod()]
        public void ChangeState()
        {
            // Arrange
            ISaleWorker SaleWorker = new SaleWorker();
            Guid salesId = Guid.NewGuid();
            SaleDto saleDto = new SaleDto()
            {
                CustomerID = 2,
                ProductID = 1,
                Quantity = 1,
                SaleDate = DateTime.Now,
                SalesGuid = salesId
            };

            // ACT
            SaleWorker.Create(saleDto);
            var salesById = SaleWorker.Search(salesId);
            saleDto.ID = salesById.ID;
            saleDto.State = Core.Enums.StateTypes.States.Accept.ToString();
            SaleWorker.ChangeState(saleDto.ID, Core.Enums.StateTypes.States.Accept);

            // Assert
            var sale = SaleWorker.Search(salesId);
            Assert.AreEqual(sale.State, saleDto.State, "No se cambio el estado correctamente");
        }

        [TestMethod()]
        public void Search()
        {
            // Arrange
            ISaleWorker SaleWorker = new SaleWorker();
            Guid salesId = Guid.NewGuid();
            SaleDto saleDto = new SaleDto()
            {
                CustomerID = 1,
                ProductID = 1,
                Quantity = 1,
                SaleDate = DateTime.Now,
                SalesGuid = salesId
            };

            // ACT
            SaleWorker.Create(saleDto);
            var sale = SaleWorker.Search(salesId);

            // Assert
            Assert.AreEqual(sale.SalesGuid, saleDto.SalesGuid, "No se encontró la venta");
        }
    }
}
