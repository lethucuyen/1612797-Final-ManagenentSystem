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
using System.Windows.Shapes;
//<add using>
using _1612797_SalesManagementApplication.Login;
using _1612797_SalesManagementApplication.MessageBoxs;
//</add using>

namespace _1612797_SalesManagementApplication
{
    /// <summary>
    /// Interaction logic for Window_Login.xaml
    /// </summary>
    public partial class Window_Login : Window
    {

        public Window_Login()
        {
            InitializeComponent();
        }

        //Khi click nút shutdown :
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Khi click di chuyển cửa sổ :
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //Khi click ẩn cửa sổ :
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Khi click "Đăng nhập" :
        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxUserName.Text == "" || TextBoxPassword.Password == "")
            {
                //MessageBox.Show(" Nhập vào mật khẩu. Thông tin đăng nhập không chính xác");
                var windowMessageBox = new Window_MessageBoxs();
                //this.Hide();
                windowMessageBox.GridInsideMessageBox.Children.Clear();
                windowMessageBox.GridInsideMessageBox.Children.Add(new UserControl_DangNhapThBai());
                windowMessageBox.ShowDialog();
            }
            else
            {
                if (TextBoxUserName.Text.ToLower() == "admin" && TextBoxPassword.Password == "123")
                {
                    this.Hide();
                    //MessageBox.Show(" Nhập vào mật khẩu. Thông tin đăng nhập không chính xác");
                    var windowMessageBox = new Window_MessageBoxs();
                    //this.Hide();
                    windowMessageBox.GridInsideMessageBox.Children.Clear();
                    windowMessageBox.GridInsideMessageBox.Children.Add(new UserControl_DangNhapThCong());
                    windowMessageBox.ShowDialog();

                    var mainWindow = new MainWindow();
                    mainWindow.ShowDialog();

                }
            }

        }

        private void ButtonCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window_CreateAccount();
            this.Hide();
            window.ShowDialog();
        }

        private void ButtonForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window_ForgotPassword();
            this.Hide();
            window.ShowDialog();
        }

        private void CheckBoxStaySignedIn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSignInWithFacebook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSignInWithTwitter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSignInWithGoogle_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
