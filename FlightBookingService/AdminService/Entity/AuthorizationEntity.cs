using AdminService.ViewModel;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Entity
{
    public class AuthorizationEntity
    {
        FlightBookingContext _flightBookingContext;

        public AuthorizationEntity()
        {
        }

        public AuthorizationEntity(FlightBookingContext flightBookingContext)
        {
            _flightBookingContext = flightBookingContext;
        }

        public bool IsAdminValid(User UserModel)
        {
            UserMaster userMaster = _flightBookingContext.UserMasters.Where(x => x.Email == UserModel.Email
             && x.Password == UserModel.Password).FirstOrDefault();
            if (userMaster == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
