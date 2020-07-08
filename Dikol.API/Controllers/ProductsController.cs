using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dikol.API.DTOs;
using Dikol.API.Errors;
using Dikol.Core.Entities;
using Dikol.Core.Interfaces;
using Dikol.Core.Specifications.Params;
using Dikol.Core.Specifications.ProductSpecifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dikol.API.Helpers.Pagination;

namespace Dikol.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo, 
            IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        #region Products
        [HttpGet]
        public async Task<ActionResult<GenericPagination<ProductDTO>>> GetProducts(
            [FromQuery] ProductSpecificationParams productsParams)
        {
            var productsWithTypesAndBrandsSpec = new ProductsWithTypesAndBrandsSpecification(productsParams);
            var productCountSpec = new ProductsWithFiltersForCountSpecification(productsParams);

            var productsCount = await _productRepo.CountAsync(productCountSpec);

            var products = await _productRepo.GetAllAsync(productsWithTypesAndBrandsSpec);
            var productsDTO = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);

            return Ok(new GenericPagination<ProductDTO>(
                productsParams.PageIndex,
                productsParams.PageSize, 
                productsCount, 
                productsDTO)
                );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var specification = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productRepo.GetEntityAsync(specification);

            if (product == null)
                return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Product, ProductDTO>(product));
        } 
        #endregion

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _productBrandRepo.GetAllAsync();

            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productTypes = await _productTypeRepo.GetAllAsync();

            return Ok(productTypes);
        }
    }
}
