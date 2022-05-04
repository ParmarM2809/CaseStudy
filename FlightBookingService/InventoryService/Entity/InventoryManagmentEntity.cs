using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Entity
{
    public class InventoryManagmentEntity
    {
        FlightBookingContext _flightBookingContext;

        public InventoryManagmentEntity()
        {
        }

        public InventoryManagmentEntity(FlightBookingContext flightBookingContext)
        {
            _flightBookingContext = flightBookingContext;
        }

        public List<Inventory> GetAllFLightList()
        {
            return _flightBookingContext.Inventories.Where(x=>x.IsAvailable).ToList();
        }
    }
}
