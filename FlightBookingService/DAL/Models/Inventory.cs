using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Inventory
    {
        public long Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDiscountAvailable { get; set; }
        public string AirlineName { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
    }
}
