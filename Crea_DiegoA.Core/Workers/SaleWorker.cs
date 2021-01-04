using Crea_DiegoA.Core.DTOs;
using Crea_DiegoA.Core.Exceptions;
using System;
using System.Linq;
using static Crea_DiegoA.Core.Enums.StateTypes;

namespace Crea_DiegoA.Core.Reposity
{
    public class SaleWorker : ISaleWorker
    {
        public bool Create(SaleDto saleDto)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    Sale sale = new Sale()
                    {
                        SaleDate = DateTime.Now,
                        SaleGuid = saleDto.SalesGuid,
                        CustomerID = saleDto.CustomerID,
                        ProductID = saleDto.ProductID,
                        Quantity = saleDto.Quantity
                    };
                    context.Sale.Add(sale);

                    return context.SaveChanges() == 1;
                }
            }
            catch (SaleWorkerException ex)
            {
                throw ex;
            }
        }

        public bool ChangeState(int id, States state)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    var Sale = context.Sale.FirstOrDefault(row => row.ID == id);
                    Sale.State = state.ToString();

                    return context.SaveChanges() == 1;
                }
            }
            catch (SaleWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public Sale Search(int id)
        {
            try
            {
                return GetSale(id);
            }
            catch (SaleWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public Sale Search(DateTime date)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    return context.Sale.FirstOrDefault(row => row.SaleDate == date);
                }
            }
            catch (SaleWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public SaleDto Search(Guid salesId)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    var sale = context.Sale.FirstOrDefault(row => row.SaleGuid == salesId);
                    SaleDto saleDto = new SaleDto()
                    {
                        CustomerID = sale.CustomerID,
                        ID = sale.ID,
                        ProductID = sale.ProductID,
                        Quantity = sale.Quantity,
                        SaleDate = (DateTime)sale.SaleDate,
                        SalesGuid = (Guid)sale.SaleGuid,
                        State = sale.State
                    };

                    return saleDto;
                }
            }
            catch (SaleWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public bool Update(SaleDto saleDto)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    var Sale = context.Sale.FirstOrDefault(row => row.ID == saleDto.ID);
                    Sale.Quantity = saleDto.Quantity;                    

                    return context.SaveChanges() == 1;
                }
            }
            catch (SaleWorkerException ex)
            {
                throw ex;
            }
        }

        private Sale GetSale(int id)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    return context.Sale.FirstOrDefault(row => row.ID == id);
                }
            }
            catch (SaleWorkerException ex)
            {
                throw ex;
            }
        }
    }
}
