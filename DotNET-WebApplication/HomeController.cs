using Microsoft.AspNetCore.Mvc;

namespace DotNET_WebApplication
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var productName = _productService.GetProductName();
            return Content($"Product: {productName}");
        }
    }
}