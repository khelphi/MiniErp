using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Helpers
{
    public class ResultData
    {

        public ResultData(bool success)
        {
            this.Success = success;
        }
        public virtual bool Success { get; private set; }

    }
    public class ResultData<T> : ResultData
    {
        public ResultData(T data) : base(true)
        {
            this.Data = data;
        }

        public T Data { get; private set; }
    }
     
}
