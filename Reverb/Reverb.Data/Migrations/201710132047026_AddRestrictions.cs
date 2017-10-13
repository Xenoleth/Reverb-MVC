namespace Reverb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRestrictions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "Title", c => c.String());
        }
    }
}
