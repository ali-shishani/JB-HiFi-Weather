using AutoMapper;
using jb.hifi.core.Models.Output;
using jb.hifi.core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jb.hifi.service
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            //CreateMap<Source, Dest>().ForMember(dest => dest.Member, opt => opt.Ignore());

            // we only wish to return the description to the client
            CreateMap<OpenWeatherDataResponse, CurrentWeatherDataOutput>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Weather == null || src.Weather.Count == 0 ? "Not available" : src.Weather.FirstOrDefault().Description));
        }
    }
}
