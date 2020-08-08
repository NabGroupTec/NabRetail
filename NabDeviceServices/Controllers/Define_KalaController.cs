using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NabDeviceServices.Infrastructure;
using NabDeviceServices.Models;

namespace NabDeviceServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Define_KalaController : ControllerBase
    {
        private readonly NabContext _context;

        public Define_KalaController(NabContext context)
        {
            _context = context;
        }

        // GET: api/Define_Kala
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Define_Kala>>> GetDefineKala()
        {
            string query = string.Format(@"SELECT
   Id,
  Nam,
  DK_KOL,
  DK_JOZ,
  ROUND(KolCount, 2) KolCount,
  ROUND(JozCount, 2) JozCount,
  (SELECT
    CASE
      WHEN Fe > 0 THEN Fe
      ELSE (SELECT
          ISNULL(SUM(Fe), 0) AS Fe
        FROM (SELECT TOP 1
          Fe
        FROM (SELECT
          Fe,
          KalaFactorSell.IdFactor
        FROM KalaFactorSell
        WHERE KalaFactorSell.IdKala = EndData.Id
        AND KalaFactorSell.Activ = 1
        AND KalaFactorSell.Fe > 0) AS ListKala
        INNER JOIN ListFactorSell
          ON ListFactorSell.IdFactor = ListKala.IdFactor
        ORDER BY D_date DESC) AS EndCost)
    END AS Fe
  FROM (SELECT
    ISNULL(SUM(CostBigKala), 0) AS Fe
  FROM (SELECT TOP 1
    CostBigKala
  FROM Define_CostKala
  WHERE IdKala = EndData.Id
  AND CostBigKala > 0
  ORDER BY Id DESC) AS CityFe) AS ListCost)
  AS Price
FROM (SELECT
  AllKala.*,
  (SELECT
    ISNULL(SUM(CASE
      WHEN KolCount >= 0 THEN KolCount
    END), 0) + ISNULL(SUM(CASE
      WHEN KolCount < 0 THEN KolCount
    END), 0)
  FROM (SELECT
    ISNULL(SUM(Count_Kol), 0) AS KolCount
  FROM Define_PrimaryKala
  WHERE IdKala = AllKala.id
  UNION ALL
  SELECT
    ISNULL(SUM(KalaFactorBuy.KolCount), 0) AS KolCount
  FROM KalaFactorBuy
  INNER JOIN ListFactorBuy
    ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor
  WHERE (KalaFactorBuy.Activ = 1
  AND ListFactorBuy.Activ = 1
  AND ListFactorBuy.Stat = 0)
  AND IdKala = AllKala.id
  UNION ALL
  SELECT
    ISNULL(SUM(KalaFactorBackSell.KolCount), 0) AS KolCount
  FROM KalaFactorBackSell
  INNER JOIN ListFactorBackSell
    ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor
  WHERE (KalaFactorBackSell.Activ = 1
  AND ListFactorBackSell.Activ = 1)
  AND IdKala = AllKala.id
  UNION ALL
  SELECT
    ISNULL(SUM(KalaFactorSell.KolCount) * (-1), 0) AS KolCount
  FROM KalaFactorSell
  INNER JOIN ListFactorSell
    ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor
  WHERE (KalaFactorSell.Activ = 1
  AND ListFactorSell.Activ = 1
  AND ListFactorSell.Stat = 3)
  AND IdKala = AllKala.id
  UNION ALL
  SELECT
    ISNULL(SUM(KalaFactorBackBuy.KolCount) * (-1), 0) AS KolCount
  FROM KalaFactorBackBuy
  INNER JOIN listFactorBackBuy
    ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor
  WHERE (KalaFactorBackBuy.Activ = 1
  AND listFactorBackBuy.Activ = 1)
  AND IdKala = AllKala.id
  UNION ALL
  SELECT
    ISNULL(SUM(KalaFactorDamage.KolCount) * (-1), 0) AS KolCount
  FROM KalaFactorDamage
  INNER JOIN listFactorDamage
    ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor
  WHERE (KalaFactorDamage.Activ = 1
  AND ListFactorDamage.Activ = 1)
  AND IdKala = AllKala.id) AS AllKolCount)
  KolCount,
  (SELECT
    ISNULL(SUM(CASE
      WHEN AllJozCount.JozCount >= 0 THEN AllJozCount.JozCount
    END), 0) + ISNULL(SUM(CASE
      WHEN AllJozCount.JozCount < 0 THEN AllJozCount.JozCount
    END), 0)
  FROM (SELECT
    ISNULL(SUM(Count_joz), 0) AS JozCount
  FROM Define_PrimaryKala
  WHERE IdKala = AllKala.id
  UNION ALL
  SELECT
    ISNULL(SUM(KalaFactorBuy.JozCount), 0) AS JozCount
  FROM KalaFactorBuy
  INNER JOIN ListFactorBuy
    ON KalaFactorBuy.IdFactor = ListFactorBuy.IdFactor
  WHERE (KalaFactorBuy.Activ = 1
  AND ListFactorBuy.Activ = 1
  AND ListFactorBuy.Stat = 0)
  AND IdKala = AllKala.id
  UNION ALL
  SELECT
    ISNULL(SUM(KalaFactorBackSell.JozCount), 0) AS JozCount
  FROM KalaFactorBackSell
  INNER JOIN ListFactorBackSell
    ON KalaFactorBackSell.IdFactor = ListFactorBackSell.IdFactor
  WHERE (KalaFactorBackSell.Activ = 1
  AND ListFactorBackSell.Activ = 1)
  AND IdKala = AllKala.id
  UNION ALL
  SELECT
    ISNULL(SUM(KalaFactorSell.JozCount) * (-1), 0) AS JozCount
  FROM KalaFactorSell
  INNER JOIN ListFactorSell
    ON KalaFactorSell.IdFactor = ListFactorSell.IdFactor
  WHERE (KalaFactorSell.Activ = 1
  AND ListFactorSell.Activ = 1
  AND ListFactorSell.Stat = 3)
  AND IdKala = AllKala.id
  UNION ALL
  SELECT
    ISNULL(SUM(KalaFactorBackBuy.JozCount) * (-1), 0) AS JozCount
  FROM KalaFactorBackBuy
  INNER JOIN listFactorBackBuy
    ON KalaFactorBackBuy.IdFactor = ListFactorBackBuy.IdFactor
  WHERE (KalaFactorBackBuy.Activ = 1
  AND listFactorBackBuy.Activ = 1)
  AND IdKala = AllKala.id
  UNION ALL
  SELECT
    ISNULL(SUM(KalaFactorDamage.JozCount) * (-1), 0) AS JozCount
  FROM KalaFactorDamage
  INNER JOIN listFactorDamage
    ON KalaFactorDamage.IdFactor = ListFactorDamage.IdFactor
  WHERE (KalaFactorDamage.Activ = 1
  AND ListFactorDamage.Activ = 1)
  AND IdKala = AllKala.id) AS AllJozCount)
  JozCount
FROM (SELECT
  Id,
  Nam,
  DK_KOL,
  DK_JOZ
FROM Define_Kala WHERE Define_Kala.Activ ='False') AS AllKala) AS EndData");

            var result = Helper.RawSqlQuery(_context, query,
                x=>new Define_Kala{Id=(long)x[0],Nam = (string)x[1],DK_JOZ = (double)x[3],DK_KOL = (long)x[2],JozCount = (double)x[5],KolCount = (double)x[4],Price = (long)x[6]});


            return  result;// _context.DefineKala.ToListAsync();
        }

        // GET: api/Define_Kala/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Define_Kala>> GetDefine_Kala(long id)
        {
            var define_Kala = await _context.DefineKala.FindAsync(id);

            if (define_Kala == null)
            {
                return NotFound();
            }

            return define_Kala;
        }

        // PUT: api/Define_Kala/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefine_Kala(long id, Define_Kala define_Kala)
        {
            if (id != define_Kala.Id)
            {
                return BadRequest();
            }

            _context.Entry(define_Kala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Define_KalaExists(id))
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

        // POST: api/Define_Kala
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Define_Kala>> PostDefine_Kala(Define_Kala define_Kala)
        {
            _context.DefineKala.Add(define_Kala);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefine_Kala", new { id = define_Kala.Id }, define_Kala);
        }

        // DELETE: api/Define_Kala/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Define_Kala>> DeleteDefine_Kala(long id)
        {
            var define_Kala = await _context.DefineKala.FindAsync(id);
            if (define_Kala == null)
            {
                return NotFound();
            }

            _context.DefineKala.Remove(define_Kala);
            await _context.SaveChangesAsync();

            return define_Kala;
        }

        private bool Define_KalaExists(long id)
        {
            return _context.DefineKala.Any(e => e.Id == id);
        }
    }
}
