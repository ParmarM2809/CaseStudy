using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.ViewModel
{
    public class BookingModel
    {
        public long Id { get; set; }
        public string Pnrno { get; set; }
        public long FlightId { get; set; }
        public long UserId { get; set; }
        public long BookedSeats { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Total { get; set; }
        public long? AppliedCoupenCode { get; set; }
        public bool IsCoupenApplied { get; set; }
        public bool IsCancelled { get; set; }

    }
}
