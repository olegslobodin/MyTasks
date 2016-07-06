using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTasks.Models
{
    public class Priority
    {
        public int ID { get; set; }

        [Required]
        public int PriorityLevel { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}