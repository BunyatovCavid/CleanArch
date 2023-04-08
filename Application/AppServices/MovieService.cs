using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppServices
{
    public class MovieService:IMovieService
    {

        IUOW _uow;
        IMapper _mapper;
        public MovieService(IMapper mapper, IUOW uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Movie> GetByid(int id)
        {
            try
            {
                var data = await _uow._movie.GetByid(id);
                return data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<List<Movie>> Get()
        {
            try
            {
                var data = await _uow._movie.Get();
                return data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Movie> Post(MovieDto movieDto)
        {
            try
            {
                var new_post = _mapper.Map<Movie>(movieDto);
                await _uow._movie.Post(new_post);
                await _uow.SaveChange();
                var return_value = await _uow._movie.GetMovie(movieDto.Title);
                return return_value;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Movie> Put(int id, MovieDto movieDto)
        {
            try
            {
                var new_entity = _mapper.Map<Movie>(movieDto);
                var data = await _uow._movie.Put(id, new_entity);
                if (data != null)
                {
                    var return_value = _mapper.Map(movieDto, data);
                    await _uow.SaveChange();
                    return return_value;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }
        public async Task<string> Delete(int id)
        {
            try
            {
                var data = await _uow._movie.GetByid(id);
                if (data != null)
                {
                    await _uow._movie.Delete(data);
                    await _uow.SaveChange();
                    return "Succesful";
                }
                else return "This id is not registered";
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return "Failed";
            }
        }
    }
}
