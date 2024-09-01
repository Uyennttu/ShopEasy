using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopEasy.Models;
using ShopEasy.Service;

namespace ShopEasy.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ProductService _productService;    

        public ProductDetailsModel(ProductService productService)
        {
            _productService = productService;
           
        }

        public Product Product { get; set; }
        
        public void OnGet(int id)
        {
            Product = _productService.GetProductById(id);
          
        }
        
    }

}
