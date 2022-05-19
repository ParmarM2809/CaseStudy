﻿using DAL.Models;
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

        public List<Airline> AvailableAirLine()
        {
            return _flightBookingContext.Airlines.ToList();
        }

        public List<ServiceCity> AvailableCity()
        {
            return _flightBookingContext.ServiceCities.ToList();
        }

        public List<Inventory> GetSearchedFlightList(string SearchText)
        {
            List<Inventory> inventoryList = _flightBookingContext.Inventories.
                Where(x => x.IsAvailable && x.StartPoint.Contains(SearchText) ||
                x.EndPoint.Contains(SearchText)).ToList();
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
            inventory.UpdatedDate = DateTime.Now;
            inventory.ScheduledDate = flightModel.ScheduledDate; 
            inventory.SeatAvaibility = flightModel.SeatAvaibility;
            if (inventory.Id == 0)
            {
                inventory.CreatedDate = DateTime.Now;
                _flightBookingContext.Add(inventory);
            }
            else
            {
                _flightBookingContext.Entry(inventory).State = EntityState.Detached;
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
