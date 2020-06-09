using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieWeb.Database;
using MovieWeb.Domain;
using MovieWeb.Models;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieDatabase _movieDatabase;

        public MovieController(IMovieDatabase movies)
        {
            _movieDatabase = movies;
        }

        public IActionResult Index()
        {
            var movies = _movieDatabase.GetMovies()
                .Select(item => new MovieIndexViewModel()
                {
                    Title = item.Title,
                    Id = item.Id
                })
                .ToList();

            return View(movies);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie movieFromDb = _movieDatabase.GetMovie((int)id);

            MovieDetailViewModel movie = new MovieDetailViewModel()
            {
                Title = movieFromDb.Title,
                Genre = movieFromDb.Genre,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate
            };

            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel movie)
        {
            if (!TryValidateModel(movie))
            {
                return View(movie);
            }

            _movieDatabase.Insert(new Movie()
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate
            });

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie movieFromDb = _movieDatabase.GetMovie((int)id);

            MovieEditViewModel movie = new MovieEditViewModel()
            {
                Title = movieFromDb.Title,
                Genre = movieFromDb.Genre,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate
            };

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieEditViewModel movie)
        {
            if (!TryValidateModel(movie))
            {
                return View(movie);
            }

            _movieDatabase.Update(id, new Movie()
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate
            });

            return RedirectToAction("Detail", new { Id = id });

        }
    }
}
