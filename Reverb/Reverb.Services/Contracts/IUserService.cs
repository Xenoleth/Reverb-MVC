using Reverb.Data.Models;
using System.Linq;

namespace Reverb.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();

        void AddFavoriteSong(Song song, string email);

        void RemoveFavoriteSong(Song song, string email);
    }
}
