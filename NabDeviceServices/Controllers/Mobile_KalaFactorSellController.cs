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
    public class Mobile_KalaFactorSellController : ControllerBase
    {
        private readonly NabContext _context;

        public Mobile_KalaFactorSellController(NabContext context)
        {
            _context = context;
        }

        // GET: api/Mobile_KalaFactorSell
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mobile_KalaFactorSell>>> GetMobile_KalaFactorSell()
        {
            try
            {
                return await _context.Mobile_KalaFactorSell.ToListAsync();
            }
            catch (Exception e)
            {
                string message = e.Message;
                return NotFound();
            }

        }

        // GET: api/Mobile_KalaFactorSell/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mobile_KalaFactorSell>> GetMobile_KalaFactorSell(long id)
        {
            var mobile_KalaFactorSell = await _context.Mobile_KalaFactorSell.FindAsync(id);

            if (mobile_KalaFactorSell == null)
            {
                return NotFound();
            }

            return mobile_KalaFactorSell;
        }

        // PUT: api/Mobile_KalaFactorSell/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobile_KalaFactorSell(long id, Mobile_KalaFactorSell mobile_KalaFactorSell)
        {
            if (id != mobile_KalaFactorSell.ID)
            {
                return BadRequest();
            }

            _context.Entry(mobile_KalaFactorSell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Mobile_KalaFactorSellExists(id))
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

        // POST: api/Mobile_KalaFactorSell
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mobile_KalaFactorSell>> PostMobile_KalaFactorSell(Mobile_KalaFactorSell mobile_KalaFactorSell)
        {
            _context.Mobile_KalaFactorSell.Add(mobile_KalaFactorSell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobile_KalaFactorSell", new { id = mobile_KalaFactorSell.ID }, mobile_KalaFactorSell);
        }

        // DELETE: api/Mobile_KalaFactorSell/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mobile_KalaFactorSell>> DeleteMobile_KalaFactorSell(long id)
        {
            var mobile_KalaFactorSell = await _context.Mobile_KalaFactorSell.FindAsync(id);
            if (mobile_KalaFactorSell == null)
            {
                return NotFound();
            }

            _context.Mobile_KalaFactorSell.Remove(mobile_KalaFactorSell);
            await _context.SaveChangesAsync();

            return mobile_KalaFactorSell;
        }

        private bool Mobile_KalaFactorSellExists(long id)
        {
            return _context.Mobile_KalaFactorSell.Any(e => e.ID == id);
        }
    }
}
