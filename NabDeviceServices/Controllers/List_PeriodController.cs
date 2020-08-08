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
    public class List_PeriodController : ControllerBase
    {
        private readonly NabManagementContext _context;

        public List_PeriodController(NabManagementContext context)
        {
            _context = context;
        }

        // GET: api/List_Period
        [HttpGet]
        public async Task<ActionResult<IEnumerable<List_Period>>> GetListPeriod()
        {
            return await _context.List_Period.ToListAsync();
        }

        // GET: api/List_Period/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List_Period>> GetList_Period(long id)
        {
            var list_Period = await _context.List_Period.FindAsync(id);

            if (list_Period == null)
            {
                return NotFound();
            }

            return list_Period;
        }

        // PUT: api/List_Period/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutList_Period(long id, List_Period list_Period)
        {
            if (id != list_Period.Id)
            {
                return BadRequest();
            }

            _context.Entry(list_Period).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!List_PeriodExists(id))
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

        // POST: api/List_Period
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<List_Period>> PostList_Period(List_Period list_Period)
        {
            _context.List_Period.Add(list_Period);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetList_Period", new { id = list_Period.Id }, list_Period);
        }

        // DELETE: api/List_Period/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List_Period>> DeleteList_Period(long id)
        {
            var list_Period = await _context.List_Period.FindAsync(id);
            if (list_Period == null)
            {
                return NotFound();
            }

            _context.List_Period.Remove(list_Period);
            await _context.SaveChangesAsync();

            return list_Period;
        }

        private bool List_PeriodExists(long id)
        {
            return _context.List_Period.Any(e => e.Id == id);
        }
    }
}
