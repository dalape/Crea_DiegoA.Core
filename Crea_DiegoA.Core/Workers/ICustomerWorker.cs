using Crea_DiegoA.Core.DTOs;

namespace Crea_DiegoA.Core.Reposity.Workers
{
    public interface ICustomerWorker
    {
        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="customerDto">Information about customer</param>
        /// <returns>True = created, False = couldn't create customer</returns>
        bool Create(CustomerDto customerDto);
        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="customerDto">Information about customer</param>
        /// <returns>True = update, False = couldn't update customer</returns>
        bool Update(CustomerDto customerDto);
        /// <summary>
        /// Change customer to state disable
        /// </summary>
        /// <param name="document"></param>
        /// <returns>True = disable, False = couldn't disable customer</returns>
        bool ChangeState(string document, bool enable);
        /// <summary>
        /// Search customer by document
        /// </summary>
        /// <param name="id">Identifier number</param>
        /// <returns>Information about customer</returns>
        CustomerDto Search(int id);
        /// <summary>
        /// Search customer by document
        /// </summary>
        /// <param name="document">Document number</param>
        /// <returns>Information about customer</returns>
        Customer Search(string document);
        /// <summary>
        /// Search customer by document
        /// </summary>
        /// <param name="document">Document number</param>
        /// <returns>Information about customer</returns>
        CustomerDto SearchByName(string name);
    }
}
