using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniErp.Application.Helpers
{
    public class ErrorReturn
    {

        public string Code { get; set;}
        public string Message { get; set; }
    }

    public class FieldRetornoError: ErrorReturn
    {
        public string Field { get; set; }
    }

}
