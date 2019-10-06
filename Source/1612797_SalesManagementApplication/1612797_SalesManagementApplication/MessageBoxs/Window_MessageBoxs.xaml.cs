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

namespace _1612797_SalesManagementApplication.MessageBoxs
{
    /// <summary>
    /// Interaction logic for Window_MessageBoxs.xaml
    /// </summary>
    public partial class Window_MessageBoxs : Window
    {
        public Window_MessageBoxs()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Khi click nút shutdown :
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

    }
}
