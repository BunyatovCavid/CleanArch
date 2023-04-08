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
    public class ActorService:IActorService
    {
        IUOW _uow;
        IMapper _mapper;
        public ActorService(IMapper mapper, IUOW uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<string> DeleteActor(int id)
        {
            try
            {
                var data = await _uow._actor.GetByid(id);
                if (data != null)
                {
                    await _uow._actor.Delete(data);
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

        public async Task<List<Actor>> Get()
        {
            try
            {
                var data = await _uow._actor.Get();
                return data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Actor> GetByid(int id)
        {
            try
            {
                var data = await _uow._actor.GetByid(id);
                return data;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Actor> Post(ActorDto actorDto)
        {
            try
            {
                var new_post = _mapper.Map<Actor>(actorDto);
                await _uow._actor.Post(new_post);
                await _uow.SaveChange();
                var return_value = await _uow._actor.GetActor(actorDto.Name);
                return return_value;
            }
            catch (Exception ex)
            {
                var log = ex.Message;
                var log_inner = ex.InnerException;
                return null;
            }
        }

        public async Task<Actor> Put(int id, ActorDto actorDto)
        {
            try
            {
                var new_entity = _mapper.Map<Actor>(actorDto);
                var data = await _uow._actor.Put(id, new_entity);
                if (data != null)
                {
                    var return_value = _mapper.Map(actorDto, data);
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
    }
}
