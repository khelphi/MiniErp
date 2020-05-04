using Microsoft.AspNetCore.Mvc;
using MiniErp.Application.Contracts.v2.Partners.Request;
using MiniErp.Application.Data.MySql.Entities;
using MiniErp.Application.Helpers;
using MiniErp.Application.Services.v1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniErp.Api.Default.Controllers.v2
{

    [Route("api/v2/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {

        private readonly PartnerService partnerService;

        /// <summary>
        /// Construtor da controller
        /// </summary>
        /// <param name="_partnerService"></param>
        public PartnerController(PartnerService _partnerService)
        {
            this.partnerService = _partnerService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewPartnerPostRequest request)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid partnerId)
        {
            var result = await partnerService.GetById(partnerId);
            return HttpHelper.Convert(result);
        }



    }
}
