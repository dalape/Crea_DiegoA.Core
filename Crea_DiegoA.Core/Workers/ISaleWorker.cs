using Crea_DiegoA.Core.DTOs;
using System;
using static Crea_DiegoA.Core.Enums.StateTypes;

namespace Crea_DiegoA.Core.Reposity.Workers
{
    public interface ISaleWorker
    {
        /// <summary>
        /// Create a new sale
        /// </summary>
        /// <param name="saleDto">Information about sale</param>
        /// <returns>True = created, False = couldn't create sale</returns>
        bool Create(SaleDto saleDto);
        /// <summary>
        /// Update a sale
        /// </summary>
        /// <param name="saleDto">Information about sale</param>
        /// <returns>True = updated, False = couldn't update sale</returns>
        bool Update(SaleDto saleDto);
        /// <summary
        /// Change customer to state disable
        /// </summary>
        /// <param name="SaleID">Sale identifier</param>
        /// <param name="state">State to change</param>
        /// <returns>Change sale state</returns>
        bool ChangeState(int id, States state);
        /// <summary>
        /// Search customer by name
        /// </summary>
        /// <param name="id">Sale identifier</param>
        /// <returns>Information about Sale</returns>
        Sale Search(int id);
        /// <summary>
        /// Search customer by name
        /// </summary>
        /// <param name="date">Sale date</param>
        /// <returns>Information about Sale</returns>
        Sale Search(DateTime date);
        /// <summary>
        /// Search customer by name
        /// </summary>
        /// <param name="customerID">Customer identifier</param>
        /// <returns>Information about Sale</returns>
        SaleDto Search(Guid salesId);
    }
}
