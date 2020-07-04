using AutoMapper;
using Dikol.API.DTOs;
using Dikol.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dikol.API.Helpers.AutoMapper.Resolvers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            return string.IsNullOrEmpty(source.PictureUrl) == false ?
                _configuration["ApiUrl"] + source.PictureUrl : null;
        }
    }
}
