using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.UI.WebControls;
using ToDo.Core.Models;
using ToDo.Persistence;

namespace ToDo.Controllers.api
{
    [Authorize]
    public class ToDosController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ToDosController()
        {
            _context = new ApplicationDbContext();
        }

       // [HttpGet]
       // public IHttpActionResult Get()
       // {
       //     var todo = _context.ToDoLists.Include(t => t.ToDoPriorities).ToList();
       //
       //     return Ok(todo);
       // }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var todo = _context.ToDoLists.Single(t => t.Id == id);

            if (todo == null)
                return NotFound();

            _context.ToDoLists.Remove(todo);
            _context.SaveChanges();

            return Ok(todo);
        }

        [HttpPut]
        public IHttpActionResult ChangeStatus(int id)
        {
            var todo = _context.ToDoLists.Single(t => t.Id == id);

            if (todo == null)
                return BadRequest("There was no such todo.");

            todo.ToDoStatus = todo.ToDoStatus == ToDoStatus.Open ? ToDoStatus.Done : ToDoStatus.Open;

            _context.SaveChanges();

            return Ok(todo);
        }

        [HttpGet]
        public IHttpActionResult SortBy()
        {
            var todos = _context.ToDoLists.OrderBy(t => t.Name);

            return Ok(todos);
        }
    }
}
