using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Final_project
{
    public sealed partial class MainPage : Page
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public MainPage()
        {
            this.InitializeComponent();
        }
       
        private void AddNewTaskItemButton_Click(object sender, RoutedEventArgs e) {
            string taskName = TaskItemName.Text;
            bool isUrgent = (bool)TaskItemIsUrgent.IsChecked;
            bool isImportant = (bool)TaskItemIsImportant.IsChecked;

            if (taskName.Length == 0) {
                return;
            }
            MyTask myTask = new MyTask(taskName,isImportant,isUrgent);
            AddTaskToList(myTask);

            TaskItemName.Text = "";
        }

        private void AddTaskToList(MyTask task)
        {
            List<MyTask> importantAndUrgentTaskList = (List<MyTask>)importantAndUrgentTasks.ItemsSource ==null ? new List<MyTask>(): (List<MyTask>)importantAndUrgentTasks.ItemsSource;
            List<MyTask> importantAndNotUrgentTaskList = (List<MyTask>)importantAndNotUrgentTasks.ItemsSource == null ? new List<MyTask>() : (List<MyTask>)importantAndNotUrgentTasks.ItemsSource;
            List<MyTask> notImportantAndUrgentTaskList = (List<MyTask>)NotImportantAndUrgentTasks.ItemsSource == null ? new List<MyTask>() : (List<MyTask>)NotImportantAndUrgentTasks.ItemsSource;
            List<MyTask> notImportantAndNotUrgentTaskList = (List<MyTask>)NotImportantAndNotUrgentTasks.ItemsSource == null ? new List<MyTask>() : (List<MyTask>)NotImportantAndNotUrgentTasks.ItemsSource;
            if (task.IsImportant && task.IsUrgent)
            {
                importantAndUrgentTaskList.Add(task);
                importantAndUrgentTasks.ItemsSource = new List<MyTask>(importantAndUrgentTaskList);

            }
            if (task.IsImportant && !task.IsUrgent)
            {
                importantAndNotUrgentTaskList.Add(task);
                importantAndNotUrgentTasks.ItemsSource = new List<MyTask>(importantAndNotUrgentTaskList);

            }
            if (!task.IsImportant && task.IsUrgent)
            {
                notImportantAndUrgentTaskList.Add(task);
                NotImportantAndUrgentTasks.ItemsSource = new List<MyTask>(notImportantAndUrgentTaskList);

             }
            if (!task.IsImportant && !task.IsUrgent)
            {
                notImportantAndNotUrgentTaskList.Add(task);
                NotImportantAndNotUrgentTasks.ItemsSource = new List<MyTask>(notImportantAndNotUrgentTaskList);
            }
        }
        private void DeleteTaskItem_Button(object sender, RoutedEventArgs e)
        {
            var listName = ((Button)sender).Tag;
            var taskName = ((Button)sender).CommandParameter;
            if (listName.Equals("importantAndUrgentTasks"))
            {
                List<MyTask> tasks = (List<MyTask>)importantAndUrgentTasks.ItemsSource;
                DeleteTaskFromList(taskName, tasks);
                importantAndUrgentTasks.ItemsSource = new List<MyTask>(tasks);
            }
            if (listName.Equals("importantAndNotUrgentTasks"))
            {
                List<MyTask> tasks = (List<MyTask>)importantAndNotUrgentTasks.ItemsSource;
                DeleteTaskFromList(taskName, tasks);
                importantAndNotUrgentTasks.ItemsSource = new List<MyTask>(tasks);
            }
            if (listName.Equals("NotImportantAndUrgentTasks"))
            {
                List<MyTask> tasks = (List<MyTask>)NotImportantAndUrgentTasks.ItemsSource;
                DeleteTaskFromList(taskName, tasks);
                NotImportantAndUrgentTasks.ItemsSource = new List<MyTask>(tasks);
            }
            if (listName.Equals("NotImportantAndNotUrgentTasks"))
            {
                List<MyTask> tasks = (List<MyTask>)NotImportantAndNotUrgentTasks.ItemsSource;
                DeleteTaskFromList(taskName, tasks);
                NotImportantAndNotUrgentTasks.ItemsSource = new List<MyTask>(tasks);
            }
        }

        private static void DeleteTaskFromList(object taskName, List<MyTask> tasks)
        {
            foreach (var task in tasks)
            {
                if (task.Name.Equals(taskName))
                {
                    tasks.Remove(task);
                    break;
                }
            }
        }
        private void CompleteTaskItem_Button(object sender, RoutedEventArgs e)
        {
            List<MyTask> completedTaskList = (List<MyTask>)(completedTasks.ItemsSource ?? new List<MyTask>());
            DeleteTaskItem_Button(sender, e);
            var taskName = (String)((Button)sender).CommandParameter;
            completedTaskList.Add(new MyTask(taskName));
            completedTasks.ItemsSource = new List<MyTask>(completedTaskList);
        }
    }
   

}
