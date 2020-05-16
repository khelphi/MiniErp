using MiniErp.Application.Data.MySql.Entities;
using MiniErp.Application.Data.MySql.StaticTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Data.MySql.Views
{
    public class PartnerFilteredView
    {
        public PartnerFilteredView()
        {
            this.Contacts = new List<PartnerContactEntity>();
        }

        /// <summary>
        /// Id do Parceiro
        /// </summary>
        public Guid PartnerId { get; set; }
        /// <summary>
        /// Nome do Parceiro
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Numero do Documento do Parceiro
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        /// Situation do Parceiro
        /// </summary>
        public int Situation { get; set; }

        /// <summary>
        /// Status do Parceiro
        /// </summary>
        public PartnerStatusType Status { get; set; }

        /// <summary>
        /// Codigo do Parceiro
        /// </summary>
        public string PartnerCode { get; set; }

        /// <summary>
        /// Contatos do Parceiro
        /// </summary>
        public List<PartnerContactEntity> Contacts { get; set; }

}

    
}
