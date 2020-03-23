using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibraryNetCore.Model
{
    public partial class Client
    {
        protected Client() {
            this.Orders = new HashSet<Order>();
        }

        public int ClientId { get; set; }
        [MaxLength(20)]
        [MinLength(0)]
        public string Name { get; set; }
        [MinLength(0)]
        [MaxLength(50)]
        public string Email { get; set; }
        // 0 = inregistrare corecta; 1 = inregistrare stearsa
        //public int Deleted { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
