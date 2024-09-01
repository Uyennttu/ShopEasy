using ShopEasy.Models;

namespace ShopEasy.Service
{
    public class CartService
    {
        
            private readonly ProductService _productService;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public CartService(ProductService productService, IHttpContextAccessor httpContextAccessor)
            {
                _productService = productService;
                _httpContextAccessor = httpContextAccessor;
            }

            public List<CartItem> CartItems
            {
                get
                {
                    var session = _httpContextAccessor.HttpContext.Session;
                    return SessionService.GetObjectFromJson<List<CartItem>>(session, "CartItems") ?? new List<CartItem>();
                }
                set
                {
                    var session = _httpContextAccessor.HttpContext.Session;
                    SessionService.SetObjectAsJson(session, "CartItems", value);
                }
            }

            public void AddItem(int id)
            {
                var cartItems = CartItems;
                var existingItem = cartItems.FirstOrDefault(c => c.Product.Id == id);

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {                   
                    cartItems.Add(new CartItem
                    {
                        Product = _productService.GetProductById(id),
                        Quantity = 1
                    });
                }

                CartItems = cartItems; 
            }

            public void RemoveItem(int id)
            {
                var cartItems = CartItems;
                var item = cartItems.FirstOrDefault(i => i.Product.Id == id);
                if (item != null)
                {
                    if (item.Quantity > 1)
                    {
                        item.Quantity--;
                    }
                    else
                    {
                        cartItems.Remove(item);
                    }
                }

                CartItems = cartItems; 
            }

            public void IncreaseItem(int productId)
            {
                var cartItems = CartItems;
                var item = cartItems.FirstOrDefault(i => i.Product.Id == productId);
                if (item != null)
                {
                    item.Quantity++;
                }

                CartItems = cartItems; 
            }

            public double TotalPrice()
            {
                return CartItems.Sum(i => i.Product.Price * i.Quantity);
            }
        }

    }

