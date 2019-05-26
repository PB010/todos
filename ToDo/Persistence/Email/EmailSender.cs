using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using ToDo.Core;
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


        public static void SendAnHourBefore(ToDoViewModel toDo)
        {
            var time = (toDo.Time - DateTime.Now).TotalMinutes;
            var emailCheck = _context.EmailChecks
                .Single(e => e.ToDoListId == toDo.Id && e.ApplicationUserId == toDo.UserId);

            if (emailCheck == null)
                throw new HttpRequestException();

            if (time <= 60 && time >= 31 && !emailCheck.Hour)
            {
                emailCheck.Hour = true;
                EmailTemplate.TimeTemplate("Expiring ToDo - 1 hour or less.", toDo);

                _context.SaveChanges();
            }
        }


        public static void SendHalfAnHourBefore(ToDoViewModel toDo)
        {
            var time = (toDo.Time - DateTime.Now).TotalMinutes;
            var emailCheck = _context.EmailChecks
                .Single(e => e.ToDoListId == toDo.Id && e.ApplicationUserId == toDo.UserId);

            if (emailCheck == null)
                throw new HttpRequestException();

            if (time <= 30 && time > 0 && !emailCheck.HalfAnHour)
            {
                emailCheck.HalfAnHour = true;
                EmailTemplate.TimeTemplate("Expiring ToDo - 30 minutes or less.", toDo);
                _context.SaveChanges();
            }
        }


        public static void SendStatusChange(ToDoViewModel toDo)
        {
            var emailCheck = _context.EmailChecks
                .Include(e => e.ToDoList)
                .Single(e => e.ToDoListId == toDo.Id && e.ApplicationUserId == toDo.UserId);

            if (!emailCheck.StatusCheck)
            {
                emailCheck.StatusCheck = true;
                _context.SaveChanges();
                EmailTemplate.StatusTemplate("ToDoStatusChange", toDo);
            }
        }

        public static void ResetStatus(ToDoViewModel toDo)
        {
            var emailCheck = _context.EmailChecks
                .Include(e => e.ToDoList)
                .Single(e => e.ToDoListId == toDo.Id && e.ApplicationUserId == toDo.UserId);

            emailCheck.StatusCheck = false;
            _context.SaveChanges();
        }
    }

}