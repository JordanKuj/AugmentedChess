namespace Chess.WebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Chess.WebAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Chess.WebAPI.Models.ChessWebAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Chess.WebAPI.Models.ChessWebAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // meaningless time and boardstate to seed database
            DateTime time = new DateTime(1970, 1, 1, 1, 1, 1);
            Array[,] board = new Array[8,8];

            context.Games.AddOrUpdate(
                x => x.GameId,
                new Games() { GameId = 0000, StartTime = time, EndTime = time }
                );

            context.Boardstates.AddOrUpdate(
                x => x.StateId,
                new Boardstates() { StateId = 0000, GameId = 0000, Timestamp = time, State = board }
                );
        }
    }
}
