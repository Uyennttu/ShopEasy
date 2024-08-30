using System.Text.Json;
using ShopEasy.Models;
namespace ShopEasy.Service
{
    public class CartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string CartSessionKey = "Cart";
        private readonly ProductService _productService;
        public CartService(IHttpContextAccessor httpContextAccessor, ProductService productService)
        {
            _httpContextAccessor = httpContextAccessor;
            _productService = productService;
        }

        public List<Item> GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            var cartData = session?.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartData))
            {
                return new List<Item>();
            }
            return JsonSerializer.Deserialize<List<Item>>(cartData) ?? new List<Item>();
        }

        public void AddToCart(Product product, int quantity)
        {
            var cart = GetCartItems();
            var existingItem = cart.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new Item(product, quantity));
            }
            SaveCart(cart);
        }
        public void SaveCart(List<Item> cart)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            var cartData = JsonSerializer.Serialize(cart);
            session?.SetString(CartSessionKey, cartData);
        }
        public Product GetProductById(int productId)
        {
            return _productService.GetProducts().FirstOrDefault(p => p.Id == productId);
        }


    }
}
