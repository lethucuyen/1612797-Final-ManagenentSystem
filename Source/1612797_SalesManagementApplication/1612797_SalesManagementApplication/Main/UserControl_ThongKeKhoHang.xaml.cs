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
    /// Interaction logic for UserControl_ThongKeKhoHang.xaml
    /// </summary>
    public partial class UserControl_ThongKeKhoHang : UserControl
    {
        public UserControl_ThongKeKhoHang()
        {
            InitializeComponent();
        }

        CProductBLL p = new CProductBLL();
        CProductDAL dal = new CProductDAL();
        
       
        private void Button_SearchTenSP_Click(object sender, RoutedEventArgs e)
        {
            DataTable tb = new DataTable();
            tb = dal.Search_HangTonKho(TextBox_SearchTenSP.Text);
            MyDataGrid_SP.DataContext = tb.DefaultView;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable tb = new DataTable();
            tb = dal.Select_HangTonKho();
            MyDataGrid_SP.DataContext = tb.DefaultView;

        }


    }
}
