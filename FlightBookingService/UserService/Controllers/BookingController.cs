using Confluent.Kafka;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Entity;
using UserService.ViewModel;
using Utility;

namespace UserService.Controllers
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        ProducerConfig _producerConfig;

        public BookingController(ProducerConfig producerConfig)
        {
            _producerConfig = producerConfig;
        }

        [HttpPost]
        [Route("AddUpdateFlightBooking")]
        public async Task<IActionResult> AddUpdateFlightBooking(BookingModel booking)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.NotFound);
                //    return resultObject;
                //}
                BookingEntity bookingEntity = new BookingEntity();
                if (booking.Id > 0 && bookingEntity.UpdateAligiability(booking.UserId, booking.Pnrno) == false)
                {
                    resultObject = new ResultObject(APIResponseMessage.UpdateTimePassed, StatusType.Success);
                    return NotFound();
                }
                bookingEntity.AddUpdateBooking(booking);
                resultObject = new ResultObject(APIResponseMessage.DataSaved, StatusType.Success);
                return Ok();
            }
            catch (Exception ex)
            {
                resultObject = new ResultObject(APIResponseMessage.SomethingWrong, StatusType.Error);
                resultObject.ExceptionMessage = ex.Message;
                resultObject.ExceptionStackTrace = ex.StackTrace;
                resultObject.ResultException = ex.InnerException;
                return NotFound();
            }
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
        public IActionResult GetActiveBookingList(long UserID)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                List<BookingModel> bookings = new BookingEntity().GetActiveBookingList(UserID);
                resultObject = bookings == null ?
                    new ResultObject(APIResponseMessage.DataNotFound, StatusType.NotFound)
                    : new ResultObject(APIResponseMessage.DataFound, StatusType.NotFound);
                resultObject.ResultData = bookings;
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                resultObject = new ResultObject(APIResponseMessage.SomethingWrong, StatusType.Error);
                resultObject.ExceptionMessage = ex.Message;
                resultObject.ExceptionStackTrace = ex.StackTrace;
                resultObject.ResultException = ex.InnerException;
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetBookingById/{BookingId}")]
        public IActionResult GetBookingById(long BookingId)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                if (BookingId == 0 )
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.Error);
                    return NotFound();
                }
                Booking booking = new BookingEntity().GetBookingByID(BookingId);
                resultObject = booking == null ?
                    new ResultObject(APIResponseMessage.DataNotFound, StatusType.Error) :
                    new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                resultObject.ResultData = booking;
                return Ok(booking);
            }
            catch (Exception ex)
            {
                resultObject = new ResultObject(APIResponseMessage.SomethingWrong, StatusType.Error);
                resultObject.ExceptionMessage = ex.Message;
                resultObject.ExceptionStackTrace = ex.StackTrace;
                resultObject.ResultException = ex.InnerException;
                return NotFound();
            }
        }

        //public async Task<ActionResult> Get(string Topic , [FromBody]Employee employee)
        //{
        //    var EmpData = JsonConvert.SerializeObject(employee);
        //    using (var producer = new ProducerConfig<Null, string>(_producerConfig).Buid())
        //    {
        //        await producer.Pro
        //    }
        //}

    }
}
