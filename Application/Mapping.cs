using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<MovieDto, Movie>();
            CreateMap<ActorDto, Actor>();
        }
    }
}
