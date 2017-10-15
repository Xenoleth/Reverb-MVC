namespace Reverb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoverAndVideoUrls : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "CoverUrl", c => c.String(maxLength: 100));
            AddColumn("dbo.Songs", "VideoUrl", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "VideoUrl");
            DropColumn("dbo.Albums", "CoverUrl");
        }
    }
}
