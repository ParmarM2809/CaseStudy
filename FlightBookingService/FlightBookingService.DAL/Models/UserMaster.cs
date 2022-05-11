using System;
using System.Collections.Generic;

#nullable disable

namespace FlightBookingService.DAL.Models
{
    public partial class UserMaster
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }

        public virtual RoleMastertbl Role { get; set; }
    }
}
