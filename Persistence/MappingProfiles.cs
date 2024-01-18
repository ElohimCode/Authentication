using AutoMapper;
using Common.Responses;
using Persistence.Models;

namespace Persistence
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, UserResponse>();
            CreateMap<ApplicationRole, RoleResponse>();
            CreateMap<ApplicationRoleClaim, RoleClaimViewModel>().ReverseMap();
        }
    }
}
