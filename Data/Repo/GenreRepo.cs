﻿using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data.RepoInterface;
using MusicLibrary.Models;

namespace MusicLibrary.Data.Repo
{
    public class GenreRepo : IGenreRepo
    {
        private readonly MusicLibraryDbContext _dbContext;

        public GenreRepo(MusicLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Genre genre)
        {
            _dbContext.Add(genre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Genre genre)
        {
            if (genre != null)
            {
                _dbContext.Genres.Remove(genre);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Genre> Get(int? id)
        {
            return await _dbContext.Genres.FindAsync(id);
        }

        public async Task<List<Genre>> GetAll()
        {
           return await _dbContext.Genres.ToListAsync();
        }
    }
}
