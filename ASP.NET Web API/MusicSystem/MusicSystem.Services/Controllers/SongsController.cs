namespace MusicSystem.Services.Controllers
{
    using Data.Repositories;
    using Models;
    using MusicSystem.Models;
    using System.Web.Http;

    public class SongsController : ApiController
    {
        private readonly IMusicSystemData db;

        public SongsController(IMusicSystemData db)
        {
            this.db = db;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.db.Songs.All());
        }

        public IHttpActionResult Get(int id)
        {
            var song = db.Songs.GetById(id);

            if (song == null)
            {
                return this.BadRequest("There is no song with this Id!");
            }

            return this.Ok(song);
        }

        public IHttpActionResult Post(SongResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var song = new Song
            {
                Title = model.Title,
                Genre = model.Genre
            };

            this.db.Songs.Add(song);
            this.db.SaveChanges();

            return this.Created(this.Url.ToString(), song);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, SongResponseModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var song = db.Songs.GetById(id);

            if (song == null)
            {
                return this.BadRequest("There is no song with this Id!");
            }

            song.Title = model.Title;
            song.Genre = model.Genre;
           
            this.db.Songs.Update(song);
            this.db.SaveChanges();

            return this.Ok(song);
        }

        public IHttpActionResult Delete(int id)
        {
            var song = db.Songs.GetById(id);

            if (song == null)
            {
                return this.BadRequest("There is no song with this Id!");
            }

            this.db.Songs.Delete(song);

            return this.Ok(song);
        }
    }
}