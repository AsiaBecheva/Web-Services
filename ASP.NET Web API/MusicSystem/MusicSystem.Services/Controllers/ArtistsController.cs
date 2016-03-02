namespace MusicSystem.Services.Controllers
{
    using Models;
    using System.Web.Http;
    using System;
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
            throw new NotImplementedException();
        }

        public IHttpActionResult Post(ArtistResponseModel model)
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
    }
}
