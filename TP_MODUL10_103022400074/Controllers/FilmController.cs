using Microsoft.AspNetCore.Mvc;
using TP_MODUL10_103022400074.Models;

namespace TP_MODUL10_103022400074.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class FilmController : ControllerBase
        {
          
            private static List<Film> _films = new List<Film>
        {
            new Film("Inception", "Christopher Nolan", "2010", "Sci-Fi", "9.0"),
            new Film("Interstellar", "Christopher Nolan", "2014", "Sci-Fi", "8.7"),
            new Film("Parasite", "Bong Joon-ho", "2019", "Thriller", "8.6")
        };

            
            [HttpGet]
            public ActionResult<IEnumerable<Film>> GetAllFilms()
            {
                return Ok(_films);
            }

            
            [HttpGet("{index}")]
            public ActionResult<Film> GetFilmByIndex(int index)
            {
                if (index < 0 || index >= _films.Count)
                    return NotFound($"Film dengan index {index} tidak ditemukan.");
                return Ok(_films[index]);
            }

            
            [HttpPost]
            public ActionResult<Film> AddFilm([FromBody] Film film)
            {
                _films.Add(film);
                return Ok(film);
            }

            
            [HttpDelete("{index}")]
            public ActionResult DeleteFilm(int index)
            {
                if (index < 0 || index >= _films.Count)
                    return NotFound($"Film dengan index {index} tidak ditemukan.");
                _films.RemoveAt(index);
                return Ok();
            }
        }
    }
