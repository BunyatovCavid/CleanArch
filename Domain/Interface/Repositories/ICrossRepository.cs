using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;

namespace Domain.Interface.Repositories
{
    public interface ICrossRepository
    {
        public Task<Movie> GetActorByMovieId(int id);
        public Task<Movie> GetMovie(string title);
        public Task<Movie> GetMoviieByTitleActor(string title, string actorname);
        public Task<Movie> PostActorToMovie(CrossDto actorMovie);
        public Task<Actor> GetActor(string name);
        public Task DeleteActorsByIdFromMovie(Movie movie);
    }
}
