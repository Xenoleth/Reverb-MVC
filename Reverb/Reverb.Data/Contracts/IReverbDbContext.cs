using Reverb.Data.Models;
using Reverb.Data.Models.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Reverb.Data.Contracts
{
    public interface IReverbDbContext
    {
        IDbSet<Song> Songs { get; set; }

        IDbSet<Album> Albums { get; set; }

        IDbSet<Artist> Artists { get; set; }

        IDbSet<Genre> Genres { get; set; }

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
