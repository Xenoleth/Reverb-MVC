using Bytes2you.Validation;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using Reverb.Services.Contracts;
using System.Linq;

namespace Reverb.Services
{
    public class GenreService : IGenreService
    {
        private readonly IEfContextWrapper<Genre> genresRepo;
        private readonly ISaveContext context;

        public GenreService(IEfContextWrapper<Genre> genresRepo, ISaveContext context)
        {
            Guard.WhenArgument(genresRepo, "genresRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.genresRepo = genresRepo;
            this.context = context;
        }

        public IQueryable<Genre> GetGenres()
        {
            return this.genresRepo.All;
        }

        public void Update(Genre genre)
        {
            Guard.WhenArgument(genre, "genre").IsNull().Throw();

            this.genresRepo.Update(genre);
            this.context.SaveChanges();
        }
    }
}
