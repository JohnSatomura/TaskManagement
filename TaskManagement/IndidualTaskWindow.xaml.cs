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
using System.Text.Json;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;

namespace TaskManagement
{
    /// <summary>
    /// IndidualTaskWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class IndidualTaskWindow : Window
    {
        public IndidualTaskWindow()
        {
            InitializeComponent();

            DisplayUserName.Content = Properties.Settings.Default.UserName;

            
            Task[] LoadData = new Task[0]; //todo ここの0の意味がわからん 要素数じゃないの？
            LoadData = JsonSerializer.Deserialize<Task[]>(App.Load_TaskData());
            var data = new ObservableCollection<Task>();

            var table = new DataTable();
            foreach (Task item in LoadData)
            {
                data.Add(new Task
                {
                    Progress = item.Progress,
                    TaskName = item.TaskName,
                    DeadLine = item.DeadLine,
                    Comment = item.Comment,
                    Detail = item.Detail
                });
            }
            this.TaskTable.ItemsSource = data;
        }


        /// <summary>
        /// 行またセルはが編集モードに切り替わる前に発生します。
        /// </summary>
        /// // todo 以下実行前にパスが存在するか確認しろ 
        /// 存在しないならダイアログを出してあるところまで開く
        private void TaskTable_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            switch (e.Column.Header.ToString())
            {
                case "コメント":
                    MessageBox.Show("aaa");
                    break;
                case "詳細":
                    DataGrid dg = sender as DataGrid;
                    Task row = (Task)dg.SelectedItems[0];
                    //System.Windows.MessageBox.Show(dg.SelectedItems[0].ToString());
                    Process.Start(row.Detail.ToString());
                    e.Cancel = true;    //編集をキャンセル
                    break;
                default:
                    e.Cancel = true;    //編集をキャンセル
                    break;
            }

        }

        /// <summary>
        /// 変更したデータのアップデート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_AddNewTaskWindow(object sender, RoutedEventArgs e)
        {
            Window SubWindow = new MakeNewTaskWindow();
            //App.AddNewTask("タスク2", "199xmmdd", "できた", "なし");
            SubWindow.Show();
        }

    }
}

//System.Windows.MessageBox.Show();