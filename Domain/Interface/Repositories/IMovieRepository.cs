using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repositories
{
    public interface IMovieRepository
    {
        public Task<List<Movie>> Get();
        public Task<Movie> GetByid(int id);
        public Task Post(Movie new_entity);
        public Task<Movie> GetMovie(string name);
        public Task<Movie> Put(int id, Movie new_entity);
        public Task Delete(Movie movie);

    }
}
