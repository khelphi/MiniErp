using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniErp.Application.Helpers
{
    public class MetaError
    {

        public MetaError(ErrorReturn error, int? protocolCode)
        {
            Error = error;
            ProtocolCode = protocolCode;
        }

        public ErrorReturn Error { get; set; }

        public int? ProtocolCode { get; set; }
    }


}
