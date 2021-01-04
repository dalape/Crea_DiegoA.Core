using System;

namespace Crea_DiegoA.Core.DTOs
{
    public class SaleDto
    {
        public int ID { get; set; }
        public Guid SalesGuid { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string State { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
