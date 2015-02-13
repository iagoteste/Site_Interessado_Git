using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Site_Interessado.app_code
{
    public static class Contexto
    {
        //return dataset
        public static DataSet getdata(string sqlquery)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
           
            return ds;
        }

        //return DataTable
        public static DataTable getdataTable(string sqlquery)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
         
            return ds.Tables[0];
        }

        //Insert com id de retorno 
        public static string insertGetIdentity(string sql)
        {
            string res = "";
            try
            {
                SqlConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);

                //dbcon.ConnectionString = HttpContext.Current.Session["connString"].ToString();
                dbcon.Open();

                SqlCommand db_dados = dbcon.CreateCommand();

                db_dados.CommandText = sql + ";select @@identity as ID";
                SqlDataReader rd_dados = db_dados.ExecuteReader();

                if (rd_dados.Read())
                {
                    res = rd_dados["ID"].ToString();
                }


                rd_dados.Close();

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

          

            return res;
        }
    }//
}//