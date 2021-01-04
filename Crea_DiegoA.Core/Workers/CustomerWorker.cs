using Crea_DiegoA.Core.DTOs;
using Crea_DiegoA.Core.Exceptions;
using System;
using System.Linq;

namespace Crea_DiegoA.Core.Reposity.Workers
{
    public class CustomerWorker : ICustomerWorker
    {
        /// <inheritdoc/>
        public bool Create(CustomerDto customerDto)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    Customer customer = new Customer()
                    {
                        CreatedDate = DateTime.Now,
                        Document = customerDto.Document,
                        Email = customerDto.Email,
                        FirtsName = customerDto.FirtsName,
                        LastName = customerDto.LastName,
                        Phone = customerDto.Phone
                    };
                    context.Customer.Add(customer);

                    return context.SaveChanges() == 1;
                }
            }
            catch (CustomerWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public bool ChangeState(string document, bool enable)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    var customer = context.Customer.FirstOrDefault(row => row.Document == document);
                    customer.Enable = enable;

                    return context.SaveChanges() == 1;
                }
            }
            catch (CustomerWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public Customer Search(string document)
        {
            try
            {
                return GetCustomer(document);
            }
            catch (CustomerWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public CustomerDto SearchByName(string name)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    var customer = context.Customer.FirstOrDefault(row => row.FirtsName.Contains(name) || row.LastName.Contains(name));
                    CustomerDto customerDto = new CustomerDto()
                    {
                        Document = customer.Document,
                        Email = customer.Email,
                        Enable = (bool)customer.Enable,
                        FirtsName = customer.FirtsName,
                        ID = customer.ID,
                        LastName = customer.LastName
                    };

                    return customerDto;
                }
            }
            catch (CustomerWorkerException ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc/>
        public bool Update(CustomerDto customerDto)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    var customer = context.Customer.FirstOrDefault(row => row.Document == customerDto.Document);
                    customer.Email = customerDto.Email;
                    customer.FirtsName = customerDto.FirtsName;
                    customer.LastName = customerDto.LastName;
                    customer.Phone = customerDto.Phone;
                    customer.UpdatedDate = DateTime.Now;

                    return context.SaveChanges() == 1;
                }
            }
            catch (CustomerWorkerException ex)
            {
                throw ex;
            }
        }

        private Customer GetCustomer(string document)
        {
            try
            {
                using (var context = new Connection_Crea_Test_DA())
                {
                    return context.Customer.FirstOrDefault(row => row.Document == document);
                }
            }
            catch (CustomerWorkerException ex)
            {
                throw ex;
            }
        }
    }
}
