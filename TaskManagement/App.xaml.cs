using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json;

namespace TaskManagement
{
    class Task
    {
        public string TaskName { get; set; }
        public string DeadLine { get; set; }
        public string Progress { get; set; }
        public string Comment { get; set; }
        public string Detail { get; set; }
    }

    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// ファイルパスを渡すと中身をstringで持ってくる
        /// </summary>
        public static string Load_TaskData()
        {
            string CharCode = "utf-8";  //charset more better?
            StreamReader sr = new StreamReader(TaskManagement.Properties.Settings.Default.FilePath, Encoding.GetEncoding(CharCode));
            string JsonData = sr.ReadToEnd();
            sr.Close();
            return JsonData;
        }

        public static void AddNewTask(string TaskName,string DeadLine, string Comment, string Detail)
        {
            var NewTask = new Task();
            NewTask.TaskName = TaskName;
            NewTask.DeadLine = DeadLine;
            NewTask.Progress = "false";
            NewTask.Comment = Comment;
            NewTask.Detail = Detail;
            string jsonString = JsonSerializer.Serialize(NewTask);

            //MessageBox.Show(jsonString);
        }
    }
}
