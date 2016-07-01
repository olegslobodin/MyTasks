using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTasks.Models
{
    public class TaskGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}