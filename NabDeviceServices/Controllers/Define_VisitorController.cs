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
    public class Define_VisitorController : ControllerBase
    {
        private readonly NabContext _context;

        public Define_VisitorController(NabContext context)
        {
            _context = context;
        }

        // GET: api/Define_Visitor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Define_Visitor>>> GetDefine_Visitor()
        {
            return await _context.Define_Visitor.ToListAsync();
        }

        // GET: api/Define_Visitor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Define_Visitor>> GetDefine_Visitor(long id)
        {
            var define_Visitor = await _context.Define_Visitor.FindAsync(id);

            if (define_Visitor == null)
            {
                return NotFound();
            }

            return define_Visitor;
        }

        // PUT: api/Define_Visitor/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefine_Visitor(long id, Define_Visitor define_Visitor)
        {
            if (id != define_Visitor.Id)
            {
                return BadRequest();
            }

            _context.Entry(define_Visitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Define_VisitorExists(id))
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

        // POST: api/Define_Visitor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Define_Visitor>> PostDefine_Visitor(Define_Visitor define_Visitor)
        {
            _context.Define_Visitor.Add(define_Visitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefine_Visitor", new { id = define_Visitor.Id }, define_Visitor);
        }

        // DELETE: api/Define_Visitor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Define_Visitor>> DeleteDefine_Visitor(long id)
        {
            var define_Visitor = await _context.Define_Visitor.FindAsync(id);
            if (define_Visitor == null)
            {
                return NotFound();
            }

            _context.Define_Visitor.Remove(define_Visitor);
            await _context.SaveChangesAsync();

            return define_Visitor;
        }

        private bool Define_VisitorExists(long id)
        {
            return _context.Define_Visitor.Any(e => e.Id == id);
        }
    }
}
