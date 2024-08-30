using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopEasy.Service;
using ShopEasy.Models;
using ShopEasy.Helpers;
using ShopEasy.Models;


namespace ShopEasy.Pages
{
    public class CartModel : PageModel
    {
        public List<Item> Cart { get; set; }
        public double Total { get; set; }

        public void OnGet()
        { }

    }
}



