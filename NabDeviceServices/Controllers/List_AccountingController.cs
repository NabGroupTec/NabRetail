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
    public class List_AccountingController : ControllerBase
    {
        private readonly NabManagementContext _context;

        public List_AccountingController(NabManagementContext context)
        {
            _context = context;
        }

        // GET: api/List_Accounting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<List_Accounting>>> GetList_Accounting()
        {
            return await _context.List_Accounting.ToListAsync();
        }

        // GET: api/List_Accounting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List_Accounting>> GetList_Accounting(long id)
        {
            var list_Accounting = await _context.List_Accounting.FindAsync(id);

            if (list_Accounting == null)
            {
                return NotFound();
            }

            return list_Accounting;
        }

        // PUT: api/List_Accounting/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutList_Accounting(long id, List_Accounting list_Accounting)
        {
            if (id != list_Accounting.Id)
            {
                return BadRequest();
            }

            _context.Entry(list_Accounting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!List_AccountingExists(id))
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

        // POST: api/List_Accounting
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<List_Accounting>> PostList_Accounting(List_Accounting list_Accounting)
        {
            _context.List_Accounting.Add(list_Accounting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetList_Accounting", new { id = list_Accounting.Id }, list_Accounting);
        }

        // DELETE: api/List_Accounting/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List_Accounting>> DeleteList_Accounting(long id)
        {
            var list_Accounting = await _context.List_Accounting.FindAsync(id);
            if (list_Accounting == null)
            {
                return NotFound();
            }

            _context.List_Accounting.Remove(list_Accounting);
            await _context.SaveChangesAsync();

            return list_Accounting;
        }

        private bool List_AccountingExists(long id)
        {
            return _context.List_Accounting.Any(e => e.Id == id);
        }
    }
}
