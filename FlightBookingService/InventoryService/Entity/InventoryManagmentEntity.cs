using DAL.Models;
using InventoryService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Entity
{
    public class InventoryManagmentEntity
    {
        FlightBookingContext _flightBookingContext = new FlightBookingContext();

        public List<Inventory> GetAllFLightList()
        {
            return _flightBookingContext.Inventories.Where(x => x.IsAvailable).ToList();
        }

        public List<Inventory> GetSearchedFLightList(FlightModel flightModel)
        {
            List<Inventory> inventoryList = _flightBookingContext.Inventories.
                Where(x => x.IsAvailable && x.StartPoint == flightModel.StartPoint &&
                x.EndPoint == flightModel.EndPoint).ToList();
            return inventoryList;
        }

        public Inventory AddUpdateFlight(Inventory inventory)
        {
            if (inventory.Id == 0)
            {
                _flightBookingContext.Add(inventory);
            }
            else
            {
                _flightBookingContext.Entry(inventory).CurrentValues.SetValues(inventory);
            }
            _flightBookingContext.SaveChanges();
            return inventory;
        }

        public void BlockFlight(long FlightID)
        {
            Inventory inventory = _flightBookingContext.Inventories.Where(x => x.Id == FlightID).FirstOrDefault();
            inventory.IsAvailable = false;
            _flightBookingContext.SaveChanges();
        }

        public Inventory GetFlightByID(long FlightID)
        {
            Inventory inventory = _flightBookingContext.Inventories.Where(x => x.Id == FlightID).FirstOrDefault();
            return inventory;
        }
    }
}
