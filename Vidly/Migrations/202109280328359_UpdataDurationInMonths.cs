namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataDurationInMonths : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Membershiptypes SET DurationInMonths = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE Membershiptypes SET DurationInMonths = 'Monthly' WHERE Id = 2");
            Sql("UPDATE Membershiptypes SET DurationInMonths = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE Membershiptypes SET DurationInMonths = 'Yearly' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
