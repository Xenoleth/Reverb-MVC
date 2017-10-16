using Bytes2you.Validation;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using System.Linq;

namespace Reverb.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IEfContextWrapper<Artist> artistsRepo;
        private readonly ISaveContext context;

        public ArtistService(IEfContextWrapper<Artist> artistsRepo, ISaveContext context)
        {
            Guard.WhenArgument(artistsRepo, "artistsRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.artistsRepo = artistsRepo;
            this.context = context;
        }

        public IQueryable<Artist> GetArtists()
        {
            return this.artistsRepo.All;
        }

        public void Update(Artist artist)
        {
            Guard.WhenArgument(artist, "artist").IsNull().Throw();

            this.artistsRepo.Update(artist);
            this.context.SaveChanges();
        }
    }
}
