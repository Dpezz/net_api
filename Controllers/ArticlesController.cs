using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private ApplicationDBContext _context;
        public ArticlesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Articles>> Index()
        {
            return _context.Articles.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articles>> Show(int id)
        {
            var data = await _context.Articles.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Articles>> Create([FromBody] Articles data)
        {
            _context.Articles.Add(data);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Show", new { id = data.id }, data);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Articles>> Update(int id, [FromBody] Articles data)
        {
            if (id != data.id)
            {
                return BadRequest();
            }
            _context.Entry(data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var data_exist = _context.Articles.Any(e => e.id == id);
                if (!data_exist)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("Show", new { id = data.id }, data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Articles>> Delete(int id)
        {
            var value = await _context.Articles.FindAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(value);
            await _context.SaveChangesAsync();

            return value;
        }
    }
}
