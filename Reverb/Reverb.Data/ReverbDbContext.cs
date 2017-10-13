using Microsoft.AspNet.Identity.EntityFramework;
using Reverb.Data.Models;

namespace Reverb.Data
{
    public class ReverbDbContext : IdentityDbContext<User>
    {
        public ReverbDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public static ReverbDbContext Create()
        {
            return new ReverbDbContext();
        }
    }
}
