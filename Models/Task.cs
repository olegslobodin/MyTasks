using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyTasks.Models
{
    public class Task
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Name your task")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Add some description")]
        public string Content { get; set; }

        [Required]
        public int PriorityId { get; set; }
    }
}