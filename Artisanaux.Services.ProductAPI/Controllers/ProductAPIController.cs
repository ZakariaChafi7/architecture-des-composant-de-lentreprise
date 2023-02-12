using Artisanaux.Services.ProductAPI.Models.Dto;
using Artisanaux.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Artisanaux.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {

        protected ResponseDto _response;
        private IProductRepository _productRepository;


        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            _response.Result = productDtos;
            return _response;
        }
        [HttpGet("{id:int}")]
        public async Task<object> GetById(int id)
        {
            ProductDto productDtos =  await _productRepository.GetProductById(id);
            _response.Result = productDtos;
            return _response;

            /* try
              {
                  var result = await _productRepository.GetProductById(id);

                  if (result == null) return NotFound();

                  return result;
              }
              catch (Exception)
              {
                  return StatusCode(StatusCodes.Status500InternalServerError,
                      "Error retrieving data from the database");
              }*/
        }
        [HttpPost]
        public async Task<object> Post(ProductDto productDto)
        {
            ProductDto product = await _productRepository!.CreateUpdateProduct(productDto);
            _response.Result = product;
            return Ok(_response);
        }
        [HttpPut]
        public async Task<object> Put(ProductDto productDto)
        {
            ProductDto product = await _productRepository!.CreateUpdateProduct(productDto);
            _response.Result = product;
            return Ok(_response);
        }
        [HttpDelete("{id:int}")]
        public async Task<object> Delete(int id)
        {
            bool isDeleted = await _productRepository!.DeleteProduct(id);
            _response.Result = isDeleted;
            return Ok(_response);
        }


    }


}
