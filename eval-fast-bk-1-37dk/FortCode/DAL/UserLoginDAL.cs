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
    public class UserLoginDAL : IUserLoginDAL
    {
        private readonly IutilsHelper _utils;
        public UserLoginDAL(IutilsHelper utilithelpr)
        {
            if (this._utils == null)
                this._utils = utilithelpr;
        }
        public int createUser(UserLogin user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _utils.Connection_string;
                    string sqlText = "insert into tblUser(Name,Email,Password)values(@name,@email,@password)";
                    SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
                    sqlCmd.Parameters.AddWithValue("@name", user.Name);
                    sqlCmd.Parameters.AddWithValue("@email", user.Email);
                    sqlCmd.Parameters.AddWithValue("@password", user.Password);
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

        public DataTable CheckloginUser(UserLogin user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = _utils.Connection_string;
                    string sqlText = "select * from tblUser where Email=@email and Password=@password";
                    SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
                    sqlCmd.Parameters.AddWithValue("@email", user.Email);
                    sqlCmd.Parameters.AddWithValue("@password", user.Password);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter oda = new SqlDataAdapter(sqlCmd);
                    oda.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
