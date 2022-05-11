using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Entity;
using UserService.ViewModel;
using Utility;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        [HttpPost]
        [Route("AddUpdateFlightBooking")]
        public ResultObject AddUpdateFlightBooking(BookingModel booking)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                if (!ModelState.IsValid)
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.NotFound);
                    return resultObject;
                }
                BookingEntity bookingEntity = new BookingEntity();
                if (booking.Id > 0 && bookingEntity.UpdateAligiability(booking.UserId, booking.Pnrno) == false)
                {
                    resultObject = new ResultObject(APIResponseMessage.UpdateTimePassed, StatusType.Success);
                    return resultObject;
                }
                bookingEntity.AddUpdateBooking(booking);
                resultObject = new ResultObject(APIResponseMessage.DataSaved, StatusType.Success);

            }
            catch (Exception ex)
            {
                resultObject = new ResultObject(APIResponseMessage.SomethingWrong, StatusType.Error);
                resultObject.ExceptionMessage = ex.Message;
                resultObject.ExceptionStackTrace = ex.StackTrace;
                resultObject.ResultException = ex.InnerException;
            }
            return resultObject;
        }


        [HttpGet]
        [Route("GetBookingBySearch/{UserID}/{Pnrno}")]
        public ResultObject GetFlightByID(long UserID, string Pnrno)
        {
            ResultObject resultObject = new ResultObject();

            try
            {
                if (UserID == 0 || string.IsNullOrEmpty(Pnrno))
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.Error);
                    return resultObject;
                }
                Booking booking = new BookingEntity().GetFlightByID(UserID, Pnrno);
                resultObject = booking == null ?
                    new ResultObject(APIResponseMessage.DataNotFound, StatusType.Error) :
                    new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                resultObject.ResultData = booking;
            }
            catch (Exception ex)
            {
                resultObject = new ResultObject(APIResponseMessage.SomethingWrong, StatusType.Error);
                resultObject.ExceptionMessage = ex.Message;
                resultObject.ExceptionStackTrace = ex.StackTrace;
                resultObject.ResultException = ex.InnerException;
            }
            return resultObject;
        }

        [HttpGet]
        [Route("GetActiveBookingList/{UserID}")]
        public ResultObject GetActiveBookingList(long UserID)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                List<Booking> bookings = new BookingEntity().GetActiveBookingList(UserID);
                resultObject = bookings == null ?
                    new ResultObject(APIResponseMessage.DataNotFound, StatusType.NotFound)
                    : new ResultObject(APIResponseMessage.DataFound, StatusType.NotFound);
                resultObject.ResultData = bookings;
            }
            catch (Exception ex)
            {
                resultObject = new ResultObject(APIResponseMessage.SomethingWrong, StatusType.Error);
                resultObject.ExceptionMessage = ex.Message;
                resultObject.ExceptionStackTrace = ex.StackTrace;
                resultObject.ResultException = ex.InnerException;
            }
            return resultObject;
        }



    }
}
