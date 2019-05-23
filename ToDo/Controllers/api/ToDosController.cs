using System.Data.Entity;
using System.Linq;
using System.Web.Http;
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

        [HttpGet]
        public IHttpActionResult Get()
        {
            var todo = _context.ToDoLists.Include(t => t.ToDoPriorities).ToList();

            return Ok(todo);
        }
    }
}
