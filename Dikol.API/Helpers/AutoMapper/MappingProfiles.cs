using AutoMapper;
using Dikol.API.DTOs;
using Dikol.Core.Entities;

namespace Dikol.API.Helpers.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
