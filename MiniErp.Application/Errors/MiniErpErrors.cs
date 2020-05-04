using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MiniErp.Application.Errors
{
    public enum MiniErpErrors
    {

        [Description("Erro")]
        Partner_Post_400_DefaultError,

        [Description("É necessário informar o Nome do Parceiro")]
        Partner_Post_400_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar o Documento do Parceiro")]
        Partner_Post_400_Document_Cannot_Be_Null_Or_Empty,

        [Description("Payload inválido")]
        Partner_Post_400_Payload_Cannot_Be_Null_Or_Empty,

        [Description("Falha ao tentar excluir o Parceiro")]
        Partner_Delete_400_Connot_Delete_Partner,

        [Description("Identificação do parceiro inválida ou inexistente")]
        Partner_Get_400_PartnerId_Not_Found,



        [Description("É necessário informar o Nome do Parceiro")]
        Partner_Put_400_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar o Documento do Parceiro")]
        Partner_Put_400_Document_Cannot_Be_Null_Or_Empty,

    }
}
