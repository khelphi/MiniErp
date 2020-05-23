using MiniErp.Application.Contracts.v1.PartnersContact.Request;
using MiniErp.Application.Data.MySql.Entities;
using MiniErp.Application.Data.MySql.Repositories;
using MiniErp.Application.Errors;
using MiniErp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniErp.Application.Services.v1
{
    public class PartnersContactService : BaseService
    {
        private readonly PartnerContactRepository partnerContactRepository;

        public PartnersContactService(PartnerContactRepository _partnerContactRepository)
        {
            this.partnerContactRepository = _partnerContactRepository;
        }

        /// <summary>
        /// 
        /// </summary> 
        /// <param name="request"></param>
        public async Task<DefaultDataResponse> CreateAsync(PartnerContactPostRequest request)
        {

            //var validator = new PartnerPostRequestValidator();
            //var validationResult = validator.Validate(request);

            //var existPartner = await partnerRepository.GetByDocument(request.Document);

            //if (existPartner != null)
            //    return ErrorResponse<MiniErpErrors>(MiniErpErrors.Partner_Post_400_Document_Cannot_Be_Duplicate.ToString());

            //if (!validationResult.IsValid)
            //    return ErrorResponse<MiniErpErrors>(validationResult.Errors.ToErrorCodeList());

            var partnerContat = new PartnerContactEntity(request);
            var result = await partnerContactRepository.CreateAsync(partnerContat);
            return SuccessResponse(result);
        }


        public async Task<DefaultDataResponse> UpdateAsync(PartnerContactPutRequest request)
        {

            //var validator = new PartnerPutRequestValidator();
            //var validationResult = validator.Validate(request);

            //var existPartner = await partnerRepository.GetByDocument(request.Document);
            
            //if (existPartner != null && existPartner.PartnerId != request.PartnerId)
            //    return ErrorResponse<MiniErpErrors>(MiniErpErrors.Partner_Put_400_Document_Cannot_Be_Duplicate.ToString());

            //if (!validationResult.IsValid)
            //    return ErrorResponse<MiniErpErrors>(validationResult.Errors.ToErrorCodeList());

            var partner = new PartnerContactEntity(request);
            var result = await partnerContactRepository.CreateAsync(partner);
            return SuccessResponse(result);
        }

        public async Task<DefaultDataResponse> GetById(Guid Id)
        {
            var result = await partnerContactRepository.GetById(Id);
            return SuccessResponse(result);
        }


        public async Task<DefaultDataResponse> GetByPartnerId(Guid partnerId)
        {
            var result = await partnerContactRepository.GetByPartnerId(partnerId);
            return SuccessResponse(result);
        }


        public async Task<DefaultDataResponse> DeleteById(Guid id)
        {
            //var partner = await partnerRepository.GetById(partnerId);
            //if (partner == null)
            //    return ErrorResponse<MiniErpErrors>(MiniErpErrors.Partner_Get_400_PartnerId_Not_Found.ToString());

            var result = await partnerContactRepository.DeleteById(id);

            if (result)
                return SuccessResponse("Contato de Parceiro Excluído com sucesso");
            else
                return ErrorResponse<MiniErpErrors>(MiniErpErrors.PartnerContact_Delete_400_Connot_Delete_PartnerContact.ToString());
        }

    }
}
