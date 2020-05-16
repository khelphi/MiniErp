using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Contracts.v1.Products
{
    public class ProductPostTequest
    {
        public Guid Id { get; set; }
        public string Dsscription { get; set; }
        public string ProductTypeId { get; set; }
        public string ProductFamilyId { get; set; }
        public decimal Value { get; set; }
    }
}
