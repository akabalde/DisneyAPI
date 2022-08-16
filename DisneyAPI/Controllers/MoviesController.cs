using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DisneyAPI.Data;
using DisneyAPI.Models;
using DisneyAPI.Auth;
using Microsoft.AspNetCore.Authorization;

namespace DisneyAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        private readonly DisneyAPIContext _context;

        public MoviesController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv, DisneyAPIContext context)
        {
            hostingEnvironment = hostingEnv;
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(
            [FromQuery] string order,
            [FromQuery] string name)
        {
            if(order == null && name == null)
                return await _context.Movies.ToListAsync();


            IQueryable<Movie> moviesIQ = from m in _context.Movies
                                         select m;

            if (!String.IsNullOrEmpty(name))
            {
                moviesIQ = moviesIQ.Where(m => m.Title.Contains(name));
            }

            else if (order.ToUpper() == "ASC")
                moviesIQ = moviesIQ.OrderBy(m => m.Title);

            else if (order.ToUpper() == "DESC")
                moviesIQ = moviesIQ.OrderByDescending(m => m.Title);

            return await moviesIQ.AsNoTracking().ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.ID)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.ID }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }


        [HttpPost("upload/image/{id}")]
        public async Task<string/*IActionResult*/> PostMovieImage(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return "Movie Not Found";
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

                        movie.ImagePath = path;
                        _context.Entry(movie).State = EntityState.Modified;

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

        [HttpGet("details/{id}")]
        public async Task<ActionResult<Movie>> GetMovieDetails(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.CharacterMovies)
                .ThenInclude(e => e.Character)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }
       
    }
}
