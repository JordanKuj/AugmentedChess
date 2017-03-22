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

            // meaningless times and boardstates to seed database
            DateTime time1 = new DateTime(1970, 1, 1, 1, 1, 1);
            DateTime time2 = DateTime.Now;
            //Array[,] board = new Array[8,8];
            // google resful api tester/firefox resful api tester

            context.Games.AddOrUpdate(
                x => x.GameId,
                new Games() { GameId = 0001, StartTime = time1, EndTime = time1 },
                new Games() { GameId = 0002, StartTime = time1, EndTime = time2 }
                );

            context.Boardstates.AddOrUpdate(
                x => x.StateId,
                new Boardstates() { StateId = 0001, GameId = 0000, Timestamp = time1, State = "0" },
                new Boardstates() { StateId = 0002, GameId = 0001, Timestamp = time2, State = "0" }
                );
        }
    }
}
