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
    public class CategoryController : ControllerBase
    {
        private NudeDBContext _context;

        public CategoryController(NudeDBContext context)
        {
            _context = context;
        }

        // GET api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetItems()
        {
            string con = _context.Database.GetDbConnection().ConnectionString;
            return await _context.Categories.ToListAsync();
        }

        // GET api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetItem(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NoContent();
            }

            return category;
        }
    }
}
