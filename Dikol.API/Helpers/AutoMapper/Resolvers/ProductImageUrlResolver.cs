using AutoMapper;
using Dikol.API.DTOs;
using Dikol.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Dikol.API.Helpers.AutoMapper.Resolvers
{
    public class ProductImageUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            return string.IsNullOrEmpty(source.PictureUrl) == false ?
                _configuration["ApiUrl"] + source.PictureUrl
                : null;
        }
    }
}
