using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == 3);
            var customers = _context.Customers.ToList();

            RandomMovieViewModel viewModel = new RandomMovieViewModel
            {
                Customers = customers,
                Movie = movie
            };
            
            return View(viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movieFromDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            
            if (movieFromDb == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movieFromDb)
            {
                Genres = _context.Genres.ToList()
            };
           
            return View("MovieForm", viewModel);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "name";
            }


            return Content(String.Format("page index = {0} sort by = {1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month );
        }


        [Route("movies/list")]
        public ViewResult ListMovies()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("ListMovies");
            }
            else
            {
                return View("ReadOnlyList");
            }
            
        }

        [Route("movies/{id:int}/details")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel(new Movie()) {Genres = genres};
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();
            return RedirectToAction("ListMovies", "Movies");
        }
    }
}