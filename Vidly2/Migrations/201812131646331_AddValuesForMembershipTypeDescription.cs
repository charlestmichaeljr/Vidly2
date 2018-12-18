namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValuesForMembershipTypeDescription : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes  set description = 'Pay as you go' where id = 1");
            Sql("Update MembershipTypes  set description = 'Monthly' where id = 2");
            Sql("Update MembershipTypes  set description = 'Quarterly' where id = 3");
            Sql("Update MembershipTypes  set description = 'Annually' where id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
