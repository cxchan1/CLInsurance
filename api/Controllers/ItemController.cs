using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private  NudeDBContext _context;

        public ItemController(NudeDBContext context)
        {
            _context = context;
        }

        // GET api/Item
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            var items = _context.Items.Where(a => a.Active == true).ToList();
            return items;
        }

        // GET api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NoContent();
            }

            return item;
        }

        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (!(item.CategoryId >= 0) || String.IsNullOrEmpty(item.Name))
            {
                return BadRequest();
            }

            Item newItem = new Item();
            newItem.CategoryId = item.CategoryId;
            newItem.Name = item.Name;
            newItem.Price = item.Price;
            newItem.Active = true;
            newItem.DateCreated = DateTime.Now;

            _context.Items.Add(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = newItem.id }, newItem);
        }

        // DELETE: api/Item/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var res = await _context.Items.FindAsync(id);
            if (res == null)
            {
                return NotFound();
            }

            Item deleted = new Item();

            deleted = res;

            deleted.Active = false;

            _context.Entry(deleted).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
