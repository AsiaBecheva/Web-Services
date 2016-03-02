namespace MusicSystem.Data
{
    using Models;
    using System.Data.Entity;

    public interface IMusicSystemDbContext
    {
        IDbSet<Song> Songs { get; set; }

        IDbSet<Album> Albums { get; set; }

        IDbSet<Artist> Artists { get; set; }

        void SaveChanges();
    }
}
