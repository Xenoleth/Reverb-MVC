namespace Reverb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserCollectionInSongs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Songs", new[] { "User_Id" });
            CreateTable(
                "dbo.UserSongs",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Song_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Song_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.Song_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Song_Id);
            
            DropColumn("dbo.Songs", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.UserSongs", "Song_Id", "dbo.Songs");
            DropForeignKey("dbo.UserSongs", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserSongs", new[] { "Song_Id" });
            DropIndex("dbo.UserSongs", new[] { "User_Id" });
            DropTable("dbo.UserSongs");
            CreateIndex("dbo.Songs", "User_Id");
            AddForeignKey("dbo.Songs", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
