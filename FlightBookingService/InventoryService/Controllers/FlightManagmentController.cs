using DAL.Models;
using InventoryService.Entity;
using InventoryService.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace InventoryService.Controllers
{
    [Route("api/Flight")]
    [ApiController]
    public class FlightManagmentController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllFlightList")]
        public ResultObject GetAllFlightList()
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                List<Inventory> inventoryList = new InventoryManagmentEntity().GetAllFLightList();
                resultObject = inventoryList == null ?
                    new ResultObject(APIResponseMessage.DataNotFound, StatusType.NotFound)
                    : new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                resultObject.ResultData = inventoryList;
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

        [HttpPost]
        [Route("GetSearchedFlightList")]
        public ResultObject GetSearchedFlightList(FlightModel flightModel)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                List<Inventory> inventoryList = new List<Inventory>();
                if (!ModelState.IsValid)
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.NotFound);
                    resultObject.ResultData = inventoryList;
                }
                else
                {
                    inventoryList = new InventoryManagmentEntity().GetSearchedFlightList(flightModel);
                    resultObject = inventoryList == null ?
                                    new ResultObject(APIResponseMessage.DataNotFound, StatusType.NotFound)
                                    : new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                }
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

        [HttpPost]
        [Route("AddUpdateFlight")]
        public ResultObject AddUpdateFlight(FlightModel flightModel)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                if (!ModelState.IsValid)
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.NotFound);
                    return resultObject;
                }
                new InventoryManagmentEntity().AddUpdateFlight(flightModel);
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
        public ResultObject GetFlightByID(long FlightID)
        {
            ResultObject resultObject = new ResultObject();

            try
            {
                if (FlightID <= 0)
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.Error);
                    return resultObject;
                }
                Inventory inventory = new InventoryManagmentEntity().GetFlightByID(FlightID);
                resultObject = inventory == null ?
                    new ResultObject(APIResponseMessage.DataNotFound, StatusType.Error) :
                    new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                resultObject.ResultData = inventory;
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
