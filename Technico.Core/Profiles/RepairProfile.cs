using AutoMapper;
using Technico.Core.DTOs.Property;
using Technico.Core.DTOs.Repair;
using Technico.Core.Entities;

namespace Technico.Core.Profiles
{
    public class RepairProfile : Profile
    {
        public RepairProfile()
        {
            CreateMap<Repair, RepairDto>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Property.Owner.Name))
                .ForMember(dest => dest.OwnerSurname, opt => opt.MapFrom(src => src.Property.Owner.Surname))
                .ForMember(dest => dest.E9, opt => opt.MapFrom(src => src.Property.E9))
                .ForMember(dest => dest.PropertyAddress, opt => opt.MapFrom(src => src.Property.Address));

            CreateMap<CreateRepairDto, Repair>();

            CreateMap<UpdateRepairDto, Repair>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
