using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Helpers
{
    public class DefaultDataResponse
    {

        public DefaultDataResponse(bool success)
        {
            this.Success = success;
        }
        public virtual bool Success { get; set; }

    }
    public class DefaultDataResponse<T> : DefaultDataResponse
    {
        public DefaultDataResponse(T data) : base(true)
        {
            this.Data = data;
        }

        public T Data { get; private set; }

    }
     
}
