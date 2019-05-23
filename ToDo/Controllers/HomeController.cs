using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ToDo.Core.Models;
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

        [HttpGet]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View();

            var toDo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .ToList();

            return View(toDo);
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortByName()
        {
            var todoName = _context.ToDoLists.Include(t => t.ToDoPriorities).OrderBy(t => t.Name);

            return View("Index", todoName); 
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortByPriority()
        {
            var todoPriority = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .OrderByDescending(t => t.ToDoPrioritiesId);

            return View("Index", todoPriority);
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortByStatus()
        {
            var todoStatus = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .OrderBy(t => t.ToDoStatus == ToDoStatus.Done);

            return View("Index", todoStatus);
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortAscending()
        {
            var todo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .OrderBy(t => t.CreatedAt);

            return View("Index", todo);
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortDescending()
        {
            var todo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .OrderByDescending(t => t.CreatedAt);

            return View("Index", todo);
        }
    }
}