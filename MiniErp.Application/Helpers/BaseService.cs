using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Helpers
{
    public abstract class BaseService
    {

        public DefaultDataResponse<T> SuccessResponse<T>(T data)
        {
            return new DefaultDataResponse<T>(data);
        }

        public DefaultDataResponse SuccessResponse()
        {
            return new DefaultDataResponse(true);
        }
        
        public DefaultDataResponse ErrorResponse<T>(List<string> metaError) where T : struct
        {
            return new ErrorData<T>(metaError);
        }

        public DefaultDataResponse ErrorResponse<T>(string metaError) where T : struct
        {
            return new ErrorData<T>(metaError);
        }
        
    }
}
