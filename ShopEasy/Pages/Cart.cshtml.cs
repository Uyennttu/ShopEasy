using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ShopEasy.Models;
using ShopEasy.Service;

namespace ShopEasy.Pages
{
    public class CartModel : PageModel
    {
        private readonly CartService _cartService;

        public List<CartItem> CartItems => _cartService.CartItems;

        public double TotalPrice => _cartService.TotalPrice();

        public CartModel(CartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult OnPostAddToCart(int productId)
        {
            _cartService.AddItem(productId);
            return RedirectToPage("Cart");
        }

        public IActionResult OnPostRemove(int productId)
        {
            _cartService.RemoveItem(productId);
            return RedirectToPage();
        }

        public IActionResult OnPostIncreaseQuantity(int productId)
        {
            _cartService.IncreaseItem(productId);
            return RedirectToPage();
        }
    }
}
