using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week3_Tema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Models.Movie> movies = new List<Models.Movie>()
        {
            new Models.Movie() { ID = Guid.NewGuid(), Name = "Movie1" },
            new Models.Movie() { ID = Guid.NewGuid(), Name = "Movie2" },
            new Models.Movie() { ID = Guid.NewGuid(), Name = "Movie3" },
            new Models.Movie() { ID = Guid.NewGuid(), Name = "Movie4" },
            new Models.Movie() { ID = Guid.NewGuid(), Name = "Movie5" }
        };

        [HttpGet]
        public Models.Movie[] Get()
        {
            return movies.ToArray();
        }

        [HttpPost]
        public void Post([FromBody] Models.Movie movie)
        {
            if (movie.ID == Guid.Empty)
                movie.ID = Guid.NewGuid();

            movies.Add(movie);
        }

        [HttpPut]
        public void Put([FromBody] Models.Movie movie)
        {
            Models.Movie currentMovie = movies.FirstOrDefault(x => x.ID == movie.ID);
            currentMovie.Name = movie.Name;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            movies.RemoveAll(movie => movie.ID == id);

            //foreach (Models.Movie movie in movies)
            //{
            //    if (movie.ID == id)
            //    {
            //        movies.Remove(movie);
            //    }
            //}
        }
    }
}
