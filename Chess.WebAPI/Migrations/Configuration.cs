namespace Chess.WebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Chess.WebAPI.Models;
    using System.Collections.Generic;

    public sealed class DbApiConfiguration : DropCreateDatabaseAlways<ChessWebAPIContext>
    {
        public DbApiConfiguration( ) 
        {
            //AutomaticMigrationsEnabled = false;
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
            //DateTime time1 = new DateTime(1970, 1, 1, 1, 1, 1);
            //DateTime time2 = DateTime.Now;
            //Array[,] board = new Array[8,8];
            // google resful api tester/firefox resful api tester

            //context.Games.AddOrUpdate(
            //    x => x.GameId,
            //    new Games() { GameId = 0001, StartTime = time1, EndTime = time1 },
            //    new Games() { GameId = 0002, StartTime = time1, EndTime = time2 }
            //    );

            //context.Boardstates.AddOrUpdate(
            //    x => x.StateId,
            //    new Boardstates() { StateId = 0001, GameId = 0000, Timestamp = time1, State = "0" },
            //    new Boardstates() { StateId = 0002, GameId = 0001, Timestamp = time2, State = "0" }
            //    );

            for (var x = 0; x < 5; x++)
            {
                var date = new DateTime(2000 + x, 1, 1);
                var g = new Games()
                {
                    StartTime = date,
                    EndTime = date.AddDays(1)
                };
                context.Games.Add(g);
                context.SaveChanges();
                List<Boardstates> states = new List<Boardstates>();

                for (var y = 0; y < 20; y++)
                {
                    var state = new Boardstates()
                    {
                        Game = g,
                        GameId = g.GameId,
                        State = $"{y + 1}",
                        Timestamp = date.AddMinutes(y + 1)
                    };
                    states.Add(state);
                }
                context.Boardstates.AddRange(states);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }



   
}
