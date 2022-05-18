using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.ViewModel
{
    public class FlightModel
    {
        public long Id { get; set; }

        public DateTime ScheduledDate { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDiscountAvailable { get; set; }
        public string AirlineName { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public int SeatAvaibility { get; set; }
    }
}