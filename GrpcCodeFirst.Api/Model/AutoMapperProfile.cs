using AutoMapper;
using Google.Protobuf.Collections;

namespace GrpcCodeFirst.Api.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {   
            CreateMap<Conference, Shared.DTO.ConferenceOverview>();
            CreateMap<Conference, Shared.DTO.ConferenceDetails>();
            CreateMap<Shared.DTO.ConferenceDetails, Conference>();
            CreateMap<Shared.DTO.ConferenceOverview, Conference>();

            CreateMap<Conference, GrpcServices.Interfaces.ConferenceOverview>();
            CreateMap<GrpcServices.Interfaces.ConferenceOverview, Conference>();

            ForAllPropertyMaps(
                map => map.DestinationType.IsGenericType && map.DestinationType.GetGenericTypeDefinition() == typeof(RepeatedField<>),
                (map, options) => options.UseDestinationValue()
            );
        }
    }
}
