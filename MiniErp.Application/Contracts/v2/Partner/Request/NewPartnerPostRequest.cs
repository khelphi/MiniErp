using MiniErp.Application.Data.MySql.StaticTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Contracts.v2.Partners.Request
{
    
    /// <summary> 
    /// Payload de dados do parceiro
    /// </summary>
    public class NewPartnerPostRequest
    {
        public NewPartnerPostRequest()
        {

        }

        public string Name { get; set;}
        public string Document { get; set; }
        public int Situation { get; set; }
        public PartnerStatusType Status { get; set; }
    }


}
