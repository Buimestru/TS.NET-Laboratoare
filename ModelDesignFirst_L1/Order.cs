using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime Date { get; set; }
        public int CustomerCustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
