using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Data.RepoInterface;
using MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreRepo _genreRepo;
        private readonly IMapper _mapper;

        public GenresController(IMapper mapper, IGenreRepo genreRepo)
        {
            _mapper = mapper;
            _genreRepo = genreRepo; 
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _genreRepo.GetAll());
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _genreRepo.Get(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Genres/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Genres = await _genreRepo.GetAll();
            return View(nameof(Create));
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreRepo.Create(genre);
                ViewBag.Message = $"Genre {genre.Name} added successfully";
                ViewBag.Genres = await _genreRepo.GetAll();
            }
            return View(nameof(Create));
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreRepo.Get(id);
            await _genreRepo.Delete(genre);

            ViewBag.Message = $"Genre {genre.Name} removed successfully";        

            ViewBag.Genres = await _genreRepo.GetAll();

            return View(nameof(Create));
        }      
    }
}
