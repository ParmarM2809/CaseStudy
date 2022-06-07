using DAL.Models;
using InventoryService.Entity;
using InventoryService.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Utility;

namespace InventoryService.Controllers
{
    [Route("api/Flight")]
    [ApiController]
    public class FlightManagmentController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllFlightList")]
        public IActionResult GetAllFlightList()
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                List<Inventory> inventoryList = new InventoryManagmentEntity().GetAllFLightList();
                resultObject = inventoryList == null ?
                    new ResultObject(APIResponseMessage.DataNotFound, StatusType.NotFound)
                    : new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                resultObject.ResultData = inventoryList;
                return Ok(inventoryList);
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
        [Route("GetSearchedFlightList/{SearchText}")]
        public IActionResult GetSearchedFlightList(string SearchText)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                List<Inventory> inventoryList = new List<Inventory>();
                if (!ModelState.IsValid)
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.NotFound);
                    resultObject.ResultData = inventoryList;
                    return NotFound();
                }
                else
                {
                    inventoryList = new InventoryManagmentEntity().GetSearchedFlightList(SearchText);
                    resultObject = inventoryList == null ?
                                    new ResultObject(APIResponseMessage.DataNotFound, StatusType.NotFound)
                                    : new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                    return Ok(inventoryList);
                }
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

        [HttpPost]
        [Route("AddUpdateFlight")]
        public IActionResult AddUpdateFlight(FlightModel flightModel)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                if (!ModelState.IsValid)
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.NotFound);
                    return NotFound();
                }
                new InventoryManagmentEntity().AddUpdateFlight(flightModel);
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

        [HttpPost]
        [Route("BlockFlight/{FlightID}")]
        public ResultObject BlockFlight(long FlightID)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                if (FlightID <= 0)
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.Error);
                    return resultObject;
                }
                new InventoryManagmentEntity().BlockFlight(FlightID);
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
        [Route("GetFlightByID/{FlightID}")]
        public IActionResult GetFlightByID(long FlightID)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                if (FlightID <= 0)
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.Error);
                    return NotFound(APIResponseMessage.DataNotValid);
                }
                Inventory inventory = new InventoryManagmentEntity().GetFlightByID(FlightID);
                resultObject = inventory == null ?
                    new ResultObject(APIResponseMessage.DataNotFound, StatusType.Error) :
                    new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                return Ok(inventory);
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
        [Route("AvailableAirline")]
        public IActionResult AvailableAirline()
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                List<Airline> airlines = new InventoryManagmentEntity().AvailableAirLine();
                resultObject = new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                return Ok(airlines);

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
        [Route("ServiceCity")]
        public IActionResult ServiceCity()
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                List<ServiceCity> serviceCities = new InventoryManagmentEntity().AvailableCity();
                resultObject = new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                return Ok(serviceCities);

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
        [Route("BookingList/{Date}")]
        public IActionResult BookingList(string Date)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                List<BookingModel> serviceCities = new InventoryManagmentEntity().BookingList(Convert.ToDateTime(Date));
                resultObject = new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                return Ok(serviceCities);

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

    }
}
