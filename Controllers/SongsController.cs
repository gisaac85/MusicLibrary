﻿using AutoMapper;
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
        private string path = Path.Combine(Environment.CurrentDirectory, "Uploads");
        private static IFormFile? _file;

        public SongsController(IMapper mapper, ISongRepo songRepo, IGenreRepo genreRepo, IArtistRepo artistRepo)
        {
            _mapper = mapper;
            _songRepo = songRepo;
            _genreRepo = genreRepo;
            _artistRepo = artistRepo;
        }

        private async Task<List<SongDTO>> GetAll()
        {
            var songs = await _songRepo.GetAll();

            var songsDTO = _mapper.Map<List<Song>, List<SongDTO>>(songs);

            var genreList = await _genreRepo.GetAll();

            var artistList = await _artistRepo.GetAll();

            foreach (var s in songsDTO)
            {
                s.Genre = genreList.FirstOrDefault(g => g.Id == s.GenreId);
                s.Artist = artistList.FirstOrDefault(a => a.Id == s.ArtistId);
            }
            return songsDTO;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var songListDTO = await GetAll();
          
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
            return View("Index", songListDTO);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var artists = from s in await _artistRepo.GetAll() select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                artists = artists.Where(s => s.Name.Contains(searchString) ||
                                        s.Name.ToLower().Contains(searchString) ||
                                        s.Name.ToLower().StartsWith(searchString));
            }

            var songs = new List<Song>();

            foreach (var artist in artists)
            {
                songs = await _songRepo.GetSongByArtistId(artist.Id);
            }

            var songListDTO = _mapper.Map<List<Song>, List<SongDTO>>(songs);

            foreach (var song in songListDTO)
            {
                song.Genre = await _genreRepo.Get(song.GenreId);
                song.Artist = await _artistRepo.Get(song.ArtistId);
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
        public async Task<IActionResult> Create([FromForm] Song song,IFormFile File)
        {
            var songsDTO = new List<SongDTO>();

            song.Genre = await _genreRepo.Get(song.GenreId);
            song.Artist = await _artistRepo.Get(song.ArtistId);

            if (File == null)
            {
                ModelState.Remove("File");
            }

            if (ModelState.IsValid)
            {
                // file handle
                if (File != null && File.Length > 0)
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string fileName = Path.GetFileName(File.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        await File.CopyToAsync(stream);
                    }

                    song.FileName = Path.Combine(path, File.FileName);

                    ViewBag.Data = "data:audio/mp3;base64," + Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(path, fileName)));

                    song.File = ConvertToByteArray(Path.Combine(path, File.FileName));

                    _file = File;
                }
                // file handled

                await _songRepo.Create(song);

                SongCreateDTO songCreateDTO = _mapper.Map<SongCreateDTO>(song);

                songCreateDTO.Genre = song.Genre;
                songCreateDTO.Artist = song.Artist;

                ViewBag.Genres = await _genreRepo.GetAll();
                ViewBag.Artists = await _artistRepo.GetAll();

                ViewBag.Message = "Song added successfully";

                songsDTO = await GetAll();
            }
            return View(nameof(Index),songsDTO);
        }

        private byte[] ConvertToByteArray(string filePath)
        {
            byte[] fileData;
            //Create a File Stream Object to read the data
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    fileData = reader.ReadBytes((int)fs.Length);
                }
            }
            return fileData;
        }

        public IFormFile ConvertByteArrayToIFormFile(byte[] fileBytes, string fileName)
        {
            var formFile = new Helpers.FormFile(fileBytes, fileName)
            {
                ContentType = "audio/mpeg",
                ContentDisposition = $"form-data; name=file; filename={fileName}"
            };
            return formFile;
        }

        [HttpGet]
        public async Task<ActionResult> GetAudioStream(int id)
        {
            if (id > 0)
            {
                var song = await _songRepo.Get(id);

                song.File = ConvertToByteArray(song.FileName);

                var songFile = song.File;

                if (songFile != null && songFile.Length > 0)
                {
                    return File(songFile, "audio/mpeg");
                }
            }
            return null;
        }
       
        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _songRepo.Get(id);

            _file = ConvertByteArrayToIFormFile(song.File,song.FileName);

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
        public async Task<IActionResult> Edit(int id, [FromForm] Song song)
        {
            var songEditDTO = new SongEditDTO();
            var songsDTO = new List<SongDTO>();

            if (id != song.Id)
            {
                return NotFound();
            }

            if (_file == null)
            {
                ModelState.Remove("File");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // file handle
                    if (_file != null && _file.Length > 0)
                    {
                        song.File = ConvertToByteArray(Path.Combine(_file.FileName));
                        song.FileName = _file.FileName;
                    }
                    // file handled

                    await _songRepo.Edit(song);

                    songEditDTO = _mapper.Map<SongEditDTO>(song);

                    songEditDTO.Genre = await _genreRepo.Get(songEditDTO.GenreId);
                    songEditDTO.Artist = await _artistRepo.Get(songEditDTO.ArtistId);

                    ViewBag.Genres = await _genreRepo.GetAll();
                    ViewBag.Artists = await _artistRepo.GetAll();

                    ViewBag.Message = "Song updated successfully";

                   songsDTO = await GetAll();
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
            }
            return View(nameof(Index), songsDTO);
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

            SongToDeleteDTO.Artist = await _artistRepo.Get(SongToDeleteDTO.ArtistId);
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

            ViewBag.Message = "Song removed successfully";

            var songsDTO = new List<SongDTO>();
            songsDTO = await GetAll();

            return View(nameof(Index),songsDTO);
        }
    }
}
