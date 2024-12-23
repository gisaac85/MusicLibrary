using MusicLibrary.Models;

namespace MusicLibrary.Data.RepoInterface
{
    public interface IGenreRepo
    {
        public Task<List<Genre>> GetAll();
        public Task<Genre> Get(int? id);
        public Task Create(Genre genre);
    }
}
