using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;

namespace Domain.Interface.Services
{
    public interface ICrossService
    {
        public Task<ICollection<Actor>> GetActorByMovieId(int id);
        public Task<Movie> GetMoviieByTitleActor(string title, string actorname);
        public Task<Movie> PostActorToMovie(CrossDto actorMovieDto);
        public Task<string> DeleteActorsByIdFromMovie(int id);
    }
}
