using JWT.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JWT.API.ADOHelper
{
    public class LoginHelper
    {
        dbconn objdb = new dbconn();
        public DataTable Validate_User(Login login)
        {
            DataTable dt = new DataTable();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "User_Login";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.AddWithValue("@UserName", login.UserName);
            objSqlCommand.Parameters.AddWithValue("@Password", login.Password);
            objdb.GetDataTable(objSqlCommand, ref dt);
            return dt;
        }
    }
}