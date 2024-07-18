using Microsoft.AspNetCore.Mvc;
using ClassLibraryDal;
using ClassLibraryModel;
using System.Collections.Generic;

namespace SummerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // GET: api/todo
        [HttpGet]
        public ActionResult<IEnumerable<TodoModel>> Get()
        {
            var todos = TodoDal.GetData();
            return Ok(todos);
        }

        // GET: api/todo/5
        [HttpGet("{id}")]
        public ActionResult<TodoModel> Get(int id)
        {
            var todos = TodoDal.GetData();
            var todo = todos.Find(t => t.TodoID == id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // POST: api/todo
        [HttpPost]
        public ActionResult<TodoModel> Post([FromBody] TodoModel todo)
        {
            TodoDal.Insert(todo);
            return CreatedAtAction(nameof(Get), new { id = todo.TodoID }, todo);
        }

        // PUT: api/todo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodoModel todo)
        {
            var existingTodos = TodoDal.GetData();
            var existingTodo = existingTodos.Find(t => t.TodoID == id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            todo.TodoID = id;
            TodoDal.UpdateData(todo);
            return NoContent();
        }

        // DELETE: api/todo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todos = TodoDal.GetData();
            var todo = todos.Find(t => t.TodoID == id);
            if (todo == null)
            {
                return NotFound();
            }

            TodoDal.DeleteData(todo);
            return NoContent();
        }
    }
}
