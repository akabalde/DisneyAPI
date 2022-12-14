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
    public class GenresController : ControllerBase
    {
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        private readonly DisneyAPIContext _context;

        public GenresController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv, DisneyAPIContext context)
        {
            hostingEnvironment = hostingEnv;
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.ID)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.ID }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.ID == id);
        }


        [HttpPost("upload/image/{id}")]
        public async Task<string/*IActionResult*/> PostGenreImage(int id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                return "Genre Not Found";
            }

            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        FileInfo fi = new FileInfo(file.FileName);
                        var newFileName = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                        var path = Path.Combine("", hostingEnvironment.ContentRootPath + "\\Images\\" + newFileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);

                        }

                        genre.ImagePath = path;
                        _context.Entry(genre).State = EntityState.Modified;

                        await _context.SaveChangesAsync();
                    }
                    return "Saved Successfully";
                }
                else
                {
                    return "Select File";
                }
            }
            catch (Exception)
            {
                return "Invalid Request";
                //throw;
            }

        }
    }
}
