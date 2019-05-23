using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ToDo.Persistence;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View();

            var toDo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .ToList();

            return View(toDo);
        }


    }
}