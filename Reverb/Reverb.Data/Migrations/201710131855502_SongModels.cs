namespace Reverb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        Artist_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        Song_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.Song_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Song_Id);
            
            AddColumn("dbo.Songs", "Title", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Songs", "Duration", c => c.Int());
            AddColumn("dbo.Songs", "Lyrics", c => c.String(storeType: "ntext"));
            AddColumn("dbo.Songs", "Album_Id", c => c.Guid());
            AddColumn("dbo.Songs", "Artist_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Songs", "Album_Id");
            CreateIndex("dbo.Songs", "Artist_Id");
            AddForeignKey("dbo.Songs", "Album_Id", "dbo.Albums", "Id");
            AddForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "Song_Id", "dbo.Songs");
            DropForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Genres", new[] { "Song_Id" });
            DropIndex("dbo.Genres", new[] { "IsDeleted" });
            DropIndex("dbo.Artists", new[] { "IsDeleted" });
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            DropIndex("dbo.Albums", new[] { "IsDeleted" });
            DropIndex("dbo.Songs", new[] { "Artist_Id" });
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            DropColumn("dbo.Songs", "Artist_Id");
            DropColumn("dbo.Songs", "Album_Id");
            DropColumn("dbo.Songs", "Lyrics");
            DropColumn("dbo.Songs", "Duration");
            DropColumn("dbo.Songs", "Title");
            DropTable("dbo.Genres");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
