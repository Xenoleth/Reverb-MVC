using Bytes2you.Validation;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using System.Linq;

namespace Reverb.Services
{
    public class SongService : ISongService
    {
        private readonly IEfContextWrapper<Song> songsRepo;
        private readonly ISaveContext context;

        public SongService(IEfContextWrapper<Song> songsRepo, ISaveContext context)
        {
            Guard.WhenArgument(songsRepo, "songRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.songsRepo = songsRepo;
            this.context = context;
        }

        public IQueryable<Song> GetSongs()
        {
            return this.songsRepo.All;
        }

        public void Update(Song song)
        {
            this.songsRepo.Update(song);
            this.context.SaveChanges();
        }
    }
}
