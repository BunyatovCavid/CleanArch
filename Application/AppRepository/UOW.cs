using Application.Dto;
using Domain.Entities;
using Domain.Interface;
using Domain.Interface.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppRepository
{
    internal class UOW : IUOW
    {
        private readonly AppDbContext _db;
        public IMovieRepository _movie { get; }
        public IActorRepository _actor { get; }
        public ICrossRepository _cross { get; }
        public UOW(IMovieRepository movie, IActorRepository actor, ICrossRepository cross, AppDbContext db)
        {
            _db = db;
            _movie = movie;
            _actor = actor;
            _cross = cross;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task SaveChange()
        {
            await _db.SaveChangesAsync();
        }
    }
}
