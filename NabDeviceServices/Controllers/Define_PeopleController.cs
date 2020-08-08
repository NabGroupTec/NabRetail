using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NabDeviceServices.Models;

namespace NabDeviceServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Define_PeopleController : ControllerBase
    {
        private readonly NabContext _context;

        public Define_PeopleController(NabContext context)
        {
            _context = context;
        }

        // GET: api/Define_People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Define_People>>> GetDefine_People()
        {
            return await _context.Define_People.ToListAsync();
        }

        // GET: api/Define_People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Define_People>> GetDefine_People(long id)
        {
            var define_People = await _context.Define_People.FindAsync(id);

            if (define_People == null)
            {
                return NotFound();
            }

            return define_People;
        }

        // PUT: api/Define_People/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefine_People(long id, Define_People define_People)
        {
            if (id != define_People.ID)
            {
                return BadRequest();
            }

            _context.Entry(define_People).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Define_PeopleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Define_People
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Define_People>> PostDefine_People(Define_People define_People)
        {
            _context.Define_People.Add(define_People);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefine_People", new { id = define_People.ID }, define_People);
        }

        // DELETE: api/Define_People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Define_People>> DeleteDefine_People(long id)
        {
            var define_People = await _context.Define_People.FindAsync(id);
            if (define_People == null)
            {
                return NotFound();
            }

            _context.Define_People.Remove(define_People);
            await _context.SaveChangesAsync();

            return define_People;
        }

        private bool Define_PeopleExists(long id)
        {
            return _context.Define_People.Any(e => e.ID == id);
        }
    }
}
