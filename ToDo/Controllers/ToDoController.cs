using Microsoft.AspNet.Identity;
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
            var email = new EmailCheck
            {
                ApplicationUserId = User.Identity.GetUserId(),
                ToDoListId = toDo.Id,
                Hour = false,
                HalfAnHour = false

            };

            _context.EmailChecks.Add(email);
            _context.ToDoLists.Add(toDo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            var todo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .Single(t => t.Id == id);

            if (todo == null)
                throw new InvalidOperationException("This todo was not found.");

            var viewModel = new ToDoFormViewModel();
            viewModel.MapFormViewModel(todo);
            viewModel.ToDoPriorities = _context.ToDoPriorities.ToList();

            return View("ToDoForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ToDoFormViewModel viewModel)
        {
            var todo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .Single(t => t.Id == viewModel.Id);

            todo.UpdateToDo(viewModel);

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}