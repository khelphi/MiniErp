using Microsoft.AspNetCore.Mvc;
using MiniErp.Application.Helpers;
using System;
using System.Net;

namespace MiniErp.Application.Helpers
{
    public static class HttpHelper
    {
        
        public static IActionResult Convert(Result result)
        {
            if (result == null)
            {
                throw new ArgumentException("Result Cannot be null", "result");
            }

            if (result.Success)
            {
                return new OkResult();
            }

            if (result.MetaError.ProtocolCode == (int)HttpStatusCode.NotFound)
            {
                return new NotFoundObjectResult(result.MetaError.Error);
            }

            if (result.MetaError.ProtocolCode == (int)HttpStatusCode.BadRequest)
            {
                return new BadRequestObjectResult(result.MetaError.Error);
            }

            return new ObjectResult(result.MetaError.Error)
            {
                StatusCode = result.MetaError.ProtocolCode
            };

        }
        
        public static IActionResult Convert(DefaultDataResponse result)
        {
            if (result == null)
            {
                throw new ArgumentException("Result Cannot be null", "result");
            }

            if (result.Success)
            {
                return new ObjectResult(result) {StatusCode = (int)HttpStatusCode.OK};
            }
            return new BadRequestObjectResult(result);
        }

        public static IActionResult Convert<T>(Result<T> result)
        {
            if (result == null)
            {
                throw new ArgumentException("Result Cannot be null", "result");
            }

            if (result.Success)
            {
                return new OkObjectResult(result.Obj);
            }

            if (result.MetaError.ProtocolCode == (int)HttpStatusCode.NotFound)
            {
                return new NotFoundObjectResult(result.MetaError.Error);
            }

            if (result.MetaError.ProtocolCode == (int)HttpStatusCode.BadRequest)
            {
                return new BadRequestObjectResult(result.MetaError.Error);
            }

            return new ObjectResult(result.MetaError.Error)
            {
                StatusCode = result.MetaError.ProtocolCode
            };

        }

    }
}
