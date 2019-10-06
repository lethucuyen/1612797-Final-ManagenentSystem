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

namespace _1612797_SalesManagementApplication.Main
{
    /// <summary>
    /// Interaction logic for UserControl_BanHang.xaml
    /// </summary>
    public partial class UserControl_BanHang : UserControl
    {
        public UserControl_BanHang()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //TextBox_SearchTenSP
            //MyDataGrid_LoaiSP
        }

        private void Button_SearchTenSP_Click(object sender, RoutedEventArgs e)
        {
            string str = TextBox_SearchTenSP.Text;

            try
            {
                //Cách 2
                string cnString = Properties.Settings.Default.connString;
                SqlConnection cn = new SqlConnection(cnString);
                cn = CDatabase.Get_Database_Connection();

                string sqlText = "SELECT TENHH as 'Tên hàng hóa', SLTON as 'Số lượng tồn' FROM HANG_HOA WHERE TENHH like '%" + str + "%' ";

                DataTable tb = new DataTable();
                tb = CDatabase.Get_Data_Table(sqlText);

                CDatabase.Execute_SQL(sqlText);
                MyDataGrid_SP.DataContext = tb.DefaultView;

                CDatabase.Close_Database_Connection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
