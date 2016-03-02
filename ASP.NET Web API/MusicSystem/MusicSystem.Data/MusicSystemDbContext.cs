namespace MusicSystem.Data
{
    using Models;
    using System.Data.Entity;
    using System;

    public class MusicSystemDbContext : DbContext, IMusicSystemDbContext
    {
        public MusicSystemDbContext()
            : base("MusicSystemConnection")
        {
        }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        } 
    }
}
