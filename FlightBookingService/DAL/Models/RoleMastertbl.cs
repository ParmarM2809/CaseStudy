using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class RoleMastertbl
    {
        public RoleMastertbl()
        {
            UserMasters = new HashSet<UserMaster>();
        }

        public long RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserMaster> UserMasters { get; set; }
    }
}
