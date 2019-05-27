using System.Net;
using System.Net.Mail;
using ToDo.Core.ViewModels;

namespace ToDo.Core.Models
{
    public class EmailSender
    {
        public static bool Hour { get; set; }
        public static bool HalfAnHour { get; set; }

        public static string SendAnHourBefore(ToDoViewModel toDo)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress("petrubetco@gmail.com", "To Name"));
                message.From = new MailAddress("petrubetco@gmail.com", "ToDos Manager");
                message.Subject = "ToDos";
                message.Body = "The following ToDos are about to expire: " +
                               toDo.Name +
                               " // " +
                               toDo.Description +
                               " // " +
                               toDo.Time.ToString("dd MMM - HH:mm");
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("petrubetco@gmail.com", "nkrqtkpcrqxaxfnp");
                    client.EnableSsl = true;
                    client.Send(message);
                    Hour = true;
                    HalfAnHour = false;
                    return "";
                }
            }
        }

        public static string SendHalfAnHourBefore(ToDoViewModel toDo)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress("petrubetco@gmail.com", "To Name"));
                message.From = new MailAddress("petrubetco@gmail.com", "ToDos Manager");
                message.Subject = "ToDos";
                message.Body = "The following ToDos are about to expire: " +
                               toDo.Name +
                               " // " +
                               toDo.Description +
                               " // " +
                               toDo.Time.ToString("dd MMM - HH:mm");
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("petrubetco@gmail.com", "nkrqtkpcrqxaxfnp");
                    client.EnableSsl = true;
                    client.Send(message);
                    HalfAnHour = true;
                    Hour = false;
                    return "";
                }
            }
        }
    }
}