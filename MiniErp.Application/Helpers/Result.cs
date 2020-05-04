using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniErp.Application.Helpers
{
    public class Result
    {
        public bool Success
        {
            get { return MetaError == null; }
        }

        public MetaError MetaError { get; set; }
    }


    public class Result<T> : Result
    {
        private T _obj;

        public T Obj
        {
            get { return _obj; }
            set
            {
                if (value != null)
                    {MetaError = null;}
                _obj = value;

            }
        }
    }

}
