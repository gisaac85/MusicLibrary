using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data;
using MusicLibrary.Data.RepoInterface;
using MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongRepo _songRepo;

        public SongsController(ISongRepo songRepo)
        {
            _songRepo = songRepo;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var songList = await _songRepo.GetAll();
            return View(songList);
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

            //ViewBag.Genres = _context.Genres.ToList();

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            //ViewBag.Genres = _context.Genres.ToList();
            return View();
        }

        // POST: Songs/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ArtistName,Genre,ReleaseDate")] Song song)
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
            if (song == null)
            {
                return NotFound();
            }

            //ViewBag.Genres = _context.Genres.ToList();

            return View(song);
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
