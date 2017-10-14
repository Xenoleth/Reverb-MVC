using Bytes2you.Validation;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using System.Linq;

namespace Reverb.Services
{
    public class UserService : IUserService
    {
        private readonly IEfContextWrapper<User> usersRepo;
        private readonly ISaveContext context;

        public UserService(IEfContextWrapper<User> usersRepo, ISaveContext context)
        {
            Guard.WhenArgument(usersRepo, "usersRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.usersRepo = usersRepo;
            this.context = context;
        }

        public IQueryable<User> GetUsers()
        {
            return this.usersRepo.All;
        }

        public void AddFavoriteSong(Song song, string email)
        {
            var user = this.usersRepo
                .All
                .Where(x => x.Email == email)
                .SingleOrDefault();

            user.FavoriteSongs.Add(song);  

            context.SaveChanges();
        }

        public void RemoveFavoriteSong(Song song, string email)
        {
            var user = this.usersRepo
                .All
                .Where(x => x.Email == email)
                .SingleOrDefault();

            user.FavoriteSongs.Remove(song);

            context.SaveChanges();
        }
    }
}
