﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Vidly2.DTOs;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class MoviesController:ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // api/Movies
        public IHttpActionResult GetMovies()
        {
            var customers = _context.Movies
                .Include(m => m.Genre )
                .ToList()
                .Select(Mapper.Map<Movie,MovieDTO>);
            return Ok(customers);
        }
        

        // api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie,MovieDTO>(movie));
        }

        // POST api/Movies
        [HttpPost]
        public IHttpActionResult CreateNewMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieFromDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieFromDb == null)
            {
                return NotFound();
            }

            var movie = Mapper.Map<MovieDTO, Movie>(movieDto, movieFromDb);
            _context.SaveChanges();

            return Ok();
        }

        public IHttpActionResult DeleteMovie(int id)
        {
            var movieFromDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieFromDb == null)
            {
                return BadRequest();
            }

            _context.Movies.Remove(movieFromDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}