using Reverb.Data.Models;
using System.Data.Entity;

namespace Reverb.Data.Contracts
{
    public interface IReverbDbContext
    {
        IDbSet<Song> Songs { get; set; }

        int SaveChanges();
    }
}
