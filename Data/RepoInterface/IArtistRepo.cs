using MusicLibrary.Models;

namespace MusicLibrary.Data.RepoInterface
{
    public interface IArtistRepo
    {
        public Task<List<Artist>> GetAll();
        public Task<Artist> Get(int? id);
        public Task Create(Artist artist);
    }
}
