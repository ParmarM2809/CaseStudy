using AdminService.ViewModel;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace AdminService.Entity
{
    public class UserManagmentEntity
    {
        FlightBookingContext _flightBookingContext = new FlightBookingContext();


        public List<UserMaster> UserList()
        {
            List<UserMaster> userMasterList =
                _flightBookingContext.UserMasters.Where(x => x.RoleId == 2).ToList();
            return userMasterList;
        }

    }
}
