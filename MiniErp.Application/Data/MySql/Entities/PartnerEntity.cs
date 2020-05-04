using MiniErp.Application.Contracts.v1.Partners.Request;
using MiniErp.Application.Contracts.v2.Partners.Request;
using MiniErp.Application.Data.MySql.StaticTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniErp.Application.Data.MySql.Entities
{
    /// <summary>
    ///  Entidade que representa a tabela partner
    /// </summary>
    [Table("partner")]
    public class PartnerEntity 
    {

        public PartnerEntity()
        {

        }


        public PartnerEntity(Guid partnerId, string name, string document, int situation, PartnerStatusType status, string partnerCode)
        {
            this.PartnerId = partnerId;
            this.Name = name;
            this.Document = document;
            this.Situation = situation;
            this.Status = status;
            this.PartnerCode = partnerCode;
        }


        public PartnerEntity(Guid partnerId, string name, string document, int situation, PartnerStatusType status)
        {
            this.PartnerId = partnerId;
            this.Name = name;
            this.Document = document;
            this.Situation = situation;
            this.Status = status;
        }


        /// <summary>
        /// Construtor da Entidade PartnerEntity que receberá o contrato.
        /// </summary>
        public PartnerEntity(PartnerPostRequest obj)
        {
            this.PartnerId = Guid.NewGuid();
            this.Name = obj.Name;
            this.Document = obj.Document;
            this.Situation = obj.Situation;
            this.Status = obj.Status;
            this.PartnerCode = obj.PartnerCode;
        }

        /// <summary>
        /// Construtor da Entidade PartnerEntity que receberá o contrato.
        /// </summary>
        public PartnerEntity(PartnerPutRequest obj)
        {
            this.PartnerId = obj.PartnerId;
            this.Name = obj.Name;
            this.Document = obj.Document;
            this.Situation = obj.Situation;
            this.Status = obj.Status;
            this.PartnerCode = obj.PartnerCode;
        }

        /// <summary>
        /// Construtor da Entidade PartnerEntity que receberá o contrato.
        /// </summary>
        public PartnerEntity(NewPartnerPostRequest obj)
        {
            this.PartnerId = Guid.NewGuid();
            this.Name = obj.Name;
            this.Document = obj.Document;
            this.Situation = obj.Situation;
            this.Status = obj.Status;
        }


        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
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

    }
}
