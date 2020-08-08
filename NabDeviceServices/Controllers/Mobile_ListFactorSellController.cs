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
    public class Mobile_ListFactorSellController : ControllerBase
    {
        private readonly NabContext _context;

        public Mobile_ListFactorSellController(NabContext context)
        {
            _context = context;
        }

        // GET: api/Mobile_ListFactorSell
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mobile_ListFactorSell>>> GetMobile_ListFactorSell()
        {
            return await _context.Mobile_ListFactorSell.ToListAsync();
        }

        // GET: api/Mobile_ListFactorSell/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mobile_ListFactorSell>> GetMobile_ListFactorSell(long id)
        {
            var mobile_ListFactorSell = await _context.Mobile_ListFactorSell.FindAsync(id);

            if (mobile_ListFactorSell == null)
            {
                return NotFound();
            }

            return mobile_ListFactorSell;
        }

        // PUT: api/Mobile_ListFactorSell/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobile_ListFactorSell(long id, Mobile_ListFactorSell mobile_ListFactorSell)
        {
            if (id != mobile_ListFactorSell.IdFactor)
            {
                return BadRequest();
            }

            _context.Entry(mobile_ListFactorSell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Mobile_ListFactorSellExists(id))
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

        // POST: api/Mobile_ListFactorSell
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mobile_ListFactorSell>> PostMobile_ListFactorSell(Mobile_ListFactorSell mobile_ListFactorSell)
        {
            _context.Mobile_ListFactorSell.Add(mobile_ListFactorSell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobile_ListFactorSell", new { id = mobile_ListFactorSell.IdFactor }, mobile_ListFactorSell);
        }

        // DELETE: api/Mobile_ListFactorSell/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mobile_ListFactorSell>> DeleteMobile_ListFactorSell(long id)
        {
            var mobile_ListFactorSell = await _context.Mobile_ListFactorSell.FindAsync(id);
            if (mobile_ListFactorSell == null)
            {
                return NotFound();
            }

            _context.Mobile_ListFactorSell.Remove(mobile_ListFactorSell);
            await _context.SaveChangesAsync();

            return mobile_ListFactorSell;
        }

        private bool Mobile_ListFactorSellExists(long id)
        {
            return _context.Mobile_ListFactorSell.Any(e => e.IdFactor == id);
        }
    }
}
