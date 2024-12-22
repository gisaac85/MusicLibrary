using MusicLibrary.Models;

namespace MusicLibrary.Data.RepoInterface
{
    public interface ISongRepo
    {
        public Task Create(Song song);
        public Task Delete(Song song);
        public Task<Song> Details(int? id);
        public Task Edit(Song song);
        public Task<List<Song>> GetAll();

        public Task<Song> Get(int? id);

        public bool SongExists(int id);
    }
}
