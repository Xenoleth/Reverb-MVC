namespace Reverb.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ReverbDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ReverbDbContext context)
        {
            this.SeedAdmin(context);
        }

        private void SeedAdmin(ReverbDbContext context)
        {
            const string AdminUserName = "admin@mail.bg";
            const string AdminPassword = "1234";

            if (context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdminUserName, Email = AdminUserName, EmailConfirmed = true };

                userManager.Create(user, AdminPassword);
                userManager.AddToRole(user.Id, "Admin");
            }            
        }
    }
}
