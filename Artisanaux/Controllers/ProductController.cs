
using Artisanaux.Web.Models;
using Artisanaux.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Artisanaux.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task <IActionResult> ProductIndex()
        {
            List<ProductDto> list = new List<ProductDto>();
            var reponse = await _productService.GetAllProductAsync<ResponseDto>();
            if (reponse != null && reponse.IsSuccess)
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(reponse.Result));

            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            var response =await _productService.CreateProductsAsync<ResponseDto>(model);
            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(ProductIndex));
            return View(model);
        }
    }
}
