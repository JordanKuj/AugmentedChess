using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chess.WebAPI.Models
{
    public class ChessWebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ChessWebAPIContext() : base("ChessWebAPIContext")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<Chess.WebAPI.Models.Games> Games { get; set; }

        public System.Data.Entity.DbSet<Chess.WebAPI.Models.Boardstates> Boardstates { get; set; }
    }

    public class ChessWebAPIDbInitalizer : DropCreateDatabaseAlways<ChessWebAPIContext>
    {
        protected override void Seed(ChessWebAPIContext context)
        {
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
