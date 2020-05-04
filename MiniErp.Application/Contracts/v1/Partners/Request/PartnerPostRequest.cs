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
        //[Required()]
        public string  Name { get; set;}
        //[Required()]
        public string Document { get; set; }
        //[Required()]
        public int Situation { get; set; }
        //[Required()]
        public PartnerStatusType Status { get; set; }
        //[Required()]
        public string PartnerCode { get; set; }

    }


}
