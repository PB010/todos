using System;
using System.Linq;

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

        public IQueryable<ToDoList> CreatedFilter(IQueryable<ToDoList> toDo, bool check)
        {
            if (!check)
            {
                check = true;
                return toDo.OrderBy(t => t.CreatedAt);
            }

            check = false;
            return toDo.OrderByDescending(t => t.CreatedAt);

        }
    }
}