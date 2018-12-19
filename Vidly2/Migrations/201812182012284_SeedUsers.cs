namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3921dc34-e162-49fe-82d0-2787152e2273', N'admin@vidly.com', 0, N'ALmVjGVStTimmpFZR4DY29GXB42FooGHg7Gns5d/E4eoqhQxAqMHqeUZeUf3ojc3Hg==', N'a380ac40-ae1d-4a16-84b4-3cae746cc04a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'49dc123c-9b14-44f1-a0e8-6f252f07e903', N'charlie_michael61@msn.com', 0, N'ALWEf5a6BYfenBDk7NFgzXToocPA/Zo26mKwVsmSIa3rP4zMpgvTnDgM8oHpr76V4w==', N'f4d3c6ea-f213-4de3-b94b-a28b73727b30', NULL, 0, 0, NULL, 1, 0, N'charlie_michael61@msn.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9169712a-83ac-44f7-af6b-899d5801c882', N'stManager@vidly.com', 0, N'ADzVHnBIW8NZs6Qw3MqxNBmtlH8hff+iCJCeTRc/+YiJekHycK0lpI7SSNR6HnrrXw==', N'5fb38fe9-d82b-49cd-9d6a-6b5802e3d091', NULL, 0, 0, NULL, 1, 0, N'stManager@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e5a9023a-5248-4a44-82c3-45efc311ab7e', N'guest@vidly.com', 0, N'AP+VJG+P6YKOhSFLQiNsYnGuK6Cz2H2Z05b6lglILBor2CGF6e7JZZ2pshSO4SqXZQ==', N'45659472-e73a-4ba3-a0de-f8777a8dcf53', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9b8a72a8-292f-43b2-9dac-b4074ca55f13', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9169712a-83ac-44f7-af6b-899d5801c882', N'9b8a72a8-292f-43b2-9dac-b4074ca55f13')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
