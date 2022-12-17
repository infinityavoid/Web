using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace automastAPI.Models
{
    public class SparePart
    {
        public int SparePartId { get; set; }
        public string SpareName { get; set; }
        public int Cost { get; set; }
        public int Amount { get; set; }
        public string SparePhoto { get; set; }
        public int Quantity { get; set; }
    }
}
