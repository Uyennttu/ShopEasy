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
        private readonly CartService _cartService;

        public ProductDetailsModel(ProductService productService, CartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public Product Product { get; set; }

        // This handles the GET request to load the product details page
        public IActionResult OnGet(int id)
        {
            Product = _productService.GetProductById(id);
            if (Product == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        // This handles the POST request to add the product to the cart
       /* public IActionResult OnPostAddToCart(int productId, int quantity)
        {
            var product = _cartService.GetProductById(productId);
            if (product != null)
            {
                _cartService.AddToCart(product, quantity);
            }
            return RedirectToPage();
        }*/
    }

}
