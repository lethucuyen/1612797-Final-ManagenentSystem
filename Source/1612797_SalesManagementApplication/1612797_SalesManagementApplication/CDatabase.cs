using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//<add using>
using System.Data.SqlClient;//local db
using System.Data;//ConnectionState, DataTable
//</add using>

namespace _1612797_SalesManagementApplication
{
    class CDatabase
    {

        //
        public static SqlConnection Get_Database_Connection()
        {
            string cnString = Properties.Settings.Default.connString;
            SqlConnection cn = new SqlConnection(cnString);

            //
            if (cn.State != ConnectionState.Open)
                cn.Open();

            //
            return cn;

        }

        //
        public static DataTable Get_Data_Table(string sqlText)
        {
            SqlConnection cn = Get_Database_Connection();

            //
            DataTable tb = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(sqlText, cn);
            ad.Fill(tb);

            return tb;
        }

        public static void Execute_SQL(string sqlText)
        {
            SqlConnection cn = Get_Database_Connection();

            //
            SqlCommand cmd = new SqlCommand(sqlText, cn);
            cmd.ExecuteNonQuery();
        }

        //
        public static void Close_Database_Connection()
        {
            string cnString = Properties.Settings.Default.connString;
            SqlConnection cn = new SqlConnection(cnString);

            if (cn.State != ConnectionState.Closed)
                cn.Close();
        }

    }
}
