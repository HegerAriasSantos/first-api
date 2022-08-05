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
    public class SongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> Get()
        {
            // return await _context.Set<Song>()
            //    .AsQueryable()
            //    .ToListAsync();
            return await _context.Song.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Song>> Add(Song song)
        {
            _context.Song.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = song.Id }, song);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Song>> Delete(int id)
        {
            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Song.Remove(song);
            await _context.SaveChangesAsync();

            return song;
        }
    }
}
