using AutoMapper;
using Technico.Core.DTOs.Property;
using Technico.Core.Entities;

namespace Technico.Core.Profiles
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PropertyDto>();

            CreateMap<CreatePropertyDto, Property>();

            CreateMap<UpdatePropertyDto, Property>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
