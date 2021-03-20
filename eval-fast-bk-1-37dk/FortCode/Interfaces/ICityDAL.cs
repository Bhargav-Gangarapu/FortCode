using FortCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.Interfaces
{
    public interface ICityDAL
    {
        int addCity(CityModel obj);
        int deleteCity(CityModel obj);
        List<CityModel> getCityList();
    }
}
