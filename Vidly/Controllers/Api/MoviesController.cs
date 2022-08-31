using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/Movies 讀取資料
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }
        //GET /api/Movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie ,MovieDto>(movie));
        }
        // POST api/Movies 新增
        [HttpPost]
        public IHttpActionResult CreateMovies(MovieDto MoviesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movies = Mapper.Map<MovieDto ,Movie>(MoviesDto);
            _context.Movies.Add(movies);
            _context.SaveChanges();

            MoviesDto.Id = movies.Id;

            return Created(new Uri(Request.RequestUri + "/" + movies.Id), MoviesDto);
        }

        //PUT /api/Movies/1 更新
        public IHttpActionResult UpdateMovies(int id, MovieDto MoviesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var moviesInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (moviesInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(MoviesDto, moviesInDb);

            _context.SaveChanges();
            return Ok();
        }
        // DELETE /api/Movies/1 刪除
        [HttpDelete]
        public IHttpActionResult DeleteMovies(int id)
        {
            var moviesInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (moviesInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(moviesInDb);
            _context.SaveChanges();

            return Ok();
        }


    }
}

