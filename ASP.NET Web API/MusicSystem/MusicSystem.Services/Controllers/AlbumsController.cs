namespace MusicSystem.Services.Controllers
{
    using Data.Repositories;
    using Models;
    using MusicSystem.Models;
    using System.Web.Http;

    public class AlbumsController : ApiController
    {
        private readonly IMusicSystemData db;

        public AlbumsController(IMusicSystemData db)
        {
            this.db = db;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.db.Albums.All());
        }

        public IHttpActionResult Get(int id)
        {
            var albul = db.Albums.GetById(id);

            if (albul == null)
            {
                return this.BadRequest("There is no album with this Id!");
            }

            return this.Ok(albul);
        }

        public IHttpActionResult Post(AlbumResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var album = new Album
            {
                Title = model.Title,
                Producer = model.Producer,
                Year = model.Year
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();

            return this.Created(this.Url.ToString(), album);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumResponseModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var album = db.Albums.GetById(id);

            if (album == null)
            {
                return this.BadRequest("There is no album with this Id!");
            }

            album.Title = model.Title;
            album.Producer = model.Producer;
            album.Year = model.Year;

            this.db.Albums.Update(album);
            this.db.SaveChanges();

            return this.Ok(album);
        }

        public IHttpActionResult Delete(int id)
        {
            var album = db.Albums.GetById(id);

            if (album == null)
            {
                return this.BadRequest();
            }

            this.db.Albums.Delete(album);

            return this.Ok(album);
        }
    }
}
