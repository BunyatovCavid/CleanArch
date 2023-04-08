using Application.Dto;
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
    public class CrossRepository : ICrossRepository
    {
        AppDbContext _db;
        public CrossRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Movie> GetActorByMovieId(int id)
        {
            var data = await _db.Movies.Include(m => m.Actors).FirstOrDefaultAsync(m => m.Id == id);
            return data;
        }

        public async Task<Movie> GetMoviieByTitleActor(string title, string actorname)
        {
            var data = await _db.Movies.Include(m => m.Actors).FirstOrDefaultAsync(m => m.Title == title);
            return data;
        }

        public async Task<Movie> PostActorToMovie(CrossDto actorMovie)
        {
            var data = await _db.Movies.Include(m => m.Actors).FirstOrDefaultAsync(
                    m => m.Title == actorMovie.MovieTitle &&
                     m.Release_year == actorMovie.MovieRelease_year &&
                     m.Genre == actorMovie.MovieGenre &&
                     m.Director == actorMovie.MovieDirector);
            return data;
        }
        public async Task<Actor> GetActor(string name)
        {
            var data = await _db.Actors.SingleOrDefaultAsync(a => a.Name == name);
            return data;
        }
        public async Task DeleteActorsByIdFromMovie(Movie movie)
        {
            _db.Movies.Remove(movie);
        }

        public Task<Movie> GetMovie(string title)
        {
            var data = _db.Movies.Include(m => m.Actors).OrderByDescending(m => m.Id)
             .FirstOrDefaultAsync(m => m.Title == title);
            return data;
        }
    }
}
