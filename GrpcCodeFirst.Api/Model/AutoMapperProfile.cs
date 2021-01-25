using AutoMapper;
using GrpcCodeFirst.Shared.DTO;

namespace GrpcCodeFirst.Api.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Conference, ConferenceOverview>();
            CreateMap<ConferenceOverview, Conference>();

            CreateMap<Conference, ConferenceDetails>();
            CreateMap<Conference, ConferenceOverview>();
            CreateMap<ConferenceDetails, Conference>();
            CreateMap<ConferenceOverview, Conference>();
        }
    }
}
