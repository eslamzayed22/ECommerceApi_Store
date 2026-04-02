using AutoMapper;
using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities.ProductModule;
using ECommerce.ServiceAbstraction;
using ECommerce.Shared.DTOS.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            //map DTO to entity
            var product = _mapper.Map<Product>(createProductDto);
            await repo.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            //map entity to DTO
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var product = await repo.GetByIdAsync(id);
            if (product is null)
            {
                throw new Exception("Product not found");
            }
            //map DTO to entity
            _mapper.Map(updateProductDto, product);

            repo.Update(product);
            await _unitOfWork.SaveChangesAsync();
            //map entity to DTO
            return _mapper.Map<ProductDto>(product);

        }

        public async Task DeleteProductAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var product = await repo.GetByIdAsync(id);
            if (product is null)
            {
                throw new Exception("Product not found");
            }
            repo.Delete(product);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var Brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<BrandDto>>(Brands);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var Categories = await _unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(Categories);
        }
     
    }
}
