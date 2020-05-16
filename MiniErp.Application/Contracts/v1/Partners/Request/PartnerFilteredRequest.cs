using MiniErp.Application.Data.MySql.StaticTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Contracts.v1.Partners.Request
{
    public class PartnerFilteredRequest
    {

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Documento do Cliente
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        /// Status do Cliente
        /// </summary>
        public PartnerStatusType Status { get; set; }

        /// <summary>
        /// Code do Cliente
        /// </summary>
        public string PartnerCode { get; set; }

        /// <summary>
        /// Página da consulta
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Página final da consulta
        /// </summary>
        public int pageSize { get; set; }

    }
}
