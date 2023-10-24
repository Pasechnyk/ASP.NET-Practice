using BusinessLogic.APIModels;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practice_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService service;

        public MoviesController(IMoviesService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.Get()); 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(service.Get(id));
        }

        [HttpPost]
        public IActionResult Create(CreateMovieModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            service.Create(model);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditMovieModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            service.Edit(model);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        { 
            service.Delete(id); return Ok();
        }

    }
}
