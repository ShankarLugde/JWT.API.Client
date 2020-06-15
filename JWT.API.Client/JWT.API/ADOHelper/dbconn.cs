using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JWT.API.ADOHelper
{
    public class dbconn
    {
        private SqlConnection con;
        private string constr = string.Empty;
        public dbconn()
        {
            con = new SqlConnection();
            constr = ConfigurationManager.ConnectionStrings["MyConnection"].ToString();
            con.ConnectionString = constr;
        }



        //gedata using data table
        public void GetDataTable(SqlCommand cmd, ref DataTable dt)
        {

            try
            {
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    con.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        //GetData Using DataSet
        public void GetDataSet(SqlCommand cmd, ref DataSet ds)
        {
            try
            {
                cmd.Connection = con;
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                    con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }


        }

        //to execute command on database
        public int ExecuteNonQuery(SqlCommand cmd)
        {
            int r = 0;
            cmd.Connection = con;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return r;
        }


        //
        //to execute command on database
        public bool ExecuteScalar(SqlCommand cmd)
        {
            int r = 0;
            cmd.Connection = con;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                r = Convert.ToInt16(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            if (r == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }



        //To Execute Array 
        public void ExecuteArrayCommand(ArrayList aList)
        {
            SqlTransaction tran;

            if (con.State != ConnectionState.Open)
            {
                con.Open();

            }
            tran = con.BeginTransaction();
            try
            {
                for (int i = 0; i < aList.Count; i++)
                {
                    SqlCommand cmd = (SqlCommand)aList[i];
                    cmd.CommandTimeout = 600;
                    cmd.Connection = con;
                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}