using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibraryNetCore.Model
{
    public partial class Order
    {
        protected Order()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
        }
        public int OrderId { get; set; }
        [MaxLength(7)]
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public int Payed { get; set; }
        public int ClientId { get; set; }
        public int Deleted { get; set; }
        public virtual Client Client { get; internal set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; internal set; }
    }
}
