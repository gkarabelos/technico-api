using AutoMapper;
using Technico.Core.DTOs.Owner;
using Technico.Core.Entities;

namespace Technico.Core.Profiles
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerDto>();

            CreateMap<CreateOwnerDto, Owner>();

            CreateMap<UpdateOwnerDto, Owner>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
