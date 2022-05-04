using DAL.Models;
using InventoryService.Entity;
using InventoryService.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Controllers
{
    [Route("api/Flight")]
    [ApiController]
    public class FlightManagmentController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllFlightList")]
        public List<Inventory> GetAllFlightList()
        {
            List<Inventory> inventoryList = new InventoryManagmentEntity().GetAllFLightList();
            return inventoryList;
        }

        [HttpPost]
        [Route("GetSearchedFlightList")]
        public List<Inventory> GetSearchedFlightList(FlightModel flightModel)
        {
            List<Inventory> inventoryList = new List<Inventory>();
            if (ModelState.IsValid)
            {
                inventoryList = new InventoryManagmentEntity().GetSearchedFLightList(flightModel);
            }
            return inventoryList;
        }
        [HttpPost]
        [Route("AddUpdateFlight")]
        public IActionResult AddUpdateFlight(Inventory inventory)
        {
            new InventoryManagmentEntity().AddUpdateFlight(inventory);
            return Ok();
        }

        [HttpPost]
        [Route("BlockFlight/{FlightID}")]
        public IActionResult BlockFlight(long FlightID)
        {
            new InventoryManagmentEntity().BlockFlight(FlightID);
            return Ok();
        }

        [HttpGet]
        [Route("GetFlightByID/{FlightID}")]
        public IActionResult GetFlightByID(long FlightID)
        {
            Inventory inventory = new InventoryManagmentEntity().GetFlightByID(FlightID);
            return Ok(inventory);
        }

    }
}
