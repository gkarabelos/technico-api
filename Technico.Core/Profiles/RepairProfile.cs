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
            CreateMap<Repair, RepairDto>();

            CreateMap<CreateRepairDto, Repair>();

            CreateMap<UpdateRepairDto, Repair>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Repair, RepairDto>()
           .ForMember(dest => dest.PropertyId, opt => opt.MapFrom(src => src.Property.Id))
           .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Property.Owner.Name)); // <-- Map the Owner's Name to the DTO
        }
    }
}
