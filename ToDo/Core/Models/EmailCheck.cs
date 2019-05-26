using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Core.Models
{
    public class EmailCheck
    {
        public bool Hour { get; set; }
        public bool HalfAnHour { get; set; }
        public bool StatusCheck { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ToDoList ToDoList { get; set; }
        [Key]
        [Column(Order = 1)]
        public string ApplicationUserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ToDoListId { get; set; }
    }
}