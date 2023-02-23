using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jb.hifi.core.Models.Response
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; }

        public List<ResponseError> Errors { get; set; }
    }
}
