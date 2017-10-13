namespace Reverb.Data.Migrations
{
    using Contracts;
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
                // TODO: Seed database with music    

                this.SeedAdmin(context);
                this.SeedSongs(context);
        }

        private void SeedSongs(ReverbDbContext context)
        {
            const string artistName = "Pesho";
            const string albumTitle = "Album title";
            const string songTitle = "Song";
            const string songLyrics = "Lyrics";

            if (!context.Songs.Any())
            {
                var artist = new Artist()
                {
                    Name = artistName
                };

                context.Artists.Add(artist);

                var album = new Album()
                {
                    Title = albumTitle,
                    Artist = artist
                };

                context.Albums.Add(album);

                for (int i = 0; i < 5; i++)
                {
                    var song = new Song()
                    {
                        Title = songTitle + i,
                        Artist = artist,
                        Album = album,
                        Lyrics = songLyrics
                    };

                    context.Songs.Add(song);
                }

                context.SaveChanges();
            }
        }

        private void SeedAdmin(ReverbDbContext context)
        {
            const string AdminUserName = "admin@mail.bg";
            const string AdminPassword = "asdasd";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdminUserName,
                    Email = AdminUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdminPassword);
                userManager.AddToRole(user.Id, "Admin");
            }            
        }
    }
}
