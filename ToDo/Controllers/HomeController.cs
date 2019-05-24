using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ToDo.Core.Models;
using ToDo.Core.ViewModels;
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

            var viewModel = new List<ToDoViewModel>();

            foreach (var toDoList in toDo)
            {
                viewModel.Add(new ToDoViewModel
                {
                    CreatedAt = toDoList.CreatedAt,
                    Description = toDoList.Description,
                    Id = toDoList.Id,
                    Name = toDoList.Name,
                    Time = toDoList.Time,
                    ToDoPriorities = toDoList.ToDoPriorities,
                    ToDoPrioritiesId = toDoList.ToDoPrioritiesId,
                    ToDoStatus = toDoList.ToDoStatus
                });
            }
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortByName()
        {
            var toDo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .ToList();

            var viewModel = new List<ToDoViewModel>();

            foreach (var toDoList in toDo)
            {
                viewModel.Add(new ToDoViewModel
                {
                    CreatedAt = toDoList.CreatedAt,
                    Description = toDoList.Description,
                    Id = toDoList.Id,
                    Name = toDoList.Name,
                    Time = toDoList.Time,
                    ToDoPriorities = toDoList.ToDoPriorities,
                    ToDoPrioritiesId = toDoList.ToDoPrioritiesId,
                    ToDoStatus = toDoList.ToDoStatus
                });
            }
            return View("Index", viewModel.OrderBy(v => v.Name)); 
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortByPriority()
        {
            var toDo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .ToList();

            var viewModel = new List<ToDoViewModel>();

            foreach (var toDoList in toDo)
            {
                viewModel.Add(new ToDoViewModel
                {
                    CreatedAt = toDoList.CreatedAt,
                    Description = toDoList.Description,
                    Id = toDoList.Id,
                    Name = toDoList.Name,
                    Time = toDoList.Time,
                    ToDoPriorities = toDoList.ToDoPriorities,
                    ToDoPrioritiesId = toDoList.ToDoPrioritiesId,
                    ToDoStatus = toDoList.ToDoStatus
                });
            }
            return View("Index", viewModel.OrderByDescending(v => v.ToDoPrioritiesId));
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortByStatus()
        {
            var toDo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .ToList();

            var viewModel = new List<ToDoViewModel>();

            foreach (var toDoList in toDo)
            {
                viewModel.Add(new ToDoViewModel
                {
                    CreatedAt = toDoList.CreatedAt,
                    Description = toDoList.Description,
                    Id = toDoList.Id,
                    Name = toDoList.Name,
                    Time = toDoList.Time,
                    ToDoPriorities = toDoList.ToDoPriorities,
                    ToDoPrioritiesId = toDoList.ToDoPrioritiesId,
                    ToDoStatus = toDoList.ToDoStatus
                });
            }
            return View("Index", viewModel.OrderBy(t => t.ToDoStatus == ToDoStatus.Done));
        }

        [Authorize]
        [HttpGet]
        public ActionResult Date()
        {
            var todo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .ToList();
            var viewModel = new List<ToDoViewModel>();

            foreach (var toDoList in todo)
            {
                viewModel.Add(new ToDoViewModel
                {
                    CreatedAt = toDoList.CreatedAt,
                    Description = toDoList.Description,
                    Id = toDoList.Id,
                    Name = toDoList.Name,
                    Time = toDoList.Time,
                    ToDoPriorities = toDoList.ToDoPriorities,
                    ToDoPrioritiesId = toDoList.ToDoPrioritiesId,
                    ToDoStatus = toDoList.ToDoStatus
                });
            }

            return View("Index", ToDoViewModel.OrderDate(viewModel));
        }

        [Authorize]
        [HttpGet]
        public ActionResult Time()
        {
            var todo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .ToList();

            var viewModel = new List<ToDoViewModel>();

            foreach (var toDoList in todo)
            {
                viewModel.Add(new ToDoViewModel
                {
                    CreatedAt = toDoList.CreatedAt,
                    Description = toDoList.Description,
                    Id = toDoList.Id,
                    Name = toDoList.Name,
                    Time = toDoList.Time,
                    ToDoPriorities = toDoList.ToDoPriorities,
                    ToDoPrioritiesId = toDoList.ToDoPrioritiesId,
                    ToDoStatus = toDoList.ToDoStatus
                });
            }

            return View("Index", ToDoViewModel.OrderTime(viewModel));
        }
    }
}