

using System;

namespace MiniErp.Application.Contracts.v1.ProductFamilies.Request
{
    public class ProductFamilyPutRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
