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

namespace TaskManagement
{
    /// <summary>
    /// SettingWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();

            UserName.Text = Properties.Settings.Default.UserName;
            FolderPath.Text = Properties.Settings.Default.FilePath;
        }

        private void Save_UserData(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UserName = UserName.Text;
            Properties.Settings.Default.FilePath = FolderPath.Text;
            Window Back_MainWindow = new MainWindow();
            this.Close();
            Back_MainWindow.Show();
        }

        private void Cancel_Update(object sender, RoutedEventArgs e)
        {
            Window Back_MainWindow = new MainWindow();
            this.Close();
            Back_MainWindow.Show();
            
        }

        private void Ref_FolderDialog(object sender, RoutedEventArgs e)
        {
            FolderPath.Text = App.Show_FolderDialog();
        }
    }
}
