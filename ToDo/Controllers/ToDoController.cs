using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ToDo.Core.Models;
using ToDo.Core.ViewModels;
using ToDo.Persistence;

namespace ToDo.Controllers
{
    [Authorize]
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
                ToDoPriorities = _context.ToDoPriorities.ToList(),
                Heading = "New ToDo"
                
            };
        
            return View("ToDoForm", viewModel);
        }
        

        public ActionResult Edit(int id)
        {
            var todo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .Single(t => t.Id == id);

            var viewModel = new ToDoFormViewModel
            {
                CreatedAt = todo.CreatedAt,
                Description = todo.Description,
                Id = todo.Id,
                Name = todo.Name,
                Time = todo.Time,
                ToDoPriority = todo.ToDoPrioritiesId,
                Heading = "Edit ToDo",
                ToDoPriorities = _context.ToDoPriorities.ToList()
            };

            return View("ToDoForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(ToDoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ToDoPriorities = _context.ToDoPriorities.ToList();
                return View("ToDoForm", viewModel);
            }

            var toDo = new ToDoList
            {
                Name = viewModel.Name,
                CreatedAt = viewModel.CreatedAt,
                Description = viewModel.Description,
                Time = viewModel.Time,
                ToDoPrioritiesId = viewModel.ToDoPriority,
                ToDoStatus = viewModel.ToDoStatus
            };

            _context.ToDoLists.Add(toDo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ToDoFormViewModel viewModel)
        {
            var todo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .Single(t => t.Id == viewModel.Id);

            todo.Name = viewModel.Name;
            todo.Description = viewModel.Description;
            todo.Time = viewModel.Time;
            todo.ToDoPrioritiesId = viewModel.ToDoPriority;
            todo.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Email()
        {

            return View();
        }
    }
}