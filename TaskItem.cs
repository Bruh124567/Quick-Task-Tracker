using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Quick_Task_Tracker
{
    public class TaskItem
    {
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem() { }

        public TaskItem(string title, string priority)
        {
            Title = title;
            Priority = priority;
            CreatedAt = DateTime.Now;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $"[{Priority}] {Title} - {CreatedAt:t}";
        }
    }
}
