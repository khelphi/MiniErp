using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiniErp.Application.Data.MySql.Entities
{
    [Table("productFamily")]
    public class ProductFamilyEntity
    {
        public ProductFamilyEntity()
        {

        }

        public ProductFamilyEntity(string description)
        {
            this.Id = Guid.NewGuid();
            this.Description = description;
        }


        /// <summary>
        /// Id da Familia de  Produto
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Descrição da Familia de  Produto
        /// </summary>
        [Column("decription")]
        public string Description { get; set; }

    }
}
