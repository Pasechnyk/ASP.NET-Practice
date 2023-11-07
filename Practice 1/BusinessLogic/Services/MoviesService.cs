using AutoMapper;
using BusinessLogic.APIModels;
using BusinessLogic.Dtos;
using BusinessLogic.Entities;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
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
        //private readonly CinemaDbContext context;
        private readonly IRepository<Movie> moviesRepo;
        private readonly IMapper mapper;

        public MoviesService(IRepository<Movie> moviesRepo, IMapper mapper)
        {
            this.moviesRepo = moviesRepo;
            this.mapper = mapper;
        }

        public void Create(CreateMovieModel movie)
        {
            moviesRepo.Insert(mapper.Map<Movie>(movie));
            moviesRepo.Save();
        }

        public void Delete(int id)
        {
            var item = moviesRepo.GetByID(id);

            if (item == null)
            { throw new HttpException("Movie with this Id was not found!", HttpStatusCode.NotFound); }

            moviesRepo.Delete(item);
            moviesRepo.Save();
        }

        public void Edit(EditMovieModel movie)
        {
            moviesRepo.Update(mapper.Map<Movie>(movie));
            moviesRepo.Save();
        }

        public List<MovieDto> Get()
        {
            var items = moviesRepo.Get(includeProperties: "Genre");
            return mapper.Map<List<MovieDto>>(items);
        }

        public MovieDto? Get(int id)
        {
            var item = moviesRepo.GetByID(id);

            if (item == null)
            { throw new HttpException("Movie with this Id was not found!", HttpStatusCode.NotFound); }

            return mapper.Map<MovieDto>(item);
        }
    }
}
