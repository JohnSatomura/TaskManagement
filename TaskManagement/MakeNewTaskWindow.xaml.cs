using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskManagement
{
    /// <summary>
    /// MakeNewTaskWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MakeNewTaskWindow : Window
    {
        public MakeNewTaskWindow()
        {
            InitializeComponent();
            
        }


        private void Register_AddNewTask(object sender, RoutedEventArgs e)
        {
            App.AddNewTask(TaskNameBox.Text, DeadLineDatePicker.Text, CommentBox.Text, PathBox.Text);
            this.Close();
        }

        private void Ref_FolderDialog(object sender, RoutedEventArgs e)
        {
            PathBox.Text = App.Show_FolderDialog();
        }
    }
}
//System.Windows.MessageBox.Show();