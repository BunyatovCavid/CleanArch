using Domain.Entities;
using Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;

namespace Domain.Interface.Services
{
    public interface IActorService
    {
        public Task<List<Actor>> Get();
        public Task<Actor> GetByid(int id);
        public Task<Actor> Post(ActorDto ActorDto);
        public Task<Actor> Put(int id, ActorDto ActorDto);
        public Task<string> DeleteActor(int id);
    }
}
