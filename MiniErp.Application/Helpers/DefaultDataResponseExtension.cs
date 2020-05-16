using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Helpers
{
    public static class DefaultDataResponseExtension
    {

        public static List<ErrorReturn> GetListErrors(this DefaultDataResponse @obj)
        {
            return (List<ErrorReturn>)@obj.GetType().GetProperty("Errors").GetValue(@obj, null);
        }

    }
}
