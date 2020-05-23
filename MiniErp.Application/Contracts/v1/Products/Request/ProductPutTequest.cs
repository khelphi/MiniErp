using System;

namespace MiniErp.Application.Contracts.v1.Products.Request
{
    public class ProductPutTequest
    {
        public Guid Id { get; set; }
        public string Dsscription { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductFamilyId { get; set; }
        public double Value { get; set; }
    }
}
