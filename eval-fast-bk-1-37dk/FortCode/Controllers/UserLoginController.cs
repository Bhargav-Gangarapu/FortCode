using FortCode.Interfaces;
using FortCode.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FortCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginBAL _user;
        public UserLoginController(IUserLoginBAL user)
        {
            if (this._user == null)
                this._user = user;
        }

        [Route("registerUser")]
        [HttpPost]
        public dynamic registerUser(dynamic data)
        {
            dynamic objdata = new ExpandoObject();
            string serializedObject = string.Empty;
            try
            {
                serializedObject = JsonSerializer.Serialize(data);
                UserLogin rootobj = JsonSerializer.Deserialize<UserLogin>(serializedObject);
                return Ok(_user.createUser(rootobj));
            }
            catch (Exception ex)
            {
                objdata.success = false;
                objdata.result = "";
                objdata.message = ex.Message.ToString();
                throw;
            }
        }

        [Route("checkloginUser")]
        [HttpPost]
        public dynamic checkloginUser()
        {
            UserLogin objUser = new UserLogin();
            string serialized_data = string.Empty;
            try
            {
                objUser.Email = Request.Headers["Email"];
                objUser.Password = Request.Headers["Password"];
                var obj = _user.CheckloginUser(objUser);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[Route("checkloginUser")]
        //[HttpPost]
        //public dynamic checkloginUser(dynamic data)
        //{
        //    dynamic objdata = new ExpandoObject();
        //    string serialized_data = string.Empty;
        //    try
        //    {
        //        serialized_data = JsonSerializer.Serialize(data);
        //        UserLogin rootobj = JsonSerializer.Deserialize<UserLogin>(serialized_data);
        //        var obj = _user.CheckloginUser(rootobj);
        //        return Ok(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        objdata.success = false;
        //        objdata.result = "";
        //        objdata.message = ex.Message.ToString();
        //        throw;
        //    }
        //}
    }
}
