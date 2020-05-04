using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiniErp.Application.Data.MySql.StaticTypes
{
    public enum PartnerStatusType
    {

        /// <summary>
        /// Indica que o parceiro esta ativo
        /// </summary>
        [Display(Name = "Ativo")]
        Active =1,

        /// <summary>
        /// Indica que o parceiro esta Inatico
        /// </summary>
        [Display(Name = "Inativo")]
        Inactive =0

    }
}
