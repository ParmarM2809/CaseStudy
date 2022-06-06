using DAL.Models;
using Microsoft.EntityFrameworkCore;
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
            booking.FlightId = bookingModel.FlightId;
            booking.IsCancelled = bookingModel.IsCancelled;
            booking.IsCoupenApplied = bookingModel.IsCoupenApplied;
            booking.Total = bookingModel.Total;
            booking.UserId = bookingModel.UserId;
            booking.UpdatedOn = DateTime.Now;
            booking.Meal = bookingModel.Meal;
            booking.Id = bookingModel.Id;
            if (bookingModel.Id == 0)
            {
                Guid guid = Guid.NewGuid();
                booking.Pnrno = guid.ToString();
                _flightBookingContext.Add(booking);
            }
            else
            {
                booking.Pnrno = bookingModel.Pnrno;
                _flightBookingContext.Entry(booking).State = EntityState.Detached;
            }
            _flightBookingContext.SaveChangesAsync();
        }

        public bool UpdateAligiability(long UserID, string Pnrno)
        {
            Booking booking = _flightBookingContext.Bookings.Where(x => x.UserId == UserID && x.Pnrno == Pnrno).FirstOrDefault();
            if (booking.CreatedOn < DateTime.Now)
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
        public Booking GetBookingByID(long BookingId)
        {
            Booking booking = _flightBookingContext.Bookings.
                Where(x => x.Id == BookingId).FirstOrDefault();
            booking.Flight = _flightBookingContext.Inventories.Where(x => x.Id == booking.FlightId)
                .FirstOrDefault();
            return booking;
        }


        public List<BookingModel> GetActiveBookingList(long UserID)
        {
            List<BookingModel> bookingList = new List<BookingModel>();
            List<Booking> bookings = _flightBookingContext.Bookings.Where(x => x.UserId == UserID).ToList();
            foreach (Booking obj in bookings)
            {
                BookingModel booking = new BookingModel();
                obj.Flight = _flightBookingContext.Inventories.Where(x => x.Id == obj.FlightId).FirstOrDefault();
                booking.UserId = obj.UserId;
                booking.BookedSeats = obj.BookedSeats;
                booking.FlightName = obj.Flight.AirlineName;
                booking.Pnrno = obj.Pnrno;
                booking.Total = obj.Total;
                booking.FlightId = obj.FlightId;
                booking.IsCancelled = obj.IsCancelled;
                booking.ScheduledDate = obj.Flight.ScheduledDate;
                booking.StartPoint = obj.Flight.StartPoint;
                booking.EndPoint = obj.Flight.EndPoint;
                booking.Id = obj.Id;
                booking.CreatedDate = obj.CreatedOn;
                bookingList.Add(booking);
            }
            return bookingList;
        }

    }
}
