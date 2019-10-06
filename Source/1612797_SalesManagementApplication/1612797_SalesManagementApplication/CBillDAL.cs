using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using System.Data.SqlClient;//local db
using System.Data;//ConnectionState, DataTable

namespace _1612797_SalesManagementApplication
{
    class CBillDAL
    {

        static string cnString = Properties.Settings.Default.connString;

        public DataTable Select()
        {
            SqlConnection cn = new SqlConnection(cnString);
            cn = CDatabase.Get_Database_Connection();

            DataTable tb = new DataTable();

            try
            {
                string sqlText = "SELECT * from HOA_DON";
                tb = CDatabase.Get_Data_Table(sqlText);

                CDatabase.Execute_SQL(sqlText);
                //MyDataGrid_SP.DataContext = tb.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
            finally
            {
                CDatabase.Close_Database_Connection();
            }
            return tb;
        }

        public bool Insert(CBillBLL p)
        {
            bool isSuccess = false;
            SqlConnection cn = new SqlConnection(cnString);
            cn = CDatabase.Get_Database_Connection();
            try
            {
                string sqlText = "insert into HOA_DON(MAHD,MANV,MADL,NGAYLAP,MAKM,TONGTIEN) values (@m_MaHD,@m_MaNV,@m_MaDL,@m_NgayLap, @m_MaKM, @m_TongTien)";

                SqlCommand cmd = new SqlCommand(sqlText, cn);

                cmd.Parameters.AddWithValue("@m_MaHD", p.m_MaHD);
                cmd.Parameters.AddWithValue("@m_MaNV", p.m_MaNV);
                cmd.Parameters.AddWithValue("@m_MaDL", p.m_MaDL);
                cmd.Parameters.AddWithValue("@m_NgayLap", p.m_NgayLap);
                cmd.Parameters.AddWithValue("@m_MaKM", p.m_MaKM);
                cmd.Parameters.AddWithValue("@m_TongTien", p.m_TongTien);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                CDatabase.Close_Database_Connection();
            }
            return isSuccess;

        }

        //public bool Update(CProductBLL p)
        //{
        //    bool isSuccess = false;
        //    SqlConnection cn = new SqlConnection(cnString);
        //    cn = CDatabase.Get_Database_Connection();
        //    try
        //    {
        //        string sqlText = "UPDATE HANG_HOA SET MAHH=@m_MaHH,MAHTDG=@m_MaHTDG,MANHOM=@m_MaNhom,TENHH=@m_TenHH, DVT=@m_DVT, DONGIA=@m_DonGia, SLTON=@m_SLTon WHERE MAHH=@m_MaHH";

        //        SqlCommand cmd = new SqlCommand(sqlText, cn);

        //        cmd.Parameters.AddWithValue("@m_MaHH", p.m_MaHH);
        //        cmd.Parameters.AddWithValue("@m_MaHTDG", p.m_MaHTDG);
        //        cmd.Parameters.AddWithValue("@m_MaNhom", p.m_MaNhom);
        //        cmd.Parameters.AddWithValue("@m_TenHH", p.m_TenHH);
        //        cmd.Parameters.AddWithValue("@m_DVT", p.m_DVT);
        //        cmd.Parameters.AddWithValue("@m_DonGia", p.m_DonGia);
        //        cmd.Parameters.AddWithValue("@m_SLTon", p.m_SLTon);

        //        int rows = cmd.ExecuteNonQuery();

        //        if (rows > 0)
        //        {
        //            isSuccess = true;
        //        }
        //        else
        //        {
        //            isSuccess = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);

        //    }
        //    finally
        //    {
        //        CDatabase.Close_Database_Connection();
        //    }

        //    return isSuccess;
        //}

        public bool Delete(CBillBLL p)
       {
           bool isSuccess = false;
           SqlConnection cn = new SqlConnection(cnString);
           cn = CDatabase.Get_Database_Connection();
           try
           {
               string sqlText = "DELETE FROM HOA_DON WHERE MAHD=@m_MaHD";

               SqlCommand cmd = new SqlCommand(sqlText, cn);

               cmd.Parameters.AddWithValue("@m_MaHD", p.m_MaHD);


               int rows = cmd.ExecuteNonQuery();

               if (rows > 0)
               {
                   isSuccess = true;
               }
               else
               {
                   isSuccess = false;
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);

           }
           finally
           {
               CDatabase.Close_Database_Connection();
           }

           return isSuccess;
       }

        public DataTable Search(string keyWord)
        {
            SqlConnection cn = new SqlConnection(cnString);
            cn = CDatabase.Get_Database_Connection();

            DataTable tb = new DataTable();

            try
            {
                string sqlText = "SELECT * from HOA_DON WHERE MAHD LIKE '%" + keyWord + "%'";
                tb = CDatabase.Get_Data_Table(sqlText);

                CDatabase.Execute_SQL(sqlText);
                //MyDataGrid_SP.DataContext = tb.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
            finally
            {
                CDatabase.Close_Database_Connection();
            }
            return tb;
        }

        public void DoanhThu_HomNay()
        {
            SqlConnection cn = new SqlConnection(cnString);
            cn = CDatabase.Get_Database_Connection();

            DataTable tb = new DataTable();

            try
            {
                string sqlText = "SELECT * FROM HOA_DON WHERE month(getdate())=month(NGAYNHAP)";
                tb = CDatabase.Get_Data_Table(sqlText);

                CDatabase.Execute_SQL(sqlText);
                //MyDataGrid_SP.DataContext = tb.DefaultView;

                object SumRevenue = null;
                SumRevenue = tb.Compute("Sum(TONGTIEN)", "");
                MessageBox.Show("Doanh thu là : " + SumRevenue.ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
            finally
            {
                CDatabase.Close_Database_Connection();
            }
           

        }

    }
}
