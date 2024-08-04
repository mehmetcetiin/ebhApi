using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ebhApi.Data;
using ebhApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ebhApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EbhBasvurularController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        // GET: api/EbhBasvurulari
        [Authorize]
        [HttpGet("GetBasvurular")]
        public async Task<ActionResult<IEnumerable<EbhBasvurular>>> GetEbhBasvurulari()
        {
            return await _context.EbhBasvurulari.ToListAsync();
        }

        // GET: api/EbhBasvurulari/5
        [HttpGet("GetBasvuruById/{id}")]
        public async Task<ActionResult<EbhBasvurular>> GetEbhBasvurulariById(int id)
        {
            var basvuru = await _context.EbhBasvurulari.FindAsync(id);

            if (basvuru == null)
            {
                return NotFound();
            }

            return basvuru;
        }

        // POST: api/EbhBasvurulari
        [HttpPost("CreateBasvuru")]
        public async Task<ActionResult<EbhBasvurular>> CreateEbhBasvurulari(EbhBasvurular basvuru)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EbhBasvurulari.Add(basvuru);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEbhBasvurulariById), new { id = basvuru.Id }, basvuru);
        }


        // PUT: api/EbhBasvurulari/5
        [HttpPut("UpdateBasvuru/{id}")]
        public async Task<IActionResult> UpdateEbhBasvurulari(int id, EbhBasvurular basvuru)
        {
            if (id != basvuru.Id)
            {
                return BadRequest();
            }

            _context.Entry(basvuru).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EbhBasvurulariExists(id))
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

        // DELETE: api/EbhBasvurulari/5
        [HttpDelete("DeleteBasvuru/{id}")]
        public async Task<IActionResult> DeleteEbhBasvurulari(int id)
        {
            var basvuru = await _context.EbhBasvurulari.FindAsync(id);
            if (basvuru == null)
            {
                return NotFound();
            }

            _context.EbhBasvurulari.Remove(basvuru);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EbhBasvurulariExists(int id)
        {
            return _context.EbhBasvurulari.Any(e => e.Id == id);
        }
    }
}
