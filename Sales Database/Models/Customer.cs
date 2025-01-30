
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Database.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreaditCardNumber { get; set; }
        public float Sales {  get; set; }

        public ICollection<Sale> Products { get; } = new List<Sale>();

    }
}
