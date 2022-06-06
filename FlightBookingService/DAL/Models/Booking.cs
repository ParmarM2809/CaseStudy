using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Booking
    {
        public long Id { get; set; }
        public string Pnrno { get; set; }
        public long FlightId { get; set; }
        public long UserId { get; set; }
        public long BookedSeats { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public decimal Total { get; set; }
        public long? AppliedCoupenCode { get; set; }
        public bool IsCoupenApplied { get; set; }
        public bool IsCancelled { get; set; }
        public string Meal { get; set; }

        public virtual Inventory Flight { get; set; }
        public virtual UserMaster User { get; set; }
    }
}
