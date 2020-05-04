using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MiniErp.Application.Helpers
{

    public class ErrorData<T> : ResultData where T : struct
    {

       
        public List<ErrorReturn> Errors { get; private set; }

        protected ErrorData() : base(false)
        {
            Errors = new List<ErrorReturn>();
        }


        public ErrorData(List<string> errorsCode) : this()
        {
            BindErrors(errorsCode);
        }

        public ErrorData(string errorCode) : this()
        {
            BindErrors(new List<string> { errorCode });
        }

        protected virtual void BindErrors(List<string> errorsCode, object paramReplace = null)
        {
            foreach (var item in errorsCode)
            {
                var errorDesc = Enum.Parse(typeof(T), item).ErrorDescription(item);
                Replace(errorDesc.Error, paramReplace);
                Errors.Add(errorDesc.Error);
            }
        }

        protected virtual void BindErrors(List<T> errorsCode, object paramReplace = null)
        {
            foreach (var item in errorsCode)
            {
                var errorDescription = item.ErrorDescription();
                Replace(errorDescription.Error, paramReplace);
                Errors.Add(errorDescription.Error);
            }
        }

        public void Replace(ErrorReturn Error, object paramReplace)
        {
            if (paramReplace != null)
                Error.Message = Error.Message.Replace("[0]", (paramReplace ?? "").ToString());
        }

    }

}
