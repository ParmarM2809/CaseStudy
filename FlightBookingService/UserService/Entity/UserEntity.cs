using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace UserService.Entity
{
    public class UserEntity
    {
        FlightBookingContext _flightBookingContext = new FlightBookingContext();

        public void AddUser(UserMaster userMaster)
        {
            userMaster.RoleId = (int)RoleID.User;
            _flightBookingContext.Add(userMaster);
            _flightBookingContext.SaveChanges();
        }
    }
}
