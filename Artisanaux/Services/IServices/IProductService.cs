

using Artisanaux.Web.Models;

namespace Artisanaux.Web.Services.IServices
{
    public interface IProductService:IBaseService
    {
        Task<T> GetAllProductAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id, string token);
        Task<T> CreateProductsAsync<T>(ProductDto product);
        Task<T> UpdateProductsAsync <T>(ProductDto product, string token);
        Task<T> DeletProductsAsync <T>(int id, string token);




    }
}
