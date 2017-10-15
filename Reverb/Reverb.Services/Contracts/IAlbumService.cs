using Reverb.Data.Models;
using System.Linq;

namespace Reverb.Services.Contracts
{
    public interface IAlbumService
    {
        IQueryable<Album> GetAlbums();

        void Update(Album album);
    }
}
