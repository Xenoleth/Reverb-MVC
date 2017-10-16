using Bytes2you.Validation;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using System.Linq;

namespace Reverb.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IEfContextWrapper<Album> albumsRepo;
        private readonly ISaveContext context;

        public AlbumService(IEfContextWrapper<Album> albumsRepo, ISaveContext context)
        {
            Guard.WhenArgument(albumsRepo, "albumsRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.albumsRepo = albumsRepo;
            this.context = context;
        }

        public IQueryable<Album> GetAlbums()
        {
            return this.albumsRepo.All;
        }

        public void Update(Album album)
        {
            Guard.WhenArgument(album, "album").IsNull().Throw();

            this.albumsRepo.Update(album);
            this.context.SaveChanges();
        }
    }
}
