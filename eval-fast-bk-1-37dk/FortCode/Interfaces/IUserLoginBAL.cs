using FortCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.Interfaces
{
    public interface IUserLoginBAL
    {
        dynamic createUser(UserLogin user);
        dynamic CheckloginUser(UserLogin user);
    }
}
