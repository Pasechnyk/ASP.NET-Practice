using AutoMapper;
using BusinessLogic.APIModels;
using BusinessLogic.Dtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly CinemaDbContext context;
        private readonly IMapper mapper;

        public MoviesService(CinemaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(CreateMovieModel movie)
        {
            context.Movies.Add(mapper.Map<Movie>(movie));
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = context.Movies.Find(id);

            if (item == null) throw new HttpException("Movie with Id not found!", HttpStatusCode.NotFound);

            context.Movies.Remove(item);
            context.SaveChanges();
        }

        public void Edit(EditMovieModel movie)
        {
            context.Movies.Update(mapper.Map<Movie>(movie));
            context.SaveChanges();
        }

        public List<Movie> Get()
        {
            return context.Movies.ToList();
        }

        public MovieDto? Get(int id)
        {
            var item = context.Movies.Find(id);

            if (item == null) throw new HttpException("Movie with Id not found!", HttpStatusCode.NotFound);

            return mapper.Map<MovieDto>(item);
        }
    }
}
