using System;


namespace MiniErp.Application.Contracts.v1.ProductTypes.Request
{
    /// <summary>
    ///     Payload de atualização de dados do tipo do produto
    /// </summary>
    public class ProductTypePutRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
