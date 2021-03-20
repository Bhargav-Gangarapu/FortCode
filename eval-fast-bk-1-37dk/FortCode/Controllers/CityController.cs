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
    public class CityController : ControllerBase
    {
        private readonly ICityBAL _city;
        private readonly IUserLoginBAL _user;
        public CityController(ICityBAL city,IUserLoginBAL user)
        {
            if (this._city == null)
                this._city = city;
            if (this._user == null)
                this._user = user;
        }

        [Route("addCity")]
        [HttpPost]
        public dynamic addCity(dynamic data)
        {
            dynamic objdata = new ExpandoObject();
            string serializedObject = string.Empty;
            try
            {
                UserLogin objUser = new UserLogin();
                objUser.Email = Request.Headers["Email"];
                objUser.Password = Request.Headers["Password"];
                var objVal = _user.CheckloginUser(objUser);
                
                if (objVal.success == true)
                {
                    serializedObject = JsonSerializer.Serialize(data);
                    CityModel rootobj = JsonSerializer.Deserialize<CityModel>(serializedObject);
                    return Ok(_city.addCity(rootobj));
                }
                return Ok(objVal);
            }
            catch (Exception ex)
            {
                objdata.success = false;
                objdata.result = "";
                objdata.message = ex.Message.ToString();
                throw;
            }
        }

        [Route("deleteCity")]
        [HttpDelete]
        public dynamic deleteCity(dynamic data)
        {
            dynamic objdata = new ExpandoObject();
            string serializedObject = string.Empty;
            try
            {
                UserLogin objUser = new UserLogin();
                objUser.Email = Request.Headers["Email"];
                objUser.Password = Request.Headers["Password"];
                var objVal = _user.CheckloginUser(objUser);
                
                if(objVal.success == true)
                {
                    serializedObject = JsonSerializer.Serialize(data);
                    CityModel rootobj = JsonSerializer.Deserialize<CityModel>(serializedObject);
                    return Ok(_city.deleteCity(rootobj));
                }
                return Ok(objVal);
            }
            catch (Exception ex)
            {
                objdata.success = false;
                objdata.message = ex.Message.ToString();
                throw;
            }
        }

        [Route("getCityList")]
        [HttpGet]
        public dynamic getCityList()
        {            
            dynamic objdata = new ExpandoObject();
            List<CityModel> cityList = new List<CityModel>();
            try
            {
                UserLogin objUser = new UserLogin();
                objUser.Email = Request.Headers["Email"];
                objUser.Password = Request.Headers["Password"];
                var objVal = _user.CheckloginUser(objUser);
                
                if(objVal.success == true)
                {
                    cityList = _city.getCityList();
                    if (cityList != null)
                    {
                        objdata.success = true;
                        objdata.result = cityList;
                    }
                    else
                    {
                        objdata.success = false;
                        objdata.message = "No data found...";
                    }
                }
                else
                {
                    objdata.success = false;
                    objdata.message = "Not an Authorized User";
                }
            }
            catch (Exception ex)
            {
                objdata.success = false;
                objdata.message = ex.Message.ToString();
                throw;
            }
            return objdata;
        }
    }
}
