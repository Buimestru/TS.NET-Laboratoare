using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryNetCore.Model
{
    public partial class OrderDetails
    {
        protected OrderDetails()
        {
        }
        public int OrderDetailsId { get; set; }
        public int ProductID { get; set; }
        public float Qty { get; set; }
        public float Price { get; set; }
        public int Deleted { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; internal set; }
        public virtual Product Product { get; internal set; }
    }
}
