namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddADOBToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers set DateOfBirth = GETDATE() where id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
