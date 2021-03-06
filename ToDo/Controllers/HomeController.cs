﻿using Microsoft.AspNet.Identity;
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
        private string UserId => User.Identity.GetUserId();

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

            ToDoViewModel.MapToList(viewModel, toDo);

            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortByName()
        {
            var toDo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .Where(t => t.UserId == UserId)
                .ToList();

            var viewModel = new List<ToDoViewModel>();

            ToDoViewModel.MapToList(viewModel, toDo); ;

            return View("Index", viewModel.OrderBy(v => v.Name)); 
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortByPriority()
        {
            var toDo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .Where(t => t.UserId == UserId)
                .ToList();

            var viewModel = new List<ToDoViewModel>();

            ToDoViewModel.MapToList(viewModel, toDo); ;

            return View("Index", viewModel.OrderByDescending(v => v.ToDoPrioritiesId));
        }

        [Authorize]
        [HttpGet]
        public ActionResult SortByStatus()
        {
            var toDo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .Where(t => t.UserId == UserId)
                .ToList();

            var viewModel = new List<ToDoViewModel>();

            ToDoViewModel.MapToList(viewModel, toDo);

            return View("Index", viewModel.OrderBy(t => t.ToDoStatus == ToDoStatus.Done));
        }

        [Authorize]
        [HttpGet]
        public ActionResult Date()
        {
            var toDo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .Where(t => t.UserId == UserId)
                .ToList();

            var viewModel = new List<ToDoViewModel>();

            ToDoViewModel.MapToList(viewModel, toDo);

            return View("Index", ToDoViewModel.OrderDate(viewModel));
        }

        [Authorize]
        [HttpGet]
        public ActionResult Time()
        {
            var toDo = _context.ToDoLists
                .Include(t => t.ToDoPriorities)
                .Where(t => t.UserId == UserId)
                .ToList();

            var viewModel = new List<ToDoViewModel>();

            ToDoViewModel.MapToList(viewModel, toDo);

            return View("Index", ToDoViewModel.OrderTime(viewModel));
        }
    }
}