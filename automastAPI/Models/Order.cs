using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace automastAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Products { get; set; }
        public DateTime Date { get; set; }
        public bool Completed { get; set; }
        public bool Installation { get; set; }
        public int Cost { get; set; }

    }
}
