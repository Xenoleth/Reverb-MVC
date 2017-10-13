using Microsoft.AspNet.Identity.EntityFramework;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using System.Data.Entity;

namespace Reverb.Data
{
    public class ReverbDbContext : IdentityDbContext<User>, IReverbDbContext
    {
        public ReverbDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Song> Songs { get; set; }

        public static ReverbDbContext Create()
        {
            return new ReverbDbContext();
        }
    }
}
