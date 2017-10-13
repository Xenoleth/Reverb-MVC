using Microsoft.AspNet.Identity.EntityFramework;
using Reverb.Data.Contracts;
using Reverb.Data.Models;
using Reverb.Data.Models.Contracts;
using System;
using System.Data.Entity;
using System.Linq;

namespace Reverb.Data
{
    public class ReverbDbContext : IdentityDbContext<User>, IReverbDbContext
    {
        public ReverbDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Song> Songs { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IModifiable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IModifiable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public static ReverbDbContext Create()
        {
            return new ReverbDbContext();
        }
    }
}
