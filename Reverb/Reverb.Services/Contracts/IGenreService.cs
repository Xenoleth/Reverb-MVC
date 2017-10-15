using Reverb.Data.Models;
using System.Linq;

namespace Reverb.Services.Contracts
{
    public interface IGenreService
    {
        IQueryable<Genre> GetGenres();

        void Update(Genre genre);
    }
}
