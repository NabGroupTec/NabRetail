using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NabDeviceServices.Infrastructure;
using NabDeviceServices.Models;

namespace NabDeviceServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Define_UserController : ControllerBase
    {
        private readonly NabContext _context;

        public Define_UserController(NabContext context)
        {
            _context = context;
        }

        // GET: api/Define_User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Define_User>>> GetDefine_User()
        {
            return await _context.Define_User.ToListAsync();
        }

        // GET: api/Define_User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Define_User>> GetDefine_User(long id)
        {
            var define_User = await _context.Define_User.FindAsync(id);

            if (define_User == null)
            {
                return NotFound();
            }

            return define_User;
        }

        // GET: api/Define_User/dbName/userId/visitorId/password
        [HttpGet("{dbName}/{userId}/{visitorId}/{password}")]
        public async Task<ActionResult<Define_User>> GetDefine_User(string dbName, long userId, long visitorId, string password)
        {
            var defineUser =  _context.Define_User.SingleOrDefault(u => u.Id == userId);
            var dbInfo = await _context.Db_Info.FirstOrDefaultAsync();
            if (defineUser == null)
            {
                return NotFound();
            }
            var key = new System.Security.Cryptography.DESCryptoServiceProvider();
            var sec = new Security();
            key.IV = sec.Kiv;
            key.Key = sec.Kkey;

          var allow=  sec.StringDecrypt((byte[])dbInfo.AllowAdd, key.CreateDecryptor());
          var pass=  sec.StringDecrypt((byte[])defineUser.Pas, key.CreateDecryptor());
          
          if (allow != "0")
              return null;
          
          if (pass != password)
              return null;


            return defineUser;
        }

        // PUT: api/Define_User/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefine_User(int id, Define_User define_User)
        {
            if (id != define_User.Id)
            {
                return BadRequest();
            }

            _context.Entry(define_User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Define_UserExists(id))
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

        // POST: api/Define_User
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Define_User>> PostDefine_User(Define_User define_User)
        {
            _context.Define_User.Add(define_User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefine_User", new { id = define_User.Id }, define_User);
        }

        // DELETE: api/Define_User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Define_User>> DeleteDefine_User(int id)
        {
            var define_User = await _context.Define_User.FindAsync(id);
            if (define_User == null)
            {
                return NotFound();
            }

            _context.Define_User.Remove(define_User);
            await _context.SaveChangesAsync();

            return define_User;
        }

        private bool Define_UserExists(int id)
        {
            return _context.Define_User.Any(e => e.Id == id);
        }
    }
}
