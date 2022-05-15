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
        [Required]
        public string StartPoint { get; set; }
        [Required]
        public string EndPoint { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public bool IsDiscountAvailable { get; set; }
        [Required]
        public string AirlineName { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
    }
}