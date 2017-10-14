using Reverb.Data.Models;
using System.Linq;

namespace Reverb.Services.Contracts
{
    public interface ISongService
    {
        IQueryable<Song> GetSongs();

        void Update(Song song);
    }
}
