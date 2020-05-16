using MiniErp.Application.Data.MySql.StaticTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiniErp.Application.Contracts.v1.Partners.Request
{
    
    /// <summary> 
    /// Payload de dados do parceiro
    /// </summary>
    public class PartnerPostRequest
    {

        public string  Name { get; set;}
        public string Document { get; set; }
        public int Situation { get; set; }
        public PartnerStatusType Status { get; set; }
        public string PartnerCode { get; set; }

    }


}
