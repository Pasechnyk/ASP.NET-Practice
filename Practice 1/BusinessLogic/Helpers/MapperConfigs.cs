using AutoMapper;
using BusinessLogic.APIModels;
using BusinessLogic.Dtos;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Helpers
{
    internal class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<EditMovieModel, Movie>();
            CreateMap<MovieDto, Movie>().ReverseMap();
        }

    }
}
