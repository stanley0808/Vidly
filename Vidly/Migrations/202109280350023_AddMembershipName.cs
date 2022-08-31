namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.String());
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
