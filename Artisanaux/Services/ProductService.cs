
using Artisanaux.Web.Models;
using Artisanaux.Web.Services.IServices;

namespace Artisanaux.Web.Services
{
    public class ProductService : BaseService,IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<T> CreateProductsAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products",
                //AccessToken = token
            });
        }

        public async Task<T> DeletProductsAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });
        }
        public async Task<T> GetAllProductAsync<T>()
        {
            
            return await this.SendAsync<T>(new ApiRequest()
                { 
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products",
                //AccessToken = token
                });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });
        }
         public async Task<T> UpdateProductsAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products",
               // AccessToken = token
            });
        }
    }
}
