namespace Reverb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreaseTextLimits : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "CoverUrl", c => c.String());
            AlterColumn("dbo.Songs", "Title", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Songs", "VideoUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "VideoUrl", c => c.String(maxLength: 100));
            AlterColumn("dbo.Songs", "Title", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Albums", "CoverUrl", c => c.String(maxLength: 100));
        }
    }
}
