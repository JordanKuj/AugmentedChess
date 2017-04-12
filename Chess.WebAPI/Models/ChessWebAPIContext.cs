using Chess.WebAPI.Migrations;
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

        public ChessWebAPIContext() : base("Server=.\\sqlexpress;Database=ChessDb;Trusted_Connection=True")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //Database.SetInitializer(new DbApiConfiguration());
            
            //Database.Initialize(false);
        }

        public System.Data.Entity.DbSet<Chess.WebAPI.Models.Games> Games { get; set; }

        public System.Data.Entity.DbSet<Chess.WebAPI.Models.Boardstates> Boardstates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
