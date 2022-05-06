using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.ViewModel;

namespace UserService.Entity
{
    public class BookingEntity
    {
        FlightBookingContext _flightBookingContext = new FlightBookingContext();


        public void AddUpdateBooking(BookingModel bookingModel)
        {
            Booking booking = new Booking();
            booking.AppliedCoupenCode = bookingModel.AppliedCoupenCode;
            booking.BookedSeats = bookingModel.BookedSeats;
            booking.CreatedOn = DateTime.Now;
            booking.EndDate = bookingModel.EndDate;
            booking.FlightId = bookingModel.FlightId;
            booking.IsCancelled = bookingModel.IsCancelled;
            booking.IsCoupenApplied = bookingModel.IsCoupenApplied;
            booking.StartDate = bookingModel.StartDate;
            booking.Total = bookingModel.Total;
            booking.UserId = bookingModel.UserId;
            booking.UpdatedOn = DateTime.Now;
            if (bookingModel.Id == 0)
            {
                Guid guid = Guid.NewGuid();
                booking.Pnrno = guid.ToString();
            }
            else
            {
                booking.Pnrno = bookingModel.Pnrno;
            }
            _flightBookingContext.Add(booking);
            _flightBookingContext.SaveChanges();
        }

        public bool UpdateAligiability(long UserID , string Pnrno)
        {
            Booking booking = _flightBookingContext.Bookings.Where(x => x.UserId == UserID && x.Pnrno == Pnrno).FirstOrDefault();
            if (booking.StartDate.AddHours(24) < DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Booking GetFlightByID(long UserID, string PnrNo)
        {
            Booking booking = _flightBookingContext.Bookings.Where(x => x.UserId == UserID && x.Pnrno == PnrNo).FirstOrDefault();
            return booking;
        }


        public List<Booking> GetActiveBookingList(long UserID)
        {
            List<Booking> bookings = _flightBookingContext.Bookings.Where(x => x.UserId == UserID &&
           x.IsCancelled == false && x.StartDate >= DateTime.Now).ToList();
            return bookings;
        }

    }
}
