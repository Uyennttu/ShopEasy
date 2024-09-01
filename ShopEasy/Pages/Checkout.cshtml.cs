using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopEasy.Models;
using ShopEasy.Service;

namespace ShopEasy.Pages
{
    public class CheckoutModel : PageModel
    {
        public List<CartItem> CartItems { get; set; }
        public double TotalAmount;
        public void OnGet()
        {
            CartItems = SessionService.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "CartItems");
        if(CartItems != null)
            {
                TotalAmount = CartItems.Sum(item => item.Product.Price * item.Quantity);
            }
        }
    }
}
