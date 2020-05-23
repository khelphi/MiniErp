using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniErp.Application.Data.MySql.Entities
{
    [Table("productType")]
    public class ProductTypeEntity
    {
        public ProductTypeEntity()
        {

        }

        public ProductTypeEntity(string description)
        {
            this.Id = Guid.NewGuid();
            this.Description = description;
        }


        /// <summary>
        /// Id do Tipo de Produto
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Descrição do Tipo de Produto
        /// </summary>
        [Column("decription")]
        public string Description { get; set; }

    }
}
