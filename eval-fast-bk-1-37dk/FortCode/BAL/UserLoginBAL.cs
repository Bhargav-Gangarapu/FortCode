using FortCode.Interfaces;
using FortCode.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.BAL
{
    public class UserLoginBAL : IUserLoginBAL
    {
        private readonly IUserLoginDAL dbUserDalHelper;

        public UserLoginBAL(IUserLoginDAL UserDalHelper)
        {
            if (this.dbUserDalHelper == null)
                this.dbUserDalHelper = UserDalHelper;
        }

        public dynamic CheckloginUser(UserLogin user)
        {
            dynamic objdata = new ExpandoObject();
            DataTable dt = dbUserDalHelper.CheckloginUser(user);
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    objdata.success = true;
                    objdata.message = "User Login Successfull !!!";
                }
                else
                {
                    objdata.success = false;
                    objdata.message = "Not an Authorized User";
                }
                return objdata;
            }
            catch (Exception ex)
            {
                objdata.success = false;
                objdata.message = ex.Message.ToString();
                throw;
            }
        }

        public dynamic createUser(UserLogin user)
        {
            dynamic objdata = new ExpandoObject();
            try
            {
                int result = dbUserDalHelper.createUser(user);
                if (result > 0)
                {
                    objdata.success = true;
                    objdata.message = "User Created Successfully !!!";
                }
                else
                {
                    objdata.success = false;
                    objdata.message = "Something Went Wrong !!!";
                }
                return objdata;
            }
            catch (Exception ex)
            {
                objdata.success = false;
                objdata.message = ex.Message.ToString();
                throw;
            }
        }
    }
}
