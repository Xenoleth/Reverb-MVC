namespace Reverb.Data.Migrations
{
    using Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
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
            const string artistName1 = "Disturbed";
            const string artistName2 = "Pentakill";
            const string artistName3 = "Godsmack";
            const string artistName4 = "Rise Against";
            const string artistName5 = "Angel Vivaldi";

            const string genre1 = "Heavy Metal";
            const string genre2 = "Power Metal";
            const string genre3 = "Hard Rock";
            const string genre4 = "Punk Rock";
            const string genre5 = "Instrumental Rock";

            const string album1 = "Immortalized";
            const string cover1 = "http://inyourspeakers.com/files/images/reviews/disturbed-immortalizedjpg-16148.jpeg";
            const string song11 = "Immortalized";
            const string song12 = "The Vengeful One";
            const string song13 = "The Sound of Silence";
            const string song14 = "You're Mine";

            const string video11 = "https://www.youtube.com/embed/Auuqlcom6tM";
            const string video12 = "https://www.youtube.com/embed/8nW-IPrzM1g";
            const string video13 = "https://www.youtube.com/embed/u9Dg-g7t2l4";  
            const string video14 = "https://www.youtube.com/embed/vka6wPrB4E0";

            const string album2 = "Grasp of the Undying";
            const string cover2 = "https://allthatshreds.com/wp-content/uploads/2017/08/Pentakill-II-art.jpg";
            const string song21 = "Mortal Reminder";
            const string song22 = "Frozen Heart";
            const string song23 = "Tear of the Goddess";
            const string song24 = "The Bloodthirster";
            const string song25 = "Deadman's Plate";

            const string video21 = "https://www.youtube.com/embed/1UeMVfHN2P8";
            const string video22 = "https://www.youtube.com/embed/QJRLhRhcfgs";
            const string video23 = "https://www.youtube.com/embed/btSlfXILTkU";
            const string video24 = "https://www.youtube.com/embed/KBq_KtuSIF0";
            const string video25 = "https://www.youtube.com/embed/9ASxLLTu1ZY";

            const string album3 = "Faceless";
            const string cover3 = "https://i.pinimg.com/originals/a7/ef/54/a7ef54ea1ae678e6b1c8d1b8c7da1b8d.jpg";
            const string song31 = "I Stand Alone";
            const string song32 = "Straight Out of Line";

            const string video31 = "https://www.youtube.com/embed/OYjZK_6i37M";
            const string video32 = "https://www.youtube.com/embed/z9FmOc0ofGc";

            const string album4 = "The Sufferer the Witness";
            const string cover4 = "https://www.music-bazaar.com/album-images/vol1/62/62341/287918-big/The-Sufferer-And-The-Witness-cover.jpg";
            const string song41 = "Prayer of the Refugee";
            const string song42 = "Drones";
            const string song43 = "The Good Left Undones";

            const string video41 = "https://www.youtube.com/embed/9-SQGOYOjxs";
            const string video42 = "https://www.youtube.com/embed/94vo6NzQD5c";
            const string video43 = "https://www.youtube.com/embed/70hIRnj9kf8";

            const string album5 = "Universal Language";
            const string cover5 = "https://f4.bcbits.com/img/a2941452586_10.jpg";
            const string song51 = "A Venutian Spring";
            const string song52 = "A Mercurian Summer";
            const string song53 = "An Erisian Autumn";
            const string song54 = "A Martian Winter";

            const string video51 = "https://www.youtube.com/embed/hwPsSdAQCHY";
            const string video52 = "https://www.youtube.com/embed/uZLtzchX32c";
            const string video53 = "https://www.youtube.com/embed/86y0vYWDmm4";
            const string video54 = "https://www.youtube.com/embed/qFWoIyqSjlA";

            int? duration = 246;
            const string lyrics = "Comming soon";

            if (!context.Songs.Any())
            {
                var artist1 = new Artist()
                {
                    Name = artistName1
                };
                var artist2 = new Artist()
                {
                    Name = artistName2
                };
                var artist3 = new Artist()
                {
                    Name = artistName3
                };
                var artist4 = new Artist()
                {
                    Name = artistName4
                };
                var artist5 = new Artist()
                {
                    Name = artistName5
                };

                context.Artists.Add(artist1);
                context.Artists.Add(artist2);
                context.Artists.Add(artist3);
                context.Artists.Add(artist4);
                context.Artists.Add(artist5);

                var newGenre1 = new Genre()
                {
                    Name = genre1
                };
                var newGenre2 = new Genre()
                {
                    Name = genre2
                };
                var newGenre3 = new Genre()
                {
                    Name = genre3
                };
                var newGenre4 = new Genre()
                {
                    Name = genre4
                };
                var newGenre5 = new Genre()
                {
                    Name = genre5
                };

                context.Genres.Add(newGenre1);
                context.Genres.Add(newGenre2);
                context.Genres.Add(newGenre3);
                context.Genres.Add(newGenre4);
                context.Genres.Add(newGenre5);

                var newAlbum1 = new Album()
                {
                    Title = album1,
                    Artist = artist1,
                    CoverUrl = cover1
                };
                var newAlbum2 = new Album()
                {
                    Title = album2,
                    Artist = artist2,
                    CoverUrl = cover2
                };
                var newAlbum3 = new Album()
                {
                    Title = album3,
                    Artist = artist3,
                    CoverUrl = cover3
                };
                var newAlbum4 = new Album()
                {
                    Title = album4,
                    Artist = artist4,
                    CoverUrl = cover4
                };
                var newAlbum5 = new Album()
                {
                    Title = album5,
                    Artist = artist5,
                    CoverUrl = cover5
                };

                context.Albums.Add(newAlbum1);
                context.Albums.Add(newAlbum2);
                context.Albums.Add(newAlbum3);
                context.Albums.Add(newAlbum4);
                context.Albums.Add(newAlbum5);

                var newSong11 = new Song()
                {
                    Title = song11,
                    Album = newAlbum1,
                    Artist = artist1,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre1
                    },
                    VideoUrl = video11
                };
                var newSong12 = new Song()
                {
                    Title = song12,
                    Album = newAlbum1,
                    Artist = artist1,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre1
                    },
                    VideoUrl = video12
                };
                var newSong13 = new Song()
                {
                    Title = song13,
                    Album = newAlbum1,
                    Artist = artist1,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre1
                    },
                    VideoUrl = video13
                };
                var newSong14 = new Song()
                {
                    Title = song14,
                    Album = newAlbum1,
                    Artist = artist1,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre1
                    },
                    VideoUrl = video14
                };

                var newSong21 = new Song()
                {
                    Title = song21,
                    Album = newAlbum2,
                    Artist = artist2,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre2
                    },
                    VideoUrl = video21
                };
                var newSong22 = new Song()
                {
                    Title = song22,
                    Album = newAlbum2,
                    Artist = artist2,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre2
                    },
                    VideoUrl = video22
                };
                var newSong23 = new Song()
                {
                    Title = song23,
                    Album = newAlbum2,
                    Artist = artist2,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre2
                    },
                    VideoUrl = video23
                };
                var newSong24 = new Song()
                {
                    Title = song24,
                    Album = newAlbum2,
                    Artist = artist2,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre2
                    },
                    VideoUrl = video24
                };
                var newSong25 = new Song()
                {
                    Title = song25,
                    Album = newAlbum2,
                    Artist = artist2,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre2
                    },
                    VideoUrl = video25
                };

                var newSong31 = new Song()
                {
                    Title = song31,
                    Album = newAlbum3,
                    Artist = artist3,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre3
                    },
                    VideoUrl = video31
                };
                var newSong32 = new Song()
                {
                    Title = song32,
                    Album = newAlbum3,
                    Artist = artist3,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre3
                    },
                    VideoUrl = video32
                };

                var newSong41 = new Song()
                {
                    Title = song41,
                    Album = newAlbum4,
                    Artist = artist4,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre4
                    },
                    VideoUrl = video41
                };
                var newSong42 = new Song()
                {
                    Title = song42,
                    Album = newAlbum4,
                    Artist = artist4,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre4
                    },
                    VideoUrl = video42
                };
                var newSong43 = new Song()
                {
                    Title = song43,
                    Album = newAlbum4,
                    Artist = artist4,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre4
                    },
                    VideoUrl = video43
                };

                var newSong51 = new Song()
                {
                    Title = song51,
                    Album = newAlbum5,
                    Artist = artist5,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre5
                    },
                    VideoUrl = video51
                };
                var newSong52 = new Song()
                {
                    Title = song52,
                    Album = newAlbum5,
                    Artist = artist5,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre5
                    },
                    VideoUrl = video52
                };
                var newSong53 = new Song()
                {
                    Title = song53,
                    Album = newAlbum5,
                    Artist = artist5,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre5
                    },
                    VideoUrl = video53
                };
                var newSong54 = new Song()
                {
                    Title = song54,
                    Album = newAlbum5,
                    Artist = artist5,
                    Duration = duration,
                    Lyrics = lyrics,
                    Genres = new HashSet<Genre>()
                    {
                        newGenre5
                    },
                    VideoUrl = video54
                };

                context.Songs.Add(newSong11);
                context.Songs.Add(newSong12);
                context.Songs.Add(newSong13);
                context.Songs.Add(newSong14);

                context.Songs.Add(newSong21);
                context.Songs.Add(newSong22);
                context.Songs.Add(newSong23);
                context.Songs.Add(newSong24);
                context.Songs.Add(newSong25);

                context.Songs.Add(newSong31);
                context.Songs.Add(newSong32);

                context.Songs.Add(newSong41);
                context.Songs.Add(newSong42);
                context.Songs.Add(newSong43);

                context.Songs.Add(newSong51);
                context.Songs.Add(newSong52);
                context.Songs.Add(newSong53);
                context.Songs.Add(newSong54);
                
                context.SaveChanges();
            }
        }

        private void SeedAdmin(ReverbDbContext context)
        {
            const string AdminUserName = "admin@mail.bg";
            const string AdminPassword = "asdasd";

            const string RegualarUserName = "pesho@mail.bg";
            const string RegularPassword = "asdasd";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                var role2 = new IdentityRole { Name = "User" };
                roleManager.Create(role);
                roleManager.Create(role2);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdminUserName,
                    Email = AdminUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };
                var user2 = new User
                {
                    UserName = RegualarUserName,
                    Email = RegualarUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdminPassword);
                userManager.AddToRole(user.Id, "Admin");

                userManager.Create(user2, RegularPassword);
                userManager.AddToRole(user2.Id, "User");
            }
        }
    }
}
