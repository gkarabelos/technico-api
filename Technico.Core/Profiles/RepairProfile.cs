using AutoMapper;
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
        }
    }
}
