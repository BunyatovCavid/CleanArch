using Application.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Domain.Interface.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie_Library_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        IMovieService _Movie;
        public MovieController(IMovieService movie)
        {
            _Movie = movie;
        }

        [HttpGet]
        public async Task<List<Movie>> GetMovie()
        {
            var data = await _Movie.Get();
            return data;
        }

        [HttpGet("{id}")]
        public async Task<Movie> GetMovieById([FromQuery] int id)
        {
            var data = await _Movie.GetByid(id);
            return data;
        }
        [HttpPost]
        public async Task<Movie> PostMovie([FromQuery] MovieDto MovieDto)
        {
            var data = await _Movie.Post(MovieDto);
            return data;
        }
        [HttpPut]
        public async Task<Movie> PutMovie([FromQuery] int id, [FromQuery] MovieDto MovieDto)
        {
            var data = await _Movie.Put(id, MovieDto);
            return data;
        }
        [HttpDelete]
        public async Task<string> DeleteMovie([FromQuery] int id)
        {
            var data = await _Movie.Delete(id);
            return data;
        }

    }
}
