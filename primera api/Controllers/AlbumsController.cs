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
    public class AlbumsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlbumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> Get()
        {
            return await _context.Set<Album>()
                .AsQueryable()
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Album>> Add(Album album)
        {
            _context.Album.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = album.Id }, album);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> Delete(int id)
        {
            var album = await _context.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Album.Remove(album);
            await _context.SaveChangesAsync();

            return album;
        }
    }
}
