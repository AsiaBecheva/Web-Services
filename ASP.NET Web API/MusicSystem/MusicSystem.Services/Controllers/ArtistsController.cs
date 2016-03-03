namespace MusicSystem.Services.Controllers
{
    using Models;
    using System.Web.Http;
    using Data.Repositories;
    using MusicSystem.Models;

    public class ArtistsController : ApiController
    {
        private readonly IMusicSystemData db;

        public ArtistsController(IMusicSystemData db)
        {
            this.db = db;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.db.Artists.All());
        }

        public IHttpActionResult Get(int id)
        {
            var artist = this.db.Artists.GetById(id);

            if (artist == null)
            {
                return this.BadRequest("There is no artist with this Id!");
            }

            return this.Ok(artist);
        }

        public IHttpActionResult Post([FromBody]ArtistResponseModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newArtist = new Artist
            {
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                Country = model.Country
            };

            db.Artists.Add(newArtist);
            db.SaveChanges();

            return this.Created(this.Url.ToString(), newArtist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistResponseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var artist = this.db.Artists.GetById(id);

            if (artist == null)
            {
                return this.BadRequest("There is no artist with this Id!");
            }

            artist.Name = model.Name;
            artist.Country = model.Country;
            artist.DateOfBirth = model.DateOfBirth;

            db.Artists.Update(artist);
            db.SaveChanges();

            return this.Ok(artist);
        }

        public IHttpActionResult Delete(int id)
        {
            var artist = db.Artists.GetById(id);

            if (artist == null)
            {
                return this.BadRequest("There is no artist with this Id!");
            }

            db.Artists.Delete(artist);
            db.SaveChanges();

            return this.Ok(artist);
        }
    }
}
