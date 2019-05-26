using System;
using ToDo.Core.ViewModels;

namespace ToDo.Core.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ToDoStatus ToDoStatus { get; set; }
        public int ToDoPrioritiesId { get; set; }
        public ToDoPriorities ToDoPriorities { get; set; }

        public void UpdateToDo(ToDoFormViewModel viewModel)
        {
            Name = viewModel.Name;
            Description = viewModel.Description;
            Time = viewModel.Time;
            ToDoPrioritiesId = viewModel.ToDoPriority;
            UpdatedAt = DateTime.Now;
        }

        public void ChangeStatus()
        {
            ToDoStatus = ToDoStatus == ToDoStatus.Open ? ToDoStatus.Done : ToDoStatus.Open;
        }
    }
}