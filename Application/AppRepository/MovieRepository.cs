using Domain.Entities;
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
    public class MovieRepository :IMovieRepository
    {
        AppDbContext _db;
        public MovieRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Movie>> Get()
        {
            var data = await _db.Movies.AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<Movie> GetByid(int id)
        {
            var data = await _db.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            return data;
        }

        public async Task Post(Movie new_entity)
        {
            await _db.Movies.AddAsync(new_entity);
        }

        public async Task<Movie> Put(int id, Movie new_entity)
        {
            var data = await _db.Movies.FirstOrDefaultAsync(m => m.Id == id);
            return data; 
        }       
        public async Task Delete(Movie movie)
        {
            var data = _db.Movies.Remove(movie);
        }

        public async Task<Movie> GetMovie(string name)
        {
            var data = await _db.Movies.OrderByDescending(a => a.Id).FirstOrDefaultAsync(a => a.Title == name);
            return data;
        }
    }
}
