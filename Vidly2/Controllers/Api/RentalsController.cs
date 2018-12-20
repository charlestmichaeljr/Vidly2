using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Vidly2.DTOs;
using Vidly2.Models;
using WebGrease.Css.Extensions;

namespace Vidly2.Controllers.Api
{
    public class RentalsController: ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();    
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDTO rentalDto)
        {
            if (rentalDto.MovieIds.Count == 0)
            {
                return BadRequest("No movies were sent in the rental request");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            if (customer == null)
            {
                return BadRequest("Customer ID is invalid");
            }

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            if (movies.Count != rentalDto.MovieIds.Count)
            {
                return BadRequest("One or more movie ids are invalid");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest(movie.Name + " is unavailable");
                }

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    DateRented = DateTime.Now,
                    Movie = movie
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

        //public IHttpActionResult GetRentals()
        //{
        //    var rentals = _context.Rentals
        //        .Include(r => r.Customer)
        //        .Include(c => c.Movie)
        //        .ToList()
        //        .Select(Mapper.Map<Rental, RentalDTO>);

        //    return Ok(rentals);
        //}

        //public IHttpActionResult GetRental(int rentalId)
        //{
        //    var rental = _context.Rentals
        //        .Include(r => r.Customer)
        //        .Include(c => c.Movie)
        //        .SingleOrDefault(r => r.Id == rentalId);

        //    if (rental == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(Mapper.Map<Rental,RentalDTO>(rental));
        //}

        //[Route("rentals/customers/{customerId}")]
        //public IHttpActionResult GetRentalsByCustomerId(int customerId)
        //{
        //    var rentals = _context.Rentals
        //        .Include(r => r.Customer)
        //        .Include(c => c.Movie)
        //        .Select(r => r.Customer.Id == customerId)
        //        .ToList();

        //    return Ok();
        //}



        //[HttpPut]
        //public void UpdateRental(int rentalId, RentalDTO rentalDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }

        //    var rentalFromDb = _context.Rentals.Include(r => r.Movie)
        //        .Include(r => r.Customer).
        //        SingleOrDefault(r => r.Id == rentalId);
        //    if (rentalFromDb == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    Mapper.Map(rentalDto, rentalFromDb);

        //    _context.SaveChanges();
        //}

        //public IHttpActionResult DeleteRental(int id)
        //{
        //    return Ok();
        //}
    }
}