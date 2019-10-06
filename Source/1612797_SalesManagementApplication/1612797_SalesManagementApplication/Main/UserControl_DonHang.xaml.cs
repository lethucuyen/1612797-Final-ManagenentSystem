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
    /// Interaction logic for UserControl_DonHang.xaml
    /// </summary>
    public partial class UserControl_DonHang : UserControl
    {
        public UserControl_DonHang()
        {
            InitializeComponent();
        }

        CBillBLL p = new CBillBLL();
        CBillDAL dal = new CBillDAL();
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            p.m_MaHD = txb_MaHD.Text;
            p.m_MaNV = txb_MaNV.Text;
            p.m_MaDL = txb_MaDL.Text;
            p.m_NgayLap = DateTime.Now;
            p.m_MaKM = txb_MaKM.Text;
            p.m_TongTien = Int32.Parse(txb_TongTien.Text);

            bool success = dal.Insert(p);
            if (success == true)
            {
                MessageBox.Show("Thao tác tạo đơn hàng mới thành công.");
                Clear();
            }
            else
            {
                MessageBox.Show("Thao tác tạo đơn hàng mới thất bại.");

            }
            DataTable tb = dal.Select();
            MyDataGrid_SP.DataContext = tb.DefaultView;

        }
        private void Clear()
        {
           
        }
        private void Button_SearchTen_Click(object sender, RoutedEventArgs e)
        {
            DataTable tb = new DataTable();
            tb = dal.Search(TextBox_SearchTen.Text);
            MyDataGrid_SP.DataContext = tb.DefaultView;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable tb = new DataTable();
            tb = dal.Select();
            MyDataGrid_SP.DataContext = tb.DefaultView;

        }


        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            p.m_MaHD = txb_MaHD.Text;


            bool success = dal.Delete(p);
            if (success == true)
            {
                MessageBox.Show("Xóa đơn hàng có mã " + txb_MaHD.Text + " thành công.");
                Clear();
            }
            else
            {
                MessageBox.Show("Xóa hàng hóa có mã " + txb_MaHD.Text + " thất bại.");
            }
            DataTable tb = dal.Select();
            MyDataGrid_SP.DataContext = tb.DefaultView;
        }

        


    }
}
