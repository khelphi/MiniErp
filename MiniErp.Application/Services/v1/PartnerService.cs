using MiniErp.Application.Contracts.v1.Partners.Request;
using MiniErp.Application.Contracts.v2.Partners.Request;
using MiniErp.Application.Data.MySql.Entities;
using MiniErp.Application.Data.MySql.Repositories;
using MiniErp.Application.Errors;
using MiniErp.Application.Helpers;
using MiniErp.Application.Validators.Partner.Request;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using MiniErp.Application.Data.MySql.Views;

namespace MiniErp.Application.Services.v1
{
    public class PartnerService : BaseService
    {

        private readonly PartnerRepository partnerRepository;

        public PartnerService(PartnerRepository _partnerRepository)
        {
            this.partnerRepository = _partnerRepository;
        }


        /// <summary>
        /// 
        /// </summary> 
        /// <param name="request"></param>
        public async Task<DefaultDataResponse> CreateAsync(PartnerPostRequest request) 
        {
            
            var validator = new PartnerPostRequestValidator();
            var validationResult = validator.Validate(request);

            var existPartner = await partnerRepository.GetByDocument(request.Document);

            if (existPartner != null)
                return ErrorResponse<MiniErpErrors>(MiniErpErrors.Partner_Post_400_Document_Cannot_Be_Duplicate.ToString());

            if (!validationResult.IsValid)
                return ErrorResponse<MiniErpErrors>(validationResult.Errors.ToErrorCodeList());

            var partner = new PartnerEntity(request);
            var result = await partnerRepository.CreateAsync(partner);
            return SuccessResponse(result);
        }

        public async Task<DefaultDataResponse> UpdateAsync(PartnerPutRequest request)
        {

            var validator = new PartnerPutRequestValidator();
            var validationResult = validator.Validate(request);

            var existPartner = await partnerRepository.GetByDocument(request.Document);

            if (existPartner != null && existPartner.PartnerId != request.PartnerId)
                return ErrorResponse<MiniErpErrors>(MiniErpErrors.Partner_Put_400_Document_Cannot_Be_Duplicate.ToString());

            if (!validationResult.IsValid)
                return ErrorResponse<MiniErpErrors>(validationResult.Errors.ToErrorCodeList());



            var partner = new PartnerEntity(request);
            var result = await partnerRepository.CreateAsync(partner);
            return SuccessResponse(result);
        }


        public async Task<DefaultDataResponse> GetById(Guid partnerId) 
        {
            var result = await partnerRepository.GetById(partnerId);
            return SuccessResponse(result);
        }

        public async Task<DefaultDataResponse> GetAll()
        {
            var result = await partnerRepository.GetAll();
            return SuccessResponse(result);
        }

        public async Task<DefaultDataResponse> DeleteById(Guid partnerId)
        {
            var partner = await partnerRepository.GetById(partnerId);
            if (partner == null)
                return ErrorResponse<MiniErpErrors>(MiniErpErrors.Partner_Get_400_PartnerId_Not_Found.ToString());

            var result = await partnerRepository.DeleteById(partnerId);
            
            if (result)
               return SuccessResponse("Parceiro Excluído com sucesso");
            else
               return ErrorResponse<MiniErpErrors>(MiniErpErrors.Partner_Delete_400_Connot_Delete_Partner.ToString());
        }


        public async Task<DefaultDataResponse> GetByFilter(PartnerFilteredRequest request)
        {
            //var validator = new PartnerFilteredRequestValidator();
            var result = await partnerRepository.GetByFilter(request);
            return SuccessResponse(result);

        }


    }
}
