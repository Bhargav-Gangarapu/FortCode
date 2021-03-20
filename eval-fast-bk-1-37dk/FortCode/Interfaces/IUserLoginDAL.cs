using FortCode.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.Interfaces
{
    public interface IUserLoginDAL
    {
        int createUser(UserLogin user);
        DataTable CheckloginUser(UserLogin user);
    }
}
