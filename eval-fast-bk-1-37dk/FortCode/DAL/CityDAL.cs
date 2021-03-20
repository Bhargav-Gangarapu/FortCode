using FortCode.Interfaces;
using FortCode.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.DAL
{
    public class CityDAL : ICityDAL
    {
        private readonly IutilsHelper _utils;
        public CityDAL(IutilsHelper utilithelpr)
        {
            if (this._utils == null)
                this._utils = utilithelpr;
        }

        public int addCity(CityModel obj)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _utils.Connection_string;
                    string sqlText = "insert into tblCity(CityName,Country)values(@cityname,@country)";
                    SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
                    sqlCmd.Parameters.AddWithValue("@cityname", obj.CityName);
                    sqlCmd.Parameters.AddWithValue("@country", obj.Country);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    int i = sqlCmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteCity(CityModel obj)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _utils.Connection_string;
                    string sqlText = "Delete from tblCity where CityId = @cityid";
                    SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
                    sqlCmd.Parameters.AddWithValue("@cityid", obj.cityId);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    int i = sqlCmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CityModel> getCityList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _utils.Connection_string;
                    string sqlText = "Select * from tblCity";
                    SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter oda = new SqlDataAdapter(sqlCmd);
                    oda.Fill(dt);
                    List<CityModel> cityList = new List<CityModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CityModel city = new CityModel();
                        city.cityId = Convert.ToInt32(dt.Rows[i]["cityId"]);
                        city.CityName = dt.Rows[i]["CityName"].ToString();
                        city.Country = dt.Rows[i]["Country"].ToString();
                        cityList.Add(city);
                    }
                    conn.Close();
                    return cityList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
