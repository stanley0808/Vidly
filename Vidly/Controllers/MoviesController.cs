using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
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
            _context.Dispose();
        }
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {

                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                MovieInDb.Name = movie.Name;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.Genre = movie.Genre;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ViewResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            //從資料庫裡面讀取出舊資料放進movie變數
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var ViewModol = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", ViewModol);
        }
    }

}



//private IEnumerable<Movie> GetMovies()
//這邊模擬建立一個Movie的資料庫，並且用來被提取資料。
//{
//    return new List<Movie>
//    {
//        new Movie { Id = 1, Name = "Shrek" },
//    //        new Movie { Id = 2, Name = "Wall-e" }
//};
//}

//public ActionResult Random()// GET: Movies/Random
//{
//    var movie = new Movie()
//    {
//        Name = "Shrek!"
//    };
//    var customers = new List<Customer>
//    {
//        new Customer{Name = "Customer 1"},
//        new Customer{Name = "Customer 2"}
//    };
//    var viewModel = new RandomMovieViewModel
//    {
//        Movie = movie,
//        Customers = customers
//    };
//    return View(viewModel);


//[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
//public ActionResult ByReleaseDate(int year, int month)
//{
//    return View();


//}






