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

    class CProductDAL
    {
        static string cnString = Properties.Settings.Default.connString;

        public DataTable Select()
        {
            SqlConnection cn = new SqlConnection(cnString);
            cn = CDatabase.Get_Database_Connection();

            DataTable tb = new DataTable();

            try
            {
                string sqlText = "SELECT * from HANG_HOA";
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
        
        public bool Insert(CProductBLL p)
        {
            bool isSuccess = false;
            SqlConnection cn = new SqlConnection(cnString);
            cn = CDatabase.Get_Database_Connection();
            try
            {
                string sqlText = "insert into HANG_HOA(MAHH,MAHTDG,MANHOM,TENHH,DVT,DONGIA,SLTON) values (@m_MaHH,@m_MaHTDG,@m_MaNhom,@m_TenHH, @m_DVT, @m_DonGia, @m_SLTon)";

                SqlCommand cmd = new SqlCommand(sqlText, cn);

                cmd.Parameters.AddWithValue("@m_MaHH", p.m_MaHH);
                cmd.Parameters.AddWithValue("@m_MaHTDG", p.m_MaHTDG);
                cmd.Parameters.AddWithValue("@m_MaNhom", p.m_MaNhom);
                cmd.Parameters.AddWithValue("@m_TenHH", p.m_TenHH);
                cmd.Parameters.AddWithValue("@m_DVT", p.m_DVT);
                cmd.Parameters.AddWithValue("@m_DonGia", p.m_DonGia);
                cmd.Parameters.AddWithValue("@m_SLTon", p.m_SLTon);

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
            catch    (Exception ex)                                  
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                CDatabase.Close_Database_Connection();
            }
            return isSuccess;
                
        }

        public bool Update(CProductBLL p)
        {
            bool isSuccess= false;
            SqlConnection cn = new SqlConnection(cnString);
            cn = CDatabase.Get_Database_Connection();
            try
            {
                string sqlText = "UPDATE HANG_HOA SET MAHH=@m_MaHH,MAHTDG=@m_MaHTDG,MANHOM=@m_MaNhom,TENHH=@m_TenHH, DVT=@m_DVT, DONGIA=@m_DonGia, SLTON=@m_SLTon WHERE MAHH=@m_MaHH";

                SqlCommand cmd = new SqlCommand(sqlText, cn);

                cmd.Parameters.AddWithValue("@m_MaHH", p.m_MaHH);
                cmd.Parameters.AddWithValue("@m_MaHTDG", p.m_MaHTDG);
                cmd.Parameters.AddWithValue("@m_MaNhom", p.m_MaNhom);
                cmd.Parameters.AddWithValue("@m_TenHH", p.m_TenHH);
                cmd.Parameters.AddWithValue("@m_DVT", p.m_DVT);
                cmd.Parameters.AddWithValue("@m_DonGia", p.m_DonGia);
                cmd.Parameters.AddWithValue("@m_SLTon", p.m_SLTon);

                int rows = cmd.ExecuteNonQuery();

                if (rows>0)
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

        public bool Delete(CProductBLL p)
        {
            bool isSuccess = false;
            SqlConnection cn = new SqlConnection(cnString);
            cn = CDatabase.Get_Database_Connection();
            try
            {
                string sqlText = "DELETE FROM HANG_HOA WHERE MAHH=@m_MaHH";

                SqlCommand cmd = new SqlCommand(sqlText, cn);

                cmd.Parameters.AddWithValue("@m_MaHH", p.m_MaHH);
                

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
                string sqlText = "SELECT * from HANG_HOA WHERE MAHH LIKE '%"+keyWord+"%'OR TENHH LIKE '%"+keyWord+"%'";
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

        public DataTable Select_HangTonKho()
        {
            SqlConnection cn = new SqlConnection(cnString);
            cn = CDatabase.Get_Database_Connection();

            DataTable tb = new DataTable();

            try
            {
                string sqlText = "SELECT h.MAHH as 'Mã hàng hóa', h.TENHH as 'Tên hàng hóa', n.TENNHOM as 'Tên nhóm hàng', h.SLTON as 'Số lượng còn trong kho' from HANG_HOA h, NHOM_HANG n WHERE h.MANHOM=n.MANHOM";
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

        public DataTable Search_HangTonKho(string keyWord)
        {
            SqlConnection cn = new SqlConnection(cnString);
            cn = CDatabase.Get_Database_Connection();

            DataTable tb = new DataTable();

            try
            {
                string sqlText = "SELECT h.MAHH as 'Mã hàng hóa', h.TENHH as 'Tên hàng hóa', n.TENNHOM as 'Tên nhóm hàng', h.SLTON as 'Số lượng còn trong kho' from HANG_HOA h, NHOM_HANG n WHERE h.MANHOM=n.MANHOM AND (h.MAHH LIKE '%" + keyWord + "%'OR h.TENHH LIKE '%" + keyWord + "%' OR n.TENNHOM LIKE '%" + keyWord + "%')";
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

    }
}
