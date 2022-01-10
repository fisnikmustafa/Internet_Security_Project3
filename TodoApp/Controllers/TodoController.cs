using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]     //api/todo
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class TodoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TodoController(ApiDbContext context)
        {
            _context = context;
        }

        // GETTING ITEMS
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }

        // INSERTING ITEMS
        [HttpPost]
        public async Task<IActionResult> CreateItem(ItemData data)
        {
            if (ModelState.IsValid)
            {
                await _context.Items.AddAsync(data);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetItem", new { data.Id }, data);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        //GETTING A SINGLE ITEM
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // UPDATING AN ITEM
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, ItemData item)
        {
            if (id != item.Id)
                return BadRequest();

            // check if the item exists in database
            var exists = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (exists == null)
                return NotFound();

            exists.Title = item.Title;
            exists.Description = item.Description;
            exists.Done = item.Done;

            // implement the changes on the db level
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var exists = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

            if (exists == null)
                return NotFound();

            _context.Items.Remove(exists);

            await _context.SaveChangesAsync();

            return Ok(exists);
        }
    }
}