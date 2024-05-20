using AutoMapper;
using WAD.CW1._00013292.DAL.Dtos;
using WAD.CW1._00013292.Models;

namespace WAD.CW1._00013292.DAL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<KeyItem, KeyItemDto>();
            CreateMap<KeyItemDto, KeyItem>();
            CreateMap<KeyType, KeyTypeDto>();
            CreateMap<KeyTypeDto, KeyType>();
        }
    }
}
