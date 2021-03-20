using FortCode.Interfaces;
using FortCode.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.BAL
{
    public class CityBAL : ICityBAL
    {
        private readonly ICityDAL _dbCityDalHelper;

        public CityBAL(ICityDAL CityDalHelper)
        {
            if (this._dbCityDalHelper == null)
                this._dbCityDalHelper = CityDalHelper;
        }
        public dynamic addCity(CityModel obj)
        {
            dynamic objdata = new ExpandoObject();
            try
            {
                int result = _dbCityDalHelper.addCity(obj);
                if (result > 0)
                {
                    objdata.success = true;
                    objdata.message = "City Added Successfully !!!";
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

        public dynamic deleteCity(CityModel obj)
        {
            dynamic objdata = new ExpandoObject();
            try
            {
                int result = _dbCityDalHelper.deleteCity(obj);
                if (result > 0)
                {
                    objdata.success = true;
                    objdata.message = "City Deleted Successfully !!!";
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

        public List<CityModel> getCityList()
        {
            List<CityModel> cityList = new List<CityModel>();
            try
            {
                cityList = _dbCityDalHelper.getCityList();
                if (cityList != null)
                {
                    return cityList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cityList;
        }
    }
}
