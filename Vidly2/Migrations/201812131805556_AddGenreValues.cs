namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreValues : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres ( Description) Values('Comedy')");
            Sql("Insert into Genres ( Description) Values('Drama')");
            Sql("Insert into Genres ( Description) Values('Action')");
            Sql("Insert into Genres ( Description) Values('Musical')");
            Sql("Insert into Genres ( Description) Values('Documentary')");

        }
        
        public override void Down()
        {
        }
    }
}
