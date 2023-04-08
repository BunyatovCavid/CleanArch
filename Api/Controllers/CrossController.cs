using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Interface.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;

namespace Movie_Library_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorMovieController : ControllerBase
    {
        ICrossService _cross;

        public ActorMovieController(ICrossService cross)
        {
            _cross = cross;
        }

        [HttpGet]
        public async Task<Movie> GetMoviieByTitle([FromQuery] string title, [FromQuery] string actorname)
        {
            var data = await _cross.GetMoviieByTitleActor(title, actorname);
            return data;
        }

        [HttpGet("{id}")]
        public async Task<ICollection<Actor>> GetActorById([FromQuery] int id)
        {
            var data = await _cross.GetActorByMovieId(id);
            return data;
        }
        [HttpPost]
        public async Task<Movie> PostMovieActor([FromQuery] CrossDto actorMovieDto)
        {
            var data = await _cross.PostActorToMovie(actorMovieDto);
            return data;
        }

        [HttpDelete]
        public async Task<string> DeleteMovie([FromQuery] int id)
        {
            var data = await _cross.DeleteActorsByIdFromMovie(id);
            return data;
        }


    }
}
