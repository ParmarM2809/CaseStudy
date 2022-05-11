using DAL.Models;
using InventoryService.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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

        public List<Inventory> GetSearchedFlightList(FlightModel flightModel)
        {
            List<Inventory> inventoryList = _flightBookingContext.Inventories.
                Where(x => x.IsAvailable && x.StartPoint == flightModel.StartPoint &&
                x.EndPoint == flightModel.EndPoint).ToList();
            return inventoryList;
        }

        public Inventory AddUpdateFlight(FlightModel flightModel)
        {
            Inventory inventory = new Inventory();
            inventory.AirlineName = flightModel.AirlineName;
            inventory.ContactName = flightModel.ContactName;
            inventory.ContactNumber = flightModel.ContactNumber;
            inventory.EndPoint = flightModel.EndPoint;
            inventory.IsAvailable = flightModel.IsAvailable;
            inventory.Id = flightModel.Id;
            inventory.IsDiscountAvailable= flightModel.IsDiscountAvailable;
            inventory.Price = flightModel.Price;
            inventory.StartPoint = flightModel.StartPoint;
            if (inventory.Id == 0)
            {
                _flightBookingContext.Add(inventory);
            }
            else
            {
                _flightBookingContext.Entry(inventory).State = EntityState.Modified;
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
