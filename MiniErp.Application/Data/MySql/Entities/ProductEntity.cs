using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Data.MySql.Entities
{
    class ProductEntity
    {
        public Guid Id { get; set; }
        public string Dsscription { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductFamilyId { get; set; }
        public decimal Value { get; set; }
    }
}
