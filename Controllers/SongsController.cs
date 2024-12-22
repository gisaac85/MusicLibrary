using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data.DTO;
using MusicLibrary.Data.RepoInterface;
using MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongRepo _songRepo;
        private readonly IGenreRepo _genreRepo;
        private readonly IMapper _mapper;

        public SongsController(ISongRepo songRepo,  IMapper mapper, IGenreRepo genreRepo)
        {
            _songRepo = songRepo;
            _mapper = mapper;
            _genreRepo = genreRepo;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var songList = await _songRepo.GetAll();           

            var songListDTO = _mapper.Map<List<Song>,List<SongDTO>>(songList);

            var genreList = await _genreRepo.GetAll();
            
            foreach (var song in songListDTO)
            {
                song.Genre = genreList.FirstOrDefault(g => g.Id == song.GenreId);
            }

            return View(songListDTO);
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _songRepo.Details(id);

            if (song == null)
            {
                return NotFound();
            }

            var songDTO = _mapper.Map<Song, SongDTO>(song);

            songDTO.Genre = await _genreRepo.Get(songDTO.GenreId);

            return View(songDTO);
        }

        // GET: Songs/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Genres = await _genreRepo.GetAll();
            return View();
        }

        // POST: Songs/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Song song)
        {
            if (ModelState.IsValid)
            {
                await _songRepo.Create(song);
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _songRepo.Get(id);

            var songEditDTO = _mapper.Map<SongEditDTO>(song);

            if (songEditDTO == null)
            {
                return NotFound();
            }

            ViewBag.Genres = await _genreRepo.GetAll();

            return View(songEditDTO);
        }

        // POST: Songs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[FromForm] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }          

            if (ModelState.IsValid)
            {
                try
                {
                   _songRepo.Edit(song);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_songRepo.SongExists(song.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _songRepo.Get(id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _songRepo.Get(id);
            await _songRepo.Delete(song);
            return RedirectToAction(nameof(Index));
        }
    }
}
