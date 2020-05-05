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


namespace MiniErp.Application.Services.v1
{
    public class PartnerService : BaseService
    {

        private readonly PartnerRepository partnerRepository;

        public PartnerService(PartnerRepository _partnerRepository)
        {
            this.partnerRepository = _partnerRepository;
        }

        public async Task<ResultData> CreateAsync(PartnerPostRequest request) 
        {

            var validator = new PartnerPostRequestValidator();
            var validationResult = validator.Validate(request);

            var existPartner = await partnerRepository.GetByDocument(request.Document);

            if (existPartner != null)
                return ErrorData<MiniErpErrors>(MiniErpErrors.Partner_Post_400_Document_Cannot_Be_Duplicate.ToString());

            if (!validationResult.IsValid)
                return ErrorData<MiniErpErrors>(validationResult.Errors.ToErrorCodeList());


            var partner = new PartnerEntity(request);
            var result = await partnerRepository.CreateAsync(partner);
            return SuccessData(result);
        }

        public async Task<ResultData> UpdateAsync(PartnerPutRequest request)
        {

            var validator = new PartnerPutRequestValidator();
            var validationResult = validator.Validate(request);

            var existPartner = await partnerRepository.GetByDocument(request.Document);

            if (existPartner != null && existPartner.PartnerId != request.PartnerId)
                return ErrorData<MiniErpErrors>(MiniErpErrors.Partner_Put_400_Document_Cannot_Be_Duplicate.ToString());

            if (!validationResult.IsValid)
                return ErrorData<MiniErpErrors>(validationResult.Errors.ToErrorCodeList());


            var partner = new PartnerEntity(request);
            var result = await partnerRepository.CreateAsync(partner);
            return SuccessData(result);
        }


        public async Task<ResultData> GetById(Guid partnerId) 
        {
            var result = await partnerRepository.GetById(partnerId);
            return SuccessData(result);
        }

        public async Task<ResultData> GetAll()
        {
            var result = await partnerRepository.GetAll();
            return SuccessData(result);
        }

        public async Task<ResultData> DeleteById(Guid partnerId)
        {
            var partner = await partnerRepository.GetById(partnerId);
            if (partner == null)
                return ErrorData<MiniErpErrors>(MiniErpErrors.Partner_Get_400_PartnerId_Not_Found.ToString());

            var result = await partnerRepository.DeleteById(partnerId);
            
            if (result)
               return SuccessData("Parceiro Excluído com sucesso");
            else
               return ErrorData<MiniErpErrors>(MiniErpErrors.Partner_Delete_400_Connot_Delete_Partner.ToString());
        }

    }
}
