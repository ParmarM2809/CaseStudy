
using APIGateway.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public class AuthorizationService
    {
        FlightBookingContext _flightBookingContext = new FlightBookingContext();


        public UserMaster IsUserValid(AuthUser authUser)
        {
            UserMaster userMaster = _flightBookingContext.UserMasters.Where(x => x.Email == authUser.Email
             && x.Password == authUser.Password).FirstOrDefault();
            return userMaster;

        }
    }
}
