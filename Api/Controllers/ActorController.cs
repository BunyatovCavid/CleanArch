using Application.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application;
using Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interface.Services;

namespace Movie_Library_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        IActorService _actor;
        public ActorController(IActorService actor)
        {
            _actor = actor;
        }

        [HttpGet]
        public async Task<List<Actor>> GetActor()
        {
            var data = await _actor.Get();
            return data;
        }

        [HttpGet("{id}")]
        public async Task<Actor> GetActorById([FromQuery] int id)
        {
            var data = await _actor.GetByid(id);
            return data;
        }
        [HttpPost]
        public async Task<Actor> PostActor([FromQuery] ActorDto actorDto)
        {
            var data = await _actor.Post(actorDto);
            return data;
        }
        [HttpPut]
        public async Task<Actor> PutActor([FromQuery] int id, [FromQuery] ActorDto actorDto)
        {
            var data = await _actor.Put(id, actorDto);
            return data;
        }
        [HttpDelete]
        public async Task<string> DeleteActor([FromQuery] int id)
        {
            var data = await _actor.DeleteActor(id);
            return data;
        }
    }
}
