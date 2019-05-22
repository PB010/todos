using System.Linq;
using System.Web.Mvc;
using ToDo.Core.Models;
using ToDo.Core.ViewModels;
using ToDo.Persistence;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ToDoController()
        {
            _context = new ApplicationDbContext();
        }
        
        public ActionResult Index()
        {
            var viewModel = new ToDoFormViewModel
            {
                ToDoPriorities = _context.ToDoPriorities.ToList()
            };
        
            return View(viewModel);
        }
        
        public ActionResult Create(ToDoFormViewModel viewModel)
        {
            var toDo = new ToDoList
            {
                Name = viewModel.Name,
                CreatedAt = viewModel.CreatedAt,
                Description = viewModel.Description,
                Time = viewModel.GetTime(),
                ToDoPrioritiesId = viewModel.ToDoPriority,
                ToDoStatus = viewModel.ToDoStatus
            };
        
            _context.ToDoLists.Add(toDo);
            _context.SaveChanges();
        
            return RedirectToAction("Index", "Home");
        }
    }
}