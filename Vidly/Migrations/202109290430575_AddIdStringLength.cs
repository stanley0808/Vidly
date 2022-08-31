namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdStringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Genres", "movie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "movie", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Genres", "Name", c => c.String());
        }
    }
}
