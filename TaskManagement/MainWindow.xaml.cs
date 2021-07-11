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

namespace TaskManagement
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Display_IndidualTaskWindow(object sender, RoutedEventArgs e)
        {
            Window SubWindow = new IndidualTaskWindow();
            SubWindow.Show();
            this.Close();
        }

        private void Display_SettingWindow(object sender, RoutedEventArgs e)
        {
            Window SettingWindow = new SettingWindow();
            SettingWindow.Show();
            this.Close();
        }
    }
}
