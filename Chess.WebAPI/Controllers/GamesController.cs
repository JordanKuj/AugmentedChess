using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Chess.WebAPI.Models;

namespace Chess.WebAPI.Controllers
{
    public class GamesController : ApiController
    {
        private ChessWebAPIContext db = new ChessWebAPIContext();

        // GET: api/Games
        public IQueryable<GamesDTO> GetGames()
        {
            var game = from g in db.Games
                       select new GamesDTO()
                       {
                           GameId = g.GameId,
                           StartTime = g.StartTime,
                           EndTime = g.EndTime
                       };
            return game;
            //return db.Games;
        }

        // GET: api/Games/5
        [ResponseType(typeof(Games))]
        public async Task<IHttpActionResult> GetGames(int id)
        {
            // finalize in sprint 2
            /*var game = await db.Games.Include(g => g.GameId).Select(g => new GamesDTO()
                {
                    GameId = g.GameId,
                    StartTime = g.StartTime,
                    EndTime = g.EndTime
                }).SingleOrDefaultAsync(g => g.GameId == id);*/
            Games games = await db.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }

            return Ok(games);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGames(int id, Games games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != games.GameId)
            {
                return BadRequest();
            }

            db.Entry(games).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Games
        [ResponseType(typeof(Games))]
        public async Task<IHttpActionResult> PostGames(Games games)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(games);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = games.GameId }, games);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Games))]
        public async Task<IHttpActionResult> DeleteGames(int id)
        {
            Games games = await db.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }

            db.Games.Remove(games);
            await db.SaveChangesAsync();

            return Ok(games);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GamesExists(int id)
        {
            return db.Games.Count(e => e.GameId == id) > 0;
        }
    }
}