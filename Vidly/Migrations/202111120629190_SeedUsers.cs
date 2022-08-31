namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8685a3fe-eb5f-4c31-96d0-3a2ec845b417', N'admin@vidly.com', 0, N'AHyWs509mxi6EeFWX/wkeu8qa3+qol4YwprEJwp1DYtPCoRqHugmoeSRgMUcZGp0FA==', N'2d6fc100-2264-4751-8557-d3776d601e4d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'faf785f0-607b-469d-8ba4-554387ace865', N'asdf831038@gmail.com', 0, N'AJPeMAw8cxnT5rXaV8R1b3MtwuNmz6WfPeFqwOMmjkP6+Vz68zg0LsRfeMDSU2vMMg==', N'aa488ea9-17bb-4f37-af2f-b8966e1a30e5', NULL, 0, 0, NULL, 1, 0, N'asdf831038@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a1f549d4-1110-4801-8740-f241816a69d5', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8685a  3fe-eb5f-4c31-96d0-3a2ec845b417', N'a1f549d4-1110-4801-8740-f241816a69d5')
");
        }
        
        public override void Down()
        {
        }
    }
}
