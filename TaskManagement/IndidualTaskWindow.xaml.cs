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


namespace TaskManagement
{
    class AllTask
    {
        public string TaskName { get; set; }
        public string DeadLine { get; set; }
        public string Progress { get; set; }
        public string Comment { get; set; }
        public string Detail { get; set; }
    }

    /// <summary>
    /// IndidualTaskWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class IndidualTaskWindow : Window
    {
        public IndidualTaskWindow()
        {
            InitializeComponent();
            DisplayUserName.Content = "しねー－";

            string FilePath = "./src/Alice.json";
            AllTask[] LoadData = new AllTask[0]; //todo ここの0の意味がわからん 要素数じゃないの？
            string UserData = GetJsonData(FilePath);
            LoadData = JsonSerializer.Deserialize<AllTask[]>(UserData);


            var table = new DataTable();
            
            table.Columns.Add("作業名");
            table.Columns.Add("締め切り");
            table.Columns.Add("コメント");
            table.Columns.Add("詳細");

            foreach (AllTask item in LoadData)
            {
                var columns = table.NewRow();
                
                //item.Progress;
                columns[0] = item.TaskName;
                columns[1] = item.DeadLine;
                columns[2] = item.Comment;
                columns[3] = item.Detail;
                
                table.Rows.Add(columns);
                
            }
            this.DataContext = table;
        }


        /// <summary>
        /// 行またセルはが編集モードに切り替わる前に発生します。
        /// </summary>
        private void TaskTable_SelectionChanged(object sender, DataGridBeginningEditEventArgs e)
        {
            switch (e.Column.Header.ToString())
            {
                case "進捗":  //fall through

                case "コメント":
                    Console.WriteLine("編集可能");
                    break;
                case "詳細":
                    string FilePath = "./src/Alice.json";
                    AllTask[] LoadData = new AllTask[0]; 
                    string UserData = GetJsonData(FilePath);
                    LoadData = JsonSerializer.Deserialize<AllTask[]>(UserData);
                    
                    System.Windows.MessageBox.Show(LoadData[e.Row.GetIndex()].Detail.ToString());
                    //System.Windows.MessageBox.Show(e.Column.DisplayIndex.ToString());
                    Process.Start(LoadData[e.Row.GetIndex()].Detail.ToString());
                    e.Cancel = true;    //編集をキャンセル
                    break;
                default:
                    e.Cancel = true;    //編集をキャンセル
                    break;
            }

        }


        /// <summary>
        /// ファイルパスを渡すと中身をstringで持ってくる
        /// </summary>
        public static string GetJsonData(string FilePath)
        {
            string CharCode = "utf-8";  //charset more better?
            StreamReader sr = new StreamReader(FilePath, Encoding.GetEncoding(CharCode));
            string jsonData = sr.ReadToEnd();
            sr.Close();
            return jsonData;
        }


    }
}

//System.Windows.MessageBox.Show()