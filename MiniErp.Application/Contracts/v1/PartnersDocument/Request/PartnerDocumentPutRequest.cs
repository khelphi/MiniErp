using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Contracts.v1.PartnersDocument.Request
{
    public class PartnerDocumentPutRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
