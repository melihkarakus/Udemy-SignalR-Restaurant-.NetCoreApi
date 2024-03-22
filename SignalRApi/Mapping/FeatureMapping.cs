using AutoMapper;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultFeatureDtos>().ReverseMap();
            CreateMap<Feature, CreateFeatureDtos>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDtos>().ReverseMap();
            CreateMap<Feature, GetFeatureDtos>().ReverseMap();
        }
    }
}
