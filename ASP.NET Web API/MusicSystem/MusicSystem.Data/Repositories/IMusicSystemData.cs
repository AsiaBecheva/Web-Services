using MusicSystem.Models;

namespace MusicSystem.Data.Repositories
{
    public interface IMusicSystemData
    {
        IGenericRepository<Album> Albums { get; }

        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Song> Songs { get; }

        int SaveChanges();
    }
}
