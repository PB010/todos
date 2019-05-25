using System;
using System.Linq;
using ToDo.Core.ViewModels;

namespace ToDo.Persistence.Email
{
    public class EmailSender
    {
        private static readonly ApplicationDbContext _context;

        static EmailSender()
        {
            _context = new ApplicationDbContext();
        }

        public static void SendAnHourBefore(ToDoViewModel toDo, string userId, TimeSpan time)
        {
            var emailCheck = _context.EmailHourChecks
                .Single(e => e.ToDoListId == toDo.Id && e.ApplicationUserId == userId);

            if (time.TotalMinutes <= 60 && time.TotalMinutes > 30 && !emailCheck.Hour)
            {
                EmailTemplate.Template("Expiring ToDo - 1 hour or less.",
                    toDo,
                    emailCheck.Hour,
                    _context);
            }
            
        }

        public static void SendHalfAnHourBefore(ToDoViewModel toDo, string userId, TimeSpan time)
        {
            var emailCheck = _context.EmailHourChecks
                .Single(e => e.ToDoListId == toDo.Id && e.ApplicationUserId == userId);

            if (time.TotalMinutes <= 30 && time.TotalMinutes > 0 && !emailCheck.HalfAnHour)
            {
                EmailTemplate.Template("Expiring ToDo - 30 minutes or less.",
                    toDo,
                    emailCheck.HalfAnHour,
                    _context);
            }

                
        }
    }

}