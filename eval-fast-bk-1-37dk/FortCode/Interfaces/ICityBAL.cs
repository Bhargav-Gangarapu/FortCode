using FortCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.Interfaces
{
    public interface ICityBAL
    {
        dynamic addCity(CityModel obj);
        dynamic deleteCity(CityModel obj);
        List<CityModel> getCityList();
    }
}
