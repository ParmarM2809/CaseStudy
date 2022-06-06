using AdminService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Interface
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User user);
    }
}
