using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MondayAlert.Models;
using System.Data.SqlClient;
using System.Data;

namespace MondayAlert.Class
{
    public class Authentication
    {
        public bool LoginUser(LoginViewModel model)
        {

            try
            {
                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GET_GetLoginByUserName";
                cmd.Parameters.AddWithValue("@userName", model.Email);
                cmd.Parameters.AddWithValue("@password", model.Password);

                DataTable tbl = db.GetData(cmd);

                if (tbl.Rows[0][0].ToString() == "1") { return true; }
                else { return false; }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}