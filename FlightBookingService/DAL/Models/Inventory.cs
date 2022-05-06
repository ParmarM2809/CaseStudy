using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Bookings = new HashSet<Booking>();
        }

        public long Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDiscountAvailable { get; set; }
        public string AirlineName { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public long SeatAvaibility { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
