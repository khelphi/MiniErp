using System;

namespace MiniErp.Application.Contracts.v1.ProductFamilies.Response
{
    public class ProductFamilyDefaultResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
    }
}
