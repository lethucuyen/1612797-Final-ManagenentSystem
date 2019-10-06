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
//<add using>
using System.Data.SqlClient;//local db
using System.Data;//ConnectionState, DataTable
//</add using>

namespace _1612797_SalesManagementApplication.UserControls.MainWindows
{
    /// <summary>
    /// Interaction logic for UserControlThongKeBH.xaml
    /// </summary>
    public partial class UserControlThongKeBH : UserControl
    {
        public UserControlThongKeBH()
        {
            InitializeComponent();
        }

       

        private void ButtonOpenPopUpFilter_BCBH_Click(object sender, RoutedEventArgs e)
        {
            PopUpFilter_BCBH.IsOpen = true;
        }

        private void ButtonOpenPopUpFilter_SPBC_Click(object sender, RoutedEventArgs e)
        {
            PopUpFilter_SPBC.IsOpen = true;

        }

        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            RevenueChart.Update(true);
        }

        private void db_Read_Record_SP()
        {
            try
            {

                //Cách 2
                string cnString = Properties.Settings.Default.connString;
                SqlConnection cn = new SqlConnection(cnString);
                cn = CDatabase.Get_Database_Connection();

                string sqlText = "SELECT pp.TENHH as 'Tên hàng hóa', sum(p.SLBAN) 'Số lượng bán được' FROM CTHD p, HANG_HOA pp WHERE p.MAHH=pp.MAHH GROUP BY p.MAHH, pp.TENHH  ORDER BY sum(p.SLBAN) DESC "  ;

                DataTable tb = new DataTable();
                tb = CDatabase.Get_Data_Table(sqlText);

                CDatabase.Execute_SQL(sqlText);
                MyDataGrid_LoaiSP.DataContext = tb.DefaultView;

                CDatabase.Close_Database_Connection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                db_Read_Record_SP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonPrevPage_LoaiSP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonNextPage_LoaiSP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        
        CBillDAL dal;
        private void Button_Filter_HomNay_Click(object sender, RoutedEventArgs e)
        {
            dal.DoanhThu_HomNay();
        }

        private void Button_Filter_HomQua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Filter_7NgayTruoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Filter_ThangTruoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Filter_TuyChon_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

