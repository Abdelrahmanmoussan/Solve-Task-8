using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Database.Models
{
    internal class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}
