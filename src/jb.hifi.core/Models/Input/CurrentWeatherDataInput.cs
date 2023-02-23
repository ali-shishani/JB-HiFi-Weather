using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jb.hifi.core.Models.Input
{
    public class CurrentWeatherDataInput
    {
        public CurrentWeatherDataInput()
        {
            CancellationToken = default;
        }

        public string City { get; set; }

        public string Country { get; set; }

        public CancellationToken CancellationToken { get; set; }
    }
}
