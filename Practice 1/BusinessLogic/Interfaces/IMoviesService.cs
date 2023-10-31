using System;
using System.Collections.Generic;
using BusinessLogic.APIModels;
using BusinessLogic.Dtos;
using DataAccess.Data.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> Get();
        MovieDto? Get(int id);
        void Create(CreateMovieModel movie);
        void Edit(EditMovieModel movie);
        void Delete(int id);
    }
}
