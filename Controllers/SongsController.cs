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
        private readonly IArtistRepo _artistRepo;
        private readonly IMapper _mapper;

        public SongsController(IMapper mapper, ISongRepo songRepo, IGenreRepo genreRepo, IArtistRepo artistRepo)
        {
            _mapper = mapper;
            _songRepo = songRepo;            
            _genreRepo = genreRepo;
            _artistRepo = artistRepo;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var songList = await _songRepo.GetAll();           

            var songListDTO = _mapper.Map<List<Song>,List<SongDTO>>(songList);

            var genreList = await _genreRepo.GetAll();

            var artistList = await _artistRepo.GetAll();

            foreach (var song in songListDTO)
            {
                song.Genre = genreList.FirstOrDefault(g => g.Id == song.GenreId);
                song.Artist = artistList.FirstOrDefault(a => a.Id == song.ArtistId);
            }

            return View(songListDTO);
        }

        public async Task<IActionResult> Sort(string sortOrder)
        {
            ViewData["TitleSortParm"] = sortOrder == "Title" ? "title_desc" : "Title";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["GenreSortParm"] = sortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewData["ArtistSortParm"] = sortOrder == "Artist" ? "artist_desc" : "Artist";
            
            var songList = await _songRepo.GetAll();
            var songListDTO = _mapper.Map<List<Song>, List<SongDTO>>(songList);
            var genreList = await _genreRepo.GetAll();
            var artistList = await _artistRepo.GetAll();
            
            foreach (var song in songListDTO)
            {
                song.Genre = genreList.FirstOrDefault(g => g.Id == song.GenreId);
                song.Artist = artistList.FirstOrDefault(a => a.Id == song.ArtistId);
            }
            switch (sortOrder)
            {
                case "Title":
                    songListDTO = songListDTO.OrderBy(s => s.Title).ToList();
                    break;
                case "title_desc":
                    songListDTO = songListDTO.OrderByDescending(s => s.Title).ToList();
                    break;
                case "Date":
                    songListDTO = songListDTO.OrderBy(s => s.ReleaseDate).ToList();
                    break;
                case "date_desc":
                    songListDTO = songListDTO.OrderByDescending(s => s.ReleaseDate).ToList();
                    break;
                case "Genre":
                    songListDTO = songListDTO.OrderBy(s => s.Genre.Name).ToList();
                    break;
                case "genre_desc":
                    songListDTO = songListDTO.OrderByDescending(s => s.Genre.Name).ToList();
                    break;
                case "Artist":
                    songListDTO = songListDTO.OrderBy(s => s.Artist.Name).ToList();
                    break;
                case "artist_desc":
                    songListDTO = songListDTO.OrderByDescending(s => s.Artist.Name).ToList();
                    break;
                default:
                    songListDTO = songListDTO.OrderBy(s => s.Title).ToList();
                    break;
            }
            return View("Index",songListDTO);
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
            songDTO.Artist = await _artistRepo.Get(songDTO.ArtistId);

            return View(songDTO);
        }

        // GET: Songs/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Genres = await _genreRepo.GetAll();
            ViewBag.Artists = await _artistRepo.GetAll();
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

            ViewBag.Artists = await _artistRepo.GetAll();

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

            var SongToDeleteDTO = _mapper.Map<SongDeleteDTO>(song);

            SongToDeleteDTO.Artist  = await _artistRepo.Get(SongToDeleteDTO.ArtistId);
            SongToDeleteDTO.Genre = await _genreRepo.Get(SongToDeleteDTO.GenreId);

            return View(SongToDeleteDTO);
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
