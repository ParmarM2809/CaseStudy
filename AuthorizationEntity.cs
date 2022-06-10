using AdminService.Interface;
using AdminService.ViewModel;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Entity
{
    public class AuthorizationEntity : IAuthorization
    {
        FlightBookingContext _flightBookingContext = new FlightBookingContext();


        public UserMaster IsAdminValid(User UserModel)
        {
            UserMaster userMaster = _flightBookingContext.UserMasters.Where(x => x.Email == UserModel.Email
             && x.Password == UserModel.Password).FirstOrDefault();
            return userMaster;

        }
    }
}
