using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Contracts.v1.PartnersContact.Request
{
    public class PartnerContactPostRequest
    {
        public Guid PartnerId { get; set; }
        public string ContactName { get; set; }
        public string Description { get; set; }
        public string ContactType { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Information { get; set; }

    }
}
