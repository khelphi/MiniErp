using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Helpers
{
    public abstract class BaseService
    {

        public ResultData<T> SuccessData<T>(T data)
        {
            return new ResultData<T>(data);
        }

        public ResultData SuccesData()
        {
            return new ResultData(true);
        }
        
        public ResultData ErrorData<T>(List<string> metaError) where T : struct
        {
            return new ErrorData<T>(metaError);
        }

        public ResultData ErrorData<T>(string metaError) where T : struct
        {
            return new ErrorData<T>(metaError);
        }
        
    }
}
