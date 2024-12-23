using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data.RepoInterface;
using MusicLibrary.Models;

namespace MusicLibrary.Data.Repo
{
    
    public class SongRepo : ISongRepo
    {
        private readonly MusicLibraryDbContext _dbContext;

        public SongRepo(MusicLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Song song)
        {
            _dbContext.Add(song);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Song song)
        {
            if (song != null)
            {
                _dbContext.Songs.Remove(song);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Song> Details(int? id)
        {
            return await _dbContext.Songs.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Edit(Song song)
        {
            _dbContext.Update(song);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Song> Get(int? id)
        {
            return await _dbContext.Songs.FindAsync(id);
        }

        public async Task<List<Song>> GetAll()
        {
            return await _dbContext.Songs.ToListAsync();            
        }

        public async Task<List<Song>> GetSongByArtistId(int artistId)
        {
            return await _dbContext.Songs.Where(s => s.ArtistId == artistId).ToListAsync();
        }

        public bool SongExists(int id)
        {
            return  _dbContext.Songs.Any(e => e.Id == id);
        }
    }
}
