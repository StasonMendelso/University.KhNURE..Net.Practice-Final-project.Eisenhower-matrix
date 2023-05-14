using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    public class MyTask
    {
        public string Name { get; set; }
        public bool IsImportant { get; set; }
        public bool IsUrgent { get; set; }
        public MyTask() { }

        public MyTask(string name, bool isImportant, bool isUrgent)
        {
            Name = name;
            IsImportant = isImportant;
            IsUrgent = isUrgent;
        }

        public MyTask(string name)
        {
            Name = name;
        }
    }
}
