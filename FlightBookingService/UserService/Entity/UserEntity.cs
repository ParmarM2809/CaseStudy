using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.ViewModel;
using Utility;

namespace UserService.Entity
{
    public class UserEntity
    {
        FlightBookingContext _flightBookingContext = new FlightBookingContext();

        public void AddUser(UserModel userModel)
        {
            UserMaster userMaster = new UserMaster();
            userMaster.Email = userModel.Email;
            userMaster.Password = userModel.Password;
            userMaster.UserName = userModel.UserName;
            userMaster.RoleId = (int)RoleID.User;
            userMaster.CreatedOn = Convert.ToString(DateTime.Now);
            userMaster.UpdatedOn = Convert.ToString(DateTime.Now);
            _flightBookingContext.Add(userMaster);
            _flightBookingContext.SaveChanges();
        }
    }
}
