using AutoMapper;
using Danske.HW.Contracts;
using Danske.HW.Entities;
using Danske.HW.Models;

namespace Danske.HW.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<NumberContract, NumberModel>();
            CreateMap<NumberModel, NumberContract>();

            CreateMap<NumberModel, NumberEntity>();
            CreateMap<NumberEntity, NumberModel>();

        }
    }
}
