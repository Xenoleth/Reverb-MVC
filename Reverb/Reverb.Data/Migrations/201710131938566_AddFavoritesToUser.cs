namespace Reverb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavoritesToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Songs", "User_Id");
            AddForeignKey("dbo.Songs", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Songs", new[] { "User_Id" });
            DropColumn("dbo.Songs", "User_Id");
        }
    }
}
