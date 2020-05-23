using System;

namespace MiniErp.Application.Contracts.v1.ProductTypes.Response
{
    public class ProductTypeDefaultResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
    }
}
