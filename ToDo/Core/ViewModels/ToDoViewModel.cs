using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Core.Models;

namespace ToDo.Core.ViewModels
{
    public class ToDoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime Time { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ToDoStatus ToDoStatus { get; set; }
        public int ToDoPrioritiesId { get; set; }
        public ToDoPriorities ToDoPriorities { get; set; }
        public static bool Selector { get; set; }
        public string Check { get {return (!Selector) ? "Newest" : "Oldest";}}



        public static IOrderedEnumerable<ToDoViewModel> OrderTime(List<ToDoViewModel> viewModels)
        {
            if (!Selector)
            {
                Selector = true;
                return viewModels.OrderBy(t => t.Time);
            }

            Selector = false;
            return viewModels.OrderByDescending(t => t.Time);
        }

        public static IOrderedEnumerable<ToDoViewModel> OrderDate(List<ToDoViewModel> viewModels)
        {
            if (!Selector)
            {
                Selector = true;
                return viewModels.OrderBy(t => t.CreatedAt);
            }

            Selector = false;
            return viewModels.OrderByDescending(t => t.CreatedAt);
        }

        public static void MapToList(List<ToDoViewModel> viewModel, List<ToDoList> toDo)
        {
            foreach (var toDoList in toDo)
            {
                viewModel.Add(new ToDoViewModel
                {
                    CreatedAt = toDoList.CreatedAt,
                    UpdatedAt = toDoList.UpdatedAt,
                    Description = toDoList.Description,
                    UserId = toDoList.UserId,
                    Id = toDoList.Id,
                    Name = toDoList.Name,
                    Time = toDoList.Time,
                    ToDoPriorities = toDoList.ToDoPriorities,
                    ToDoPrioritiesId = toDoList.ToDoPrioritiesId,
                    ToDoStatus = toDoList.ToDoStatus
                });
                
            }
        }
    }
}