using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToDo.Core.Models;

namespace ToDo.Core.ViewModels
{
    public class ToDoFormViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Time { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ToDoStatus ToDoStatus { get; set; }  
        public int ToDoPriority { get; set; }
        public IEnumerable<ToDoPriorities> ToDoPriorities { get; set; }

        public DateTime GetTime()
        {
            return Convert.ToDateTime(Time);
        }
    }
}