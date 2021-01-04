using Crea_DiegoA.Core.DTOs;
using Crea_DiegoA.Core.Exceptions;
using System;
using System.Linq;

namespace Crea_DiegoA.Core.Reposity
{
    public class ProductWorker : IProductWorker
    {
        /// <inheritdoc/>
        public bool Create(ProductDto productDto)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    Product product = new Product()
                    {
                        CreatedDate = DateTime.Now,
                        Description = productDto.Description,
                        Name = productDto.Name,
                        UnitPrice = productDto.UnitPrice
                    };
                    context.Product.Add(product);

                    return context.SaveChanges() == 1;
                }
            }
            catch (ProductWorkerException ex)
            {
                throw ex;
            }
        }

        public bool ChangeState(int id, bool enable)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    var Product = context.Product.FirstOrDefault(row => row.ID == id);
                    Product.Enable = enable;

                    return context.SaveChanges() == 1;
                }
            }
            catch (ProductWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public Product Search(int id)
        {
            try
            {
                return GetProduct(id);
            }
            catch (ProductWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public ProductDto Search(string name)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    var product = context.Product.FirstOrDefault(row => row.Name.Contains(name));
                    ProductDto productDto = new ProductDto()
                    {
                        Description = product.Description,
                        Enable = Convert.ToBoolean(product.Enable),
                        ID = product.ID,
                        Name = product.Name,
                        UnitPrice = product.UnitPrice
                    };

                    return productDto;
                }
            }
            catch (ProductWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public bool Update(ProductDto productDto)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    var Product = context.Product.FirstOrDefault(row => row.ID == productDto.ID);
                    Product.Description = productDto.Description;
                    Product.Name = productDto.Name;
                    Product.UnitPrice = productDto.UnitPrice;
                    Product.UpdatedDate = DateTime.Now;

                    return context.SaveChanges() == 1;
                }
            }
            catch (ProductWorkerException ex)
            {
                throw ex;
            }
        }

        private Product GetProduct(int id)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    return context.Product.FirstOrDefault(row => row.ID == id);
                }
            }
            catch (ProductWorkerException ex)
            {
                throw ex;
            }
        }
    }
}
