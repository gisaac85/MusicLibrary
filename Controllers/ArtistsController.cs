using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Data.RepoInterface;
using MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistRepo _artistRepo;
        private readonly IMapper _mapper;

        public ArtistsController(IMapper mapper, IArtistRepo artistRepo)
        {
            _mapper = mapper;           
            _artistRepo = artistRepo;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            return View(await _artistRepo.GetAll());
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _artistRepo.Get(id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Artists = await _artistRepo.GetAll();
            return View();
        }

        // POST: Artists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Artist artist)
        {
            if (ModelState.IsValid)
            {
                await _artistRepo.Create(artist);
                ViewBag.Message = "Song added successfully";
            }
            return RedirectToAction(nameof(Index), "Songs",ViewBag.Message);
        }      
    }
}
