using DAL.Models;
using InventoryService.Entity;
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
        public List<Inventory> GetAllFlightList()
        {
            List<Inventory> inventoryList = new InventoryManagmentEntity().GetAllFLightList();
            return inventoryList;
        }
    }
}
