using MiniErp.Application.Data.MySql.StaticTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Contracts.v1.Partners.Request
{
    public class PartnerPutRequest
    {

        public Guid PartnerId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public int Situation { get; set; }
        public PartnerStatusType Status { get; set; }
        public string PartnerCode { get; set; }
    }
}
