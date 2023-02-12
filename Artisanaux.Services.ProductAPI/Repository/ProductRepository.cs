using Artisanaux.Services.ProductAPI.DbContexts;
using Artisanaux.Services.ProductAPI.Models;
using Artisanaux.Services.ProductAPI.Models.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Artisanaux.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Task<ProductDto> CreateUpdateProduct(ProductDto product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            Product productEntity = _mapper.Map<Product>(product);
            if (productEntity.ProductId > 0)
            {
                _db.Products!.Update(productEntity);
            }
            else
            {
                _db.Products!.Add(productEntity);
            }



            _db.SaveChanges();
            return Task.FromResult(_mapper.Map<ProductDto>(productEntity));
        }

        public Task<bool> DeleteProduct(int productId)
        {
            _db.Products!.Remove(new Product { ProductId = productId });
            return Task.FromResult(_db.SaveChanges() > 0);
        }

        
        public async Task<ProductDto> GetProductById(int productId)
        {
                Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
};
