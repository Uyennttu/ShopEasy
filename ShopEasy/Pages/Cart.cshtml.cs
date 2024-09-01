using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopEasy.Models;
using ShopEasy.Service;

namespace ShopEasy.Pages
{
    public class CartModel : PageModel
    {
        private readonly ProductService _productService;

        public List<CartItem> CartItems { get; set; }

        public CartModel(ProductService productService)
        {
            _productService = productService;
        }

        public void OnGet(int id)
        {
            CartItems = SessionService.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "CartItems");
            if (CartItems == null)
            {
                CartItems = new List<CartItem>
            {
                new CartItem
                {
                    Product = _productService.GetProductById(id),
                    Quantity = 1
                }
            };
            }
            else
            {
                int check = Exist(CartItems, id);
                if (check == -1)
                {
                    CartItems.Add(
                        new CartItem
                        {
                            Product = _productService.GetProductById(id),
                            Quantity = 1
                        });
                }
                else
                {
                    CartItems[check].Quantity++;
                }
            }

            SessionService.SetObjectAsJson(HttpContext.Session, "CartItems", CartItems);
        }

        private int Exist(List<CartItem> cartItems, int id)
        {
            for (int i = 0; i < cartItems.Count; i++)
            {
                if (cartItems[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void OnGetIncrease(int id)
        {
            CartItems = SessionService.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "CartItems");
            int check = Exist(CartItems, id);
            if (check != -1)
            {
                CartItems[check].Quantity++;
                SessionService.SetObjectAsJson(HttpContext.Session, "CartItems", CartItems);
            }
        }

        public void OnGetDelete(int id)
        {
            CartItems = SessionService.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "CartItems");
            int index = Exist(CartItems, id);
            if (index != -1)
            {
                if (CartItems[index].Quantity > 1)
                {
                    // Decrease the quantity if more than 1
                    CartItems[index].Quantity--;
                }
                else
                {
                    // Remove the item if the quantity is 1
                    CartItems.RemoveAt(index);
                }
                SessionService.SetObjectAsJson(HttpContext.Session, "CartItems", CartItems);
            }
        }
    }

}
