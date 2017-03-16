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
    public class BoardstatesController : ApiController
    {
        private ChessWebAPIContext db = new ChessWebAPIContext();

        // GET: api/Boardstates
        public IQueryable<Boardstates> GetBoardstates()
        {
            // finalize in sprint 2
            /*var board = from b in db.Boardstates
                        select new BoardstatesDTO()
                        {
                            StateId = b.StateId,
                            Timestamp = b.Timestamp,
                            State = b.State,
                            GameId = b.Include(g => g.GameId)
                        };
            return board;*/
            return db.Boardstates.Include(g => g.GameId);
        }

        // GET: api/Boardstates/5
        [ResponseType(typeof(Boardstates))]
        public async Task<IHttpActionResult> GetBoardstates(int id)
        {
            // finalize in sprint 2
            /*var board = await db.Boardstates.Include(b => b.StateId).Select(b => new BoardstatesDTO()
            {
                StateId = b.StateId,
                Timestamp = b.Timestamp,
                State = b.State,
                GameId = b.GameId
            }).SingleOrDefaultAsync(b => b.StateId == id);*/
            Boardstates boardstates = await db.Boardstates.FindAsync(id);
            if (boardstates == null)
            {
                return NotFound();
            }

            return Ok(boardstates);
        }

        // PUT: api/Boardstates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBoardstates(int id, Boardstates boardstates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boardstates.StateId)
            {
                return BadRequest();
            }

            db.Entry(boardstates).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardstatesExists(id))
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

        // POST: api/Boardstates
        [ResponseType(typeof(Boardstates))]
        public async Task<IHttpActionResult> PostBoardstates(Boardstates boardstates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Boardstates.Add(boardstates);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = boardstates.StateId }, boardstates);
        }

        // DELETE: api/Boardstates/5
        [ResponseType(typeof(Boardstates))]
        public async Task<IHttpActionResult> DeleteBoardstates(int id)
        {
            Boardstates boardstates = await db.Boardstates.FindAsync(id);
            if (boardstates == null)
            {
                return NotFound();
            }

            db.Boardstates.Remove(boardstates);
            await db.SaveChangesAsync();

            return Ok(boardstates);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardstatesExists(int id)
        {
            return db.Boardstates.Count(e => e.StateId == id) > 0;
        }
    }
}