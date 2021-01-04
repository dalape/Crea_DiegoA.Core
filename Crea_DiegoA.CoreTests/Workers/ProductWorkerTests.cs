using Crea_DiegoA.Core.DTOs;
using Crea_DiegoA.Core.Reposity.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crea_DiegoA.CoreTests.Workers
{
    [TestClass]
    public class ProductWorkerTests : TestBase
    {
        [TestMethod()]
        public void Create()
        {
            // Arrange
            IProductWorker ProductWorker = new ProductWorker();
            string name = GenerateRandomName("Mac Pro");
            ProductDto productDto = new ProductDto()
            {
                Description = "Un producto",
                Name = name,
                UnitPrice = 5000000
            };

            // ACT
            ProductWorker.Create(productDto);

            // Assert
            var product = ProductWorker.Search(name);
            Assert.AreEqual(product.Name, productDto.Name, "No se inserto correctamente");
        }

        [TestMethod()]
        public void Update()
        {
            // Arrange
            IProductWorker ProductWorker = new ProductWorker();
            string name = GenerateRandomName("Disco duro");
            ProductDto productDto = new ProductDto()
            {
                Description = "Otro producto",
                Name = name,
                UnitPrice = 150000
            };

            // ACT
            ProductWorker.Create(productDto);
            productDto.UnitPrice = 170000;
            var productById = ProductWorker.Search(name);
            productDto.ID = productById.ID;
            ProductWorker.Update(productDto);

            // Assert
            var product = ProductWorker.Search(name);
            Assert.AreEqual(product.UnitPrice, productDto.UnitPrice, "No se actualizo correctamente");
        }

        [TestMethod()]
        public void ChangeState()
        {
            // Arrange
            IProductWorker ProductWorker = new ProductWorker();
            string name = GenerateRandomName("Teclado gamer");
            ProductDto productDto = new ProductDto()
            {
                Description = "Nuevo producto",
                Name = name,
                UnitPrice = 230000
            };

            // ACT
            ProductWorker.Create(productDto);
            var productById = ProductWorker.Search(name);
            productDto.ID = productById.ID;
            ProductWorker.ChangeState(productDto.ID, false);

            // Assert
            var product = ProductWorker.Search(name);
            Assert.AreEqual(product.Enable, productDto.Enable, "No se cambio el estado correctamente");
        }

        [TestMethod()]
        public void Search()
        {
            // Arrange
            IProductWorker ProductWorker = new ProductWorker();
            string name = GenerateRandomName("Soporte de portátil");
            ProductDto ProductDto = new ProductDto()
            {
                Description = "Producto viejo",
                Name = name,
                UnitPrice = 40000
            };

            // ACT
            ProductWorker.Create(ProductDto);
            var product = ProductWorker.Search(name);

            // Assert
            Assert.AreEqual(product.Name, ProductDto.Name, "No se encontró el producto");
        }
    }
}
