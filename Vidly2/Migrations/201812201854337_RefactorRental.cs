namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorRental : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rentals", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.Rentals", name: "MovieId", newName: "Movie_Id");
            RenameIndex(table: "dbo.Rentals", name: "IX_CustomerId", newName: "IX_Customer_Id");
            RenameIndex(table: "dbo.Rentals", name: "IX_MovieId", newName: "IX_Movie_Id");
            AddColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            DropColumn("dbo.Rentals", "RentalDate");
            DropColumn("dbo.Rentals", "DueDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "DueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rentals", "RentalDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Rentals", "DateReturned");
            DropColumn("dbo.Rentals", "DateRented");
            RenameIndex(table: "dbo.Rentals", name: "IX_Movie_Id", newName: "IX_MovieId");
            RenameIndex(table: "dbo.Rentals", name: "IX_Customer_Id", newName: "IX_CustomerId");
            RenameColumn(table: "dbo.Rentals", name: "Movie_Id", newName: "MovieId");
            RenameColumn(table: "dbo.Rentals", name: "Customer_Id", newName: "CustomerId");
        }
    }
}
