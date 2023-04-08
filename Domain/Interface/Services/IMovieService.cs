using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;

namespace Domain.Interface.Services
{
    public interface IMovieService
    {
        public Task<List<Movie>> Get();
        public Task<Movie> GetByid(int id);
        public Task<Movie> Post(MovieDto MovieDto);
        public Task<Movie> Put(int id, MovieDto MovieDto);
        public Task<string> Delete(int id);
    }
}
