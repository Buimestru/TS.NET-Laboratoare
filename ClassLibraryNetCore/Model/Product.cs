using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibraryNetCore.Model
{
    public partial class Product
    {
        protected Product()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
        }
        public int ProductId { get; set; }
        [MaxLength(50)]
        [MinLength(0)]
        public string ProductName { get; set; }
        public float Stock { get; set; }
        public float Price { get; set; }
        public int Deleted { get; set; }
        public Nullable<int> OrderDetailsId { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; internal set; }
    }
}
