using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primera_api.Context;
using primera_api.models;

namespace primera_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArtistsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> Get()
        {

           return await _context.Set<Artist>()
                .AsQueryable()
                .Include( x => x.Albums)
                .ThenInclude( x => x.Songs)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> Add(Artist artist)
        {
            _context.Artist.Add(artist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = artist.Id }, artist);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> Delete(int id)
        {
            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artist.Remove(artist);
            await _context.SaveChangesAsync();

            return artist;
        }

        
    }
}
