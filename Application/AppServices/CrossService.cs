using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Domain.Interface.Services;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppServices
{
    public class CrossService:ICrossService
    {
        IUOW _uow;
        public CrossService(IUOW uow)
        {
            _uow = uow;
        }
        public async Task<ICollection<Actor>> GetActorByMovieId(int id)
        {
            try
            {
                var data = await _uow._cross.GetActorByMovieId(id);
                var return_data = data.Actors;
                return return_data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Movie> GetMoviieByTitleActor(string title, string actorname)
        {
            try
            {
                var data = await _uow._cross.GetMoviieByTitleActor(title, actorname);
                var data_2 = data.Actors.FirstOrDefault(a => a.Name == actorname);
                if (data != null && data_2 != null)
                {
                    return data;
                }
                else return null;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Movie> PostActorToMovie(CrossDto actorMovieDto)
        {
            try
            {
                var data = await _uow._cross.PostActorToMovie(actorMovieDto);


                var data_2 = await _uow._cross.GetActor(actorMovieDto.ActorName);
                if (data != null && data_2 != null) data.Actors.Add(data_2);
                else
                {
                    data.Actors.Add(new Actor { Name = actorMovieDto.ActorName });
                }
                await _uow.SaveChange();
                var return_value = await _uow._cross.GetMovie(actorMovieDto.MovieTitle);
                return return_value;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<string> DeleteActorsByIdFromMovie(int id)
        {
            try
            {
                var data = await _uow._movie.GetByid(id);

                if (data != null)
                {
                    foreach (var item in data.Actors)
                    {
                      await   _uow._cross.DeleteActorsByIdFromMovie(data);
                    }
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
