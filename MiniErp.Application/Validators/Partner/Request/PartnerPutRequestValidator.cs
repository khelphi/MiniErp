using FluentValidation;
using MiniErp.Application.Contracts.v1.Partners.Request;
using MiniErp.Application.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Validators.Partner.Request
{
    class PartnerPutRequestValidator : AbstractValidator<PartnerPutRequest>
    {
        public PartnerPutRequestValidator()
        {

            RuleFor(x => x.Name).Must(name => !string.IsNullOrEmpty(name))
                .WithErrorCode(MiniErpErrors.Partner_Post_400_Name_Cannot_Be_Null_Or_Empty.ToString());

            RuleFor(x => x.Document).Must(n => !string.IsNullOrEmpty(n))
                .WithErrorCode(MiniErpErrors.Partner_Post_400_Document_Cannot_Be_Null_Or_Empty.ToString());
        }

    }
}
