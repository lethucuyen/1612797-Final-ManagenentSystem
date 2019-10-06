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
    /// Interaction logic for UserControl_HangHoa.xaml
    /// </summary>
    public partial class UserControl_HangHoa : UserControl
    {
        public UserControl_HangHoa()
        {
            InitializeComponent();
        }

        CProductBLL p = new CProductBLL();
        CProductDAL dal = new CProductDAL();
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            p.m_MaHH = txb_MaHH.Text;
            p.m_MaHTDG = txb_MaHTDG.Text;
            p.m_MaNhom = txb_MaNhom.Text;
            p.m_TenHH = txb_TenHH.Text;
            p.m_DVT = txb_DVT.Text;
            p.m_DonGia = Int32.Parse(txb_DonGia.Text);
            p.m_SLTon = Int32.Parse(txb_SLTon.Text);

            bool success = dal.Insert(p);
            if(success==true)
            {
                MessageBox.Show("Tạo thành công.");
                Clear();
            }
            else
            {
                MessageBox.Show("Thao tác tạo hàng hóa mới thất bại.");

            }
            DataTable tb = dal.Select();
            MyDataGrid_SP.DataContext = tb.DefaultView;

        }
        private void Clear()
        {
            txb_MaHH.Text="";
            txb_MaHTDG.Text="";
            txb_MaNhom.Text="";
            txb_TenHH.Text="";
            txb_DVT.Text="";
            txb_DonGia.Text="";
            txb_SLTon.Text="";
        }
        private void Button_SearchTenSP_Click(object sender, RoutedEventArgs e)
        {
            DataTable tb = new DataTable();
            tb = dal.Search(TextBox_SearchTenSP.Text);
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
            p.m_MaHH = txb_MaHH.Text;
            p.m_MaHTDG = txb_MaHTDG.Text;
            p.m_MaNhom = txb_MaNhom.Text;
            p.m_TenHH = txb_TenHH.Text;
            p.m_DVT = txb_DVT.Text;
            p.m_DonGia = Int32.Parse(txb_DonGia.Text);
            p.m_SLTon = Int32.Parse(txb_SLTon.Text);

            bool success = dal.Update(p);
            if (success == true)
            {
                MessageBox.Show("Cập nhật hàng hóa có mã " + txb_MaHH.Text + " thành công.");
                Clear();
            }
            else
            {
                MessageBox.Show("Cập nhật hàng hóa có mã " + txb_MaHH.Text + " thất bại.");
            }
            DataTable tb = dal.Select();
            MyDataGrid_SP.DataContext = tb.DefaultView;
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            p.m_MaHH = txb_MaHH.Text;
            

            bool success = dal.Delete(p);
            if (success == true)
            {
                MessageBox.Show("Xóa hàng hóa có mã " + txb_MaHH.Text + " thành công.");
                Clear();
            }
            else
            {
                MessageBox.Show("Xóa hàng hóa có mã " + txb_MaHH.Text + " thất bại.");
            }
            DataTable tb = dal.Select();
            MyDataGrid_SP.DataContext = tb.DefaultView;
        }

        private void MyDataGrid_SP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
