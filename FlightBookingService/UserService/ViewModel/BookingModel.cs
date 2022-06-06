using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.ViewModel
{
    public class BookingModel
    {
        public DateTime CreatedDate { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public long Id { get; set; }
        public string Pnrno { get; set; }
        public long FlightId { get; set; }
        public string FlightName { get; set; }
        public long UserId { get; set; }
        public long BookedSeats { get; set; }
        public decimal Total { get; set; }
        public long? AppliedCoupenCode { get; set; }
        public bool IsCoupenApplied { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Meal { get; set; }

    }
}
