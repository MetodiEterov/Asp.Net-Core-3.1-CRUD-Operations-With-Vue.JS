using AutoMapper;

using Entities.DTOs;
using Entities.Models;

namespace AccountOwnerServer.AutoMapperProfiles
{
    /// <summary>
    /// MappingProfile mapping class
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// MappingProfile method
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();
            CreateMap<Account, AccountDto>();
            CreateMap<OwnerForCreationDto, Owner>();
            CreateMap<OwnerForUpdateDto, Owner>();
        }
    }
}
