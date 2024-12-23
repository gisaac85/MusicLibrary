using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data.RepoInterface;
using MusicLibrary.Models;

namespace MusicLibrary.Data.Repo
{
    public class ArtistRepo : IArtistRepo
    {
        private readonly MusicLibraryDbContext _dbContext;

        public ArtistRepo(MusicLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Artist artist)
        {
            _dbContext.Add(artist);
            await _dbContext.SaveChangesAsync();
        }      

        public async Task<Artist> Get(int? id)
        {
            return await _dbContext.Artists.FindAsync(id);
        }

        public async Task<List<Artist>> GetAll()
        {
            return await _dbContext.Artists.ToListAsync();
        }
    }
}
