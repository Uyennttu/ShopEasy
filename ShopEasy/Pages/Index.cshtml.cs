using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopEasy.Models;
using ShopEasy.Service;

namespace ShopEasy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProductService _productService;
        public IndexModel(ProductService productService)
        {
			_productService=productService;

		}
		public IEnumerable<Product> Products { get; set; }
        
        public void OnGet()
        {
			Products = _productService.GetProducts();
		}
    }


}
