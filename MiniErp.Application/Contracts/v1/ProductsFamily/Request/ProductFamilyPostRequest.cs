using System;

namespace MiniErp.Application.Contracts.v1.ProductFamily.Request
{
    public class ProductFamilyPostRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
