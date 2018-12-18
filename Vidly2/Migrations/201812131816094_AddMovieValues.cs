namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieValues : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) " 
            + "Values('Shawshank Redemption',3,GETDATE(),GETDATE(),5)");
            Sql("Insert into Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) "
                + "Values('Pulp Fiction',2,GETDATE(),GETDATE(),1)");
            Sql("Insert into Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) "
                + "Values('From Dusk Till Dawn',1,GETDATE(),GETDATE(),2)");
            Sql("Insert into Movies (Name,GenreId,ReleaseDate,DateAdded,NumberInStock) "
                + "Values('Mission: Impossible',4,GETDATE(),GETDATE(),10)");
        }
        
        public override void Down()
        {
        }
    }
}
