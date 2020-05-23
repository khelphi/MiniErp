

using MiniErp.Application.Contracts.v1.PartnersContact.Request;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniErp.Application.Data.MySql.Entities
{
    [Table("partnersContact")]
    public class PartnerContactEntity
    {
        public PartnerContactEntity()
        {

        }
        public PartnerContactEntity(PartnerContactPostRequest request)
        {
            this.Id = Guid.NewGuid();
            this.PartnerId = request.PartnerId;
            this.ContactName = request. ContactName;
            this.Description = request.Description;
            this.ContactType = request.ContactType;
            this.PhoneNumber1 = request.PhoneNumber1;
            this.PhoneNumber2 = request.PhoneNumber2;
            this.Information = request.Information;
        }

        public PartnerContactEntity(PartnerContactPutRequest request)
        {
            this.Id = request.Id;
            this.PartnerId = request.PartnerId;
            this.ContactName = request.ContactName;
            this.Description = request.Description;
            this.ContactType = request.ContactType;
            this.PhoneNumber1 = request.PhoneNumber1;
            this.PhoneNumber2 = request.PhoneNumber2;
            this.Information = request.Information;
        }

        public PartnerContactEntity(Guid id, Guid partnerId, string contactName, string description, string contactType, string phoneNumber1, string phoneNumber2, string information)
        {
            this.Id = id;
            this.PartnerId = partnerId;
            this.ContactName = contactName;
            this.Description = description;
            this.ContactType = contactType;
            this.PhoneNumber1 = phoneNumber1;
            this.PhoneNumber2 = phoneNumber2;
            this.Information = information;
        }


        /// <summary>
        /// Id do Contato do Parceiro
        /// </summary>
        [Column("partnerCode")]
        public Guid Id { get; set; }

        /// <summary>
        /// Id do Parceiro
        /// </summary>
        [Column("partnerId")]
        public Guid PartnerId { get; set; }

        /// <summary>
        /// Nome do Contato
        /// </summary>
        [Column("contactName")]
        public string ContactName { get; set; }

        /// <summary>
        /// Descrição do Contato
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// Tipo do Contato
        /// </summary>
        [Column("contactType")]
        public string ContactType { get; set; }

        /// <summary>
        /// telefone 1
        /// </summary>
        [Column("phoneNumber1")]
        public string PhoneNumber1 { get; set; }

        /// <summary>
        ///telefone 2
        /// </summary>
        [Column("phoneNumber2")]
        public string PhoneNumber2 { get; set; }

        /// <summary>
        /// Observações do contato
        /// </summary>
        [Column("information")]
        public string Information { get; set; }



    }
}
