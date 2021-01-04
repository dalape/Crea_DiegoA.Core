using Crea_DiegoA.Core.DTOs;

namespace Crea_DiegoA.Core.Reposity.Workers
{
    public interface IProductWorker
    {
        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="productDto">Information about product</param>
        /// <returns>True = created, False = couldn't create product</returns>
        bool Create(ProductDto productDto);
        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="productDto">Information about product</param>
        /// <returns>True = updated, False = couldn't update product</returns>
        bool Update(ProductDto productDto);
        /// <summary
        /// Change customer to state disable
        /// </summary>
        /// <param name="productID">Product identifier</param>
        /// <returns>Change product to state disable</returns>
        bool ChangeState(int id, bool enable);
        /// <summary>
        /// Search customer by name
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <returns>Information about product</returns>
        Product Search(int id);
        /// <summary>
        /// Search customer by name
        /// </summary>
        /// <param name="name">Product name</param>
        /// <returns>Information about product</returns>
        ProductDto Search(string name);
    }
}
