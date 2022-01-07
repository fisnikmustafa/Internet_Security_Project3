using Microsoft.AspNetCore.Mvc;
namespace TodoApp.Controllers
{
    [Route("api/[controller]")]     //api/todo
    [ApiController]

    public class TodoController : ControllerBase
    {
        [HttpGet]

        public IActionResult TestRun()
        {
            return Ok("success");
        }
    }
}