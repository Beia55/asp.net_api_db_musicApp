using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_3_MusicApp_API_DataBases.Data;
using Project_3_MusicApp_API_DataBases.Models;

namespace Project_3_MusicApp_API_DataBases.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly Project_3_MusicApp_API_DataBasesContext _context;

        public SongsController(Project_3_MusicApp_API_DataBasesContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<Song[]>> GetSong()
        {
            return await _context.Song.ToArrayAsync();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(Guid id)
        {
            var song = await _context.Song.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(Guid id, Song song)
        {
            if (id != song.ID)
            {
                return BadRequest();
            }

            Song dbSong = _context.Song.FirstOrDefault(x => x.ID == song.ID);

            dbSong.Name = song.Name;
            dbSong.Composer = song.Composer;
            dbSong.Year = song.Year;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            _context.Song.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.ID }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(Guid id)
        {
            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Song.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(Guid id)
        {
            return _context.Song.Any(e => e.ID == id);
        }
    }
}
