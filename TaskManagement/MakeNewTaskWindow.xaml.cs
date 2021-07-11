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

        private void Show_FolderDialog(object sender, RoutedEventArgs e)
        {
            using (var cofd = new CommonOpenFileDialog()
            {
                Title = "フォルダを選択してください",
                InitialDirectory = @"C:\Users",
                // フォルダ選択モードにする
                IsFolderPicker = true,
            })
            {
                if (cofd.ShowDialog() != CommonFileDialogResult.Ok)
                {
                    return;
                }

                // FileNameで選択されたフォルダを取得する
                System.Windows.MessageBox.Show($"{cofd.FileName}を選択しました");
                PathBox.Text = cofd.FileName;
            }
        }

        private void Register_AddNewTask(object sender, RoutedEventArgs e)
        {
            App.AddNewTask(TaskNameBox.Text, DeadLineDatePicker.Text, CommentBox.Text, PathBox.Text);
            this.Close();
        }
    }
}
//System.Windows.MessageBox.Show();