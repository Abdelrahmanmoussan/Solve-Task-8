using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Database.Models
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public decimal Price { get; set; }
        public float Sales {  get; set; }
        public string Description { get; set; } = "No description";

        public ICollection<Sale> Products { get; } = new List<Sale>();
    }
}
