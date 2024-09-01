using ShopEasy.Models;

namespace ShopEasy.Service
{
    public class ProductService
    {
        private readonly List<Product> _products = new List<Product>
    {
        new Product(1, "Laptop", 9.9, "New", "/images/laptop.jfif", 5, "China"),
        new Product(2, "IPhone", 8.9, "2nd Hand", "/images/phone.jpg", 10, "USA"),
        new Product(3, "IPad", 7.9, "Refurbished", "/images/ipad.jfif", 100, "VietNam")
    };

        // Retrieve all products
        public IEnumerable<Product> GetProducts() => _products;

        // Get a single product by its ID
        public Product GetProductById(int id) {            
            return _products.FirstOrDefault(p => p.Id == id);
        } 

    }

}
