using AutoMapper;
using BlazorWasmGrpcCodeFirst.Shared.DTO;

namespace BlazorWasmGrpcCodeFirst.Server.Model
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
