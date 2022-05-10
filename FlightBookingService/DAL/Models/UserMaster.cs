using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class UserMaster
    {
        public UserMaster()
        {
            Bookings = new HashSet<Booking>();
        }

        public long UserId { get; set; }
        public long RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Token { get; set; }

        public virtual RoleMastertbl Role { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
