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
            ViewBag.Geners = await _genreRepo.GetAll();
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreRepo.Create(genre);                
            }
            return RedirectToAction(nameof(Index),"Songs");
        }      
    }
}
