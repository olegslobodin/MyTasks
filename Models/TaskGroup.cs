using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyTasks.Models
{
    public class TaskGroup
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name your group")]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}