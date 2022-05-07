using AutoMapper;
using Conference;

namespace ConfTool.Server.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Model.Conference, ConferenceOverview>();
            CreateMap<ConferenceOverview, Model.Conference>();

            CreateMap<Model.Conference, Shared.DTO.ConferenceDetails>();
            CreateMap<Model.Conference, Shared.DTO.ConferenceOverview>();
            CreateMap<Shared.DTO.ConferenceDetails, Model.Conference>();
            CreateMap<Shared.DTO.ConferenceOverview, Model.Conference>();
        }
    }
}
