using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jb.hifi.core.Models.Response;

namespace jb.hifi.core.Models.Output
{
    public class CurrentWeatherDataOutput : ResponseBase
    {
        public string Description { get; set; } // we only wish to return the description to the client
    }
}
