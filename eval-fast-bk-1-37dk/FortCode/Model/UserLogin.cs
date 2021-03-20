using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.Model
{
    public class UserLogin
    {
        #region "Propeties"
        public int userId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion
    }
}
