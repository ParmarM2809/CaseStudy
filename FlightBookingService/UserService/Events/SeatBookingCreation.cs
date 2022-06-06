using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Events
{
    public class SeatBookingCreation
    {
        public long SeatCount { get; set; }

        public long FlightId { get; set; }
    }
}
