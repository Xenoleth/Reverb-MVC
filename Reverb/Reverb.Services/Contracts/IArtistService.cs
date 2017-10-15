using Reverb.Data.Models;
using System.Linq;

namespace Reverb.Services.Contracts
{
    public interface IArtistService
    {
        IQueryable<Artist> GetArtists();

        void Update(Artist artist);
    }
}
