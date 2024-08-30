using System.Xml.Linq;

namespace ShopEasy.Models
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public string MadeBy { get; set; }

        public Product(int id, string name, double price, string description, string image, int stock, string madeBy)
		{
			Id = id;
			Name = name;
			Price = price;
			Description = description;
			Image = image;
			Stock = stock;
			MadeBy = madeBy;
		}		
    }
}
