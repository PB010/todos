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
        public DateTime Time { get; set; }
        public DateTime CreatedAt { get; set; }
        public ToDoStatus ToDoStatus { get; set; } 
        [Required]
        [Display(Name = "Priority")]
        public int ToDoPriority { get; set; }
        public IEnumerable<ToDoPriorities> ToDoPriorities { get; set; }
        public string Heading { get; set; }

        public string Action { get { return (Id == 0) ? "New" : "Update"; } }

        public void MapFormViewModel(ToDoList todo)
        { 
            CreatedAt = todo.CreatedAt;
            Description = todo.Description;
            Id = todo.Id;
            Name = todo.Name;
            Time = todo.Time;
            ToDoPriority = todo.ToDoPrioritiesId;
            Heading = "Edit ToDo";
        }
    }
}