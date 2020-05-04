using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniErp.Application.Helpers
{
    public static class ValidationFailureExtension
    {

        public static List<string> ToErrorCodeList(this IList<ValidationFailure> list)
        {
            var _result = new List<string>();
            foreach (var item in list)
            {
                _result.Add(item.ErrorCode);
            }

            return _result;
        }


    }

}
