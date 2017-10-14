namespace Reverb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequirementForArtistInSong : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "Artist_Id" });
            AlterColumn("dbo.Songs", "Artist_Id", c => c.Guid());
            CreateIndex("dbo.Songs", "Artist_Id");
            AddForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "Artist_Id" });
            AlterColumn("dbo.Songs", "Artist_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Songs", "Artist_Id");
            AddForeignKey("dbo.Songs", "Artist_Id", "dbo.Artists", "Id", cascadeDelete: true);
        }
    }
}
