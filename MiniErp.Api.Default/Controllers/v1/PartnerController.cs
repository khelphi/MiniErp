using Microsoft.AspNetCore.Mvc;
using MiniErp.Application.Contracts.v1.Partners.Request;
using MiniErp.Application.Helpers;
using MiniErp.Application.Services.v1;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MiniErp.Api.Default.Controllers.v1
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        public async Task<IActionResult> Post([FromBody] PartnerPostRequest request)
        {
            var result = await partnerService.CreateAsync(request);
            return HttpHelper.Convert(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PartnerPutRequest request)
        {
            var result = await partnerService.UpdateAsync(request);
            return HttpHelper.Convert(result);
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> Get([FromQuery] Guid partnerId)
        {
            var result = await partnerService.GetById(partnerId);
            return HttpHelper.Convert(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await partnerService.GetAll();
            return HttpHelper.Convert(result);
        }

        [HttpDelete("DeleteById")]
        public async Task<IActionResult> Delete([FromQuery] Guid partnerId)
        {
            var result = await partnerService.DeleteById(partnerId);
            return HttpHelper.Convert(result);
        }


        [HttpGet("GetByFilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] PartnerFilteredRequest request)
        {
            var result = await partnerService.GetByFilter(request);
            return HttpHelper.Convert(result);
        }


    }
}
