using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DisneyAPI.Data;
using DisneyAPI.Models;
using Microsoft.AspNetCore.Authorization;
using DisneyAPI.Auth;

namespace DisneyAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterMoviesController : ControllerBase
    {
        private readonly DisneyAPIContext _context;

        public CharacterMoviesController(DisneyAPIContext context)
        {
            _context = context;
        }

        // GET: api/CharacterMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterMovie>>> GetCharacterMovies()
        {
            return await _context.CharacterMovies.ToListAsync();
        }

        // GET: api/CharacterMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterMovie>> GetCharacterMovie(int id)
        {
            var characterMovie = await _context.CharacterMovies.FindAsync(id);

            if (characterMovie == null)
            {
                return NotFound();
            }

            return characterMovie;
        }

        // PUT: api/CharacterMovies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterMovie(int id, CharacterMovie characterMovie)
        {
            if (id != characterMovie.ID)
            {
                return BadRequest();
            }

            _context.Entry(characterMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterMovieExists(id))
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

        // POST: api/CharacterMovies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterMovie>> PostCharacterMovie(CharacterMovie characterMovie)
        {
            _context.CharacterMovies.Add(characterMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacterMovie", new { id = characterMovie.ID }, characterMovie);
        }

        // DELETE: api/CharacterMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterMovie(int id)
        {
            var characterMovie = await _context.CharacterMovies.FindAsync(id);
            if (characterMovie == null)
            {
                return NotFound();
            }

            _context.CharacterMovies.Remove(characterMovie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterMovieExists(int id)
        {
            return _context.CharacterMovies.Any(e => e.ID == id);
        }
    }
}
