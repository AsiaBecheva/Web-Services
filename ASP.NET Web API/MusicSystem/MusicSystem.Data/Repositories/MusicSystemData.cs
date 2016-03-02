namespace MusicSystem.Data.Repositories
{
    using System;
    using MusicSystem.Models;
    using System.Data.Entity;
    using System.Collections.Generic;

    public class MusicSystemData : IMusicSystemData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public MusicSystemData()
        {
            this.context = new MusicSystemDbContext();
            this.repositories = new Dictionary<Type, object>();
        }

        IGenericRepository<Album> IMusicSystemData.Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        IGenericRepository<Artist> IMusicSystemData.Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        IGenericRepository<Song> IMusicSystemData.Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IGenericRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
