using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using JWT.API.Models;

namespace JWT.API.ADOHelper
{
    public class EmployeeHelper
    {
        dbconn objdb = new dbconn();

        public int Ins_Emp(Employee emp)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_EMP";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Activity", "INS");
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@EmailId", emp.EmailId);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@DateOfBirth", emp.DateOfBirth);
            return _ = objdb.ExecuteNonQuery(cmd);
        }
        public int Upd_Emp(Employee emp)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_EMP";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Activity", "UPD");
            cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@EmailId", emp.EmailId);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@DateOfBirth", emp.DateOfBirth);
            return _ = objdb.ExecuteNonQuery(cmd);
        }
        public int Del_Emp(int EmpId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_EMP";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Activity", "DEL");
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            return _ = objdb.ExecuteNonQuery(cmd);
        }
        public List<Employee> Get_Emp(Employee emp)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_EMP";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Activity", "GET");
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@EmailId", emp.EmailId);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@DateOfBirth", emp.DateOfBirth);
            objdb.GetDataTable(cmd, ref dt);

            return Utilities.ConvertDataTableToList.ConvertToDataTable<Employee>(dt);
        }
    }
}