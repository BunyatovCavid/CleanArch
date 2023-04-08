using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repositories
{
    public interface IActorRepository
    {
        public Task<List<Actor>> Get();
        public Task<Actor> GetByid(int id);
        public Task Post(Actor new_entity);
        public Task<Actor> GetActor(string name);
        public Task<Actor> Put(int id, Actor new_entity);
        public Task Delete(Actor actor);

    }
}
