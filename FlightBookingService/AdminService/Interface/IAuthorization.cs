using AdminService.ViewModel;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Interface
{
    public interface IAuthorization
    {
        UserMaster IsAdminValid(User UserModel);
    }
}
