using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTasks.Models
{
    public class User
    {
        [Key]
        public int SecretKey { get; set; }

        [Required(ErrorMessage = "Didn't you have a name?!")]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}