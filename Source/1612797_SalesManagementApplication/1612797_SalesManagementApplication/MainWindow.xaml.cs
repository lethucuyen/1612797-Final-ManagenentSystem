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
using System.Windows.Threading;//clock
using System.Data.SqlClient;//local db
using System.Data;//ConnectionState, DataTable
using _1612797_SalesManagementApplication.UserControls.MainWindows;//UserControlTongQuan, ...
using _1612797_SalesManagementApplication.Main;
//</add using>

namespace _1612797_SalesManagementApplication
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Khi click di chuyển cửa sổ :

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //Khi click nút shutdown :

        private void Button_Fechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Khi click ẩn cửa sổ :

        private void Button_Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        
        public void Timer_Tick(object sender, EventArgs e)
        {
            TextBlock_Time.Text = DateTime.Now.ToLongTimeString();
            TextBlock_Date.Text = DateTime.Now.ToLongDateString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //Load clock
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            //Mặc định cho hiển thị của GridPrincipal
            GridPrincipal.Children.Add(new UserControlTongQuan());


            //ADD LATER
        }

        //Khi chuyển tab trong menu sẽ chuyển GridPrincipal, đồng thời di chuyển cursor-menu:
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch (index)
            {
                //TỔNG QUAN
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlTongQuan());
                    MoveCursorMenu(index);
                    break;

                //BÁN HÀNG
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_BanHang());
                    MoveCursorMenu(index);
                    break;

                //HÀNG HÓA
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_HangHoa());
                    MoveCursorMenu(index);
                    break;

                //THỐNG KÊ KHO HÀNG
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_ThongKeKhoHang());
                    MoveCursorMenu(index);
                    break;

                //ĐƠN HÀNG
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_DonHang());
                    MoveCursorMenu(index);
                    break;

                //THỐNG KÊ BÁN HÀNG
                case 5:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlThongKeBH());
                    MoveCursorMenu(index);
                    break;

                //CẤU HÌNH NÂNG CAO(CHỨA QUẢN LÝ TÀI KHOÀN)
                case 6:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlCauHinhNC());
                    MoveCursorMenu(index);
                    break;
       
                default:
                    MoveCursorMenu(index);
                    break;
            }
        }

        //Sd cho sự kiện ListViewMenuNumber1_SelectionChanged :
        private void MoveCursorMenu(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (0 + (40 * index)), 0, 0);
        }
       
        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
            var windowLogin = new Window_Login();
            windowLogin.ShowDialog();
            
        }

        private void Button_Helpful_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window_Help();
            window.ShowDialog();
        }

        private void Button_Info_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window_UserInfo();
            window.ShowDialog();
        }

        private void Button_PopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            //this.Visibility = Visibility.Hidden;
            this.Hide();

            var window = new Window_Login();
            window.ShowDialog();
        }


        //ADD LATER
    }
}
//BINDING
//public partial class MainWindow : Window
//{
//    Person person = new Person("Tom", 11);
//    public MainWindow()
//    {
//        InitializeComponent();
//        GridMain.DataContext = person;
//    }
//  …
//}
//_________________________________________________________________
////GÓP Ý
//    //làm mờ xung quanh, đồng thời di chuyển cursor menu
//    MoveCursorMenu(index);
//    var blurWindow = new Window()
//    {
//        Background = Brushes.Black,
//        Opacity = 0.4,
//        AllowsTransparency = true,
//        WindowStyle = WindowStyle.None,
//        WindowState = WindowState.Maximized
//    };
//    blurWindow.Show();
//    //yourpopupwindow.show(); //show popup window or dialog here  

//    //show dialog
//    var windowFeedback = new WindowFeedback();
//    windowFeedback.ShowDialog();

//    blurWindow.Close();
//    break;