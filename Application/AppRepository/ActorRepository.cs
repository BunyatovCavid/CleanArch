using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.AppRepository
{
    public class ActorRepository : IActorRepository
    {
        AppDbContext _db;
        public ActorRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Actor>> Get()
        {
            var data = await _db.Actors.AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<Actor> GetByid(int id)
        {
            var data = await _db.Actors.FirstOrDefaultAsync(m => m.Id == id);
            return data;
        }

        public async Task Post(Actor new_entity)
        {
            await _db.Actors.AddAsync(new_entity);
        }

        public async Task<Actor> Put(int id, Actor new_entity)
        {
            var data = await _db.Actors.FirstOrDefaultAsync(m => m.Id == id);
            return data;
        }
        public async Task Delete(Actor actor)
        {
            var data =  _db.Actors.Remove(actor);
        }

        public async Task<Actor> GetActor(string name)
        {
            var data = await _db.Actors.OrderByDescending(a => a.Id).FirstOrDefaultAsync(a => a.Name == name);
            return data;
        }
    }
}
