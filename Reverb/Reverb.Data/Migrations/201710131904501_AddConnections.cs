namespace Reverb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConnections : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Song_Id", "dbo.Songs");
            DropIndex("dbo.Genres", new[] { "Song_Id" });
            CreateTable(
                "dbo.GenreSongs",
                c => new
                    {
                        Genre_Id = c.Guid(nullable: false),
                        Song_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Song_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.Song_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Song_Id);
            
            DropColumn("dbo.Genres", "Song_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Song_Id", c => c.Guid());
            DropForeignKey("dbo.GenreSongs", "Song_Id", "dbo.Songs");
            DropForeignKey("dbo.GenreSongs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.GenreSongs", new[] { "Song_Id" });
            DropIndex("dbo.GenreSongs", new[] { "Genre_Id" });
            DropTable("dbo.GenreSongs");
            CreateIndex("dbo.Genres", "Song_Id");
            AddForeignKey("dbo.Genres", "Song_Id", "dbo.Songs", "Id");
        }
    }
}
