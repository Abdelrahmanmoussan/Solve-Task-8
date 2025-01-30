using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Database.Models
{
    internal class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public float Sales { get; set; }

        public ICollection<Sale> Products { get; } = new List<Sale>();

    }
}
