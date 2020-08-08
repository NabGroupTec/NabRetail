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
    public class Mobile_NewPeopleController : ControllerBase
    {
        private readonly NabContext _context;

        public Mobile_NewPeopleController(NabContext context)
        {
            _context = context;
        }

        // GET: api/Mobile_NewPeople
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mobile_NewPeople>>> GetMobile_NewPeople()
        {
            return await _context.Mobile_NewPeople.ToListAsync();
        }

        // GET: api/Mobile_NewPeople/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mobile_NewPeople>> GetMobile_NewPeople(long id)
        {
            var mobile_NewPeople = await _context.Mobile_NewPeople.FindAsync(id);

            if (mobile_NewPeople == null)
            {
                return NotFound();
            }

            return mobile_NewPeople;
        }

        // PUT: api/Mobile_NewPeople/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobile_NewPeople(long id, Mobile_NewPeople mobile_NewPeople)
        {
            if (id != mobile_NewPeople.Id)
            {
                return BadRequest();
            }

            _context.Entry(mobile_NewPeople).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Mobile_NewPeopleExists(id))
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

        // POST: api/Mobile_NewPeople
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Mobile_NewPeople>> PostMobile_NewPeople(Mobile_NewPeople mobile_NewPeople)
        {
            _context.Mobile_NewPeople.Add(mobile_NewPeople);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobile_NewPeople", new { id = mobile_NewPeople.Id }, mobile_NewPeople);
        }

        // DELETE: api/Mobile_NewPeople/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mobile_NewPeople>> DeleteMobile_NewPeople(long id)
        {
            var mobile_NewPeople = await _context.Mobile_NewPeople.FindAsync(id);
            if (mobile_NewPeople == null)
            {
                return NotFound();
            }

            _context.Mobile_NewPeople.Remove(mobile_NewPeople);
            await _context.SaveChangesAsync();

            return mobile_NewPeople;
        }

        private bool Mobile_NewPeopleExists(long id)
        {
            return _context.Mobile_NewPeople.Any(e => e.Id == id);
        }
    }
}
