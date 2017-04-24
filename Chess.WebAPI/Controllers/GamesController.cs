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
using Chess.WebAPI.Tools;
using ChessTest;
using Chess.Core.Dtos;
using Chess.Core.Tools;

namespace Chess.WebAPI.Controllers
{
    [RoutePrefix("Games")]
    public class GamesController : ApiController
    {
        private readonly ChessWebAPIContext _db = new ChessWebAPIContext();

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(GamesDTO g)
        {
            g.StartTime = DateTime.Now;
            g.EndTime = DateTime.Now;

            var dbgame = new Games(g);
            _db.Games.Add(dbgame);
            var cha = _db.SaveChanges();
            g = dbgame.Convert();
            var b = new ChessTest.Board();
            b.fillNewBoard();

            var bs = BoardConversion.ToBoard(b);

            bs.GameId = g.GameId;
            bs.Turn = Team.error;
            bs.Timestamp = DateTime.Now;
            _db.Boardstates.Add(bs.ToBoard());

            _db.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [Route("{id}")]
        [HttpGet]
        public GamesDTO GetGameById(int gId)
        {
            Games g = _db.Games.SingleOrDefault(x => x.GameId == gId);
            GamesDTO gDto = g.Convert();
            return gDto;
        }

        // get last game/most recently added game
        [Route("")]
        [HttpGet]
        public GamesDTO GetMostRecentGame()
        {
            Games g = _db.Games.ToList().Last();
            GamesDTO gDto = g.Convert();
            return gDto;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }


        // add new game
        //[HttpPost]
        //[Route("")]
        //public bool AddState(BoardstateDTO b)
        //{
        //    //Games g = new Games();

        //    Boardstates lastMove = db.Boardstates.Last();
        //    ChessTest.Board last = BoardConversion.MakeBoard(lastMove.State);
        //    if (State.validState(b, last) == false)
        //        return false;

        //    //g.StartTime = DateTime.Now;

        //    //db.Games.Add(g);
        //    int x = db.SaveChanges();
        //    if (x == 1)
        //        return true;

        //    return false;
        //}

        // get game by ids

        //private bool GamesExists(int id)
        //{
        //    return db.Games.Count(e => e.GameId == id) > 0;
        //}

        //// returns game indicated by id
        //public GamesDTO GetGameById(int gId)
        //{
        //    Games g;
        //    GamesDTO game;
        //    g = db.Games.SingleOrDefault(x => x.GameId == gId);
        //    if (g == null)
        //        return null;
        //    game = new GamesDTO(g);
        //    return game;
        //}

        //// returns array containing all game ids
        //public List<int> GetAllGameIds()
        //{
        //    var games = db.Games.Include(g => g.GameId).Select(x => x.GameId).ToList();
        //    return games;
        //}

        //// returns most recent game (game added to db last)
        //public GamesDTO GetMostRecentGame()
        //{
        //    Games g;
        //    GamesDTO game;
        //    g = db.Games.Last();
        //    game = new GamesDTO(g);
        //    return game;
        //}

        //// add new game to db
        //private void AddNewGame()
        //{
        //    Games g = new Games();
        //    g.StartTime = DateTime.Now;

        //    db.Games.Add(g);
        //    // check when debugging int x = db.SaveChanges();
        //    db.SaveChanges();
        //}

        //// end game
        //private void EndGame(int gId)
        //{
        //    Games g = db.Games.SingleOrDefault(x => x.GameId == gId);
        //    g.EndTime = DateTime.Now;
        //    db.SaveChanges();
        //}

        // GET: api/Games
        //public IQueryable<GamesDTO> GetGames()
        //{
        //    var game = from g in db.Games
        //               select new GamesDTO()
        //               {
        //                   GameId = g.GameId,
        //                   StartTime = g.StartTime,
        //                   EndTime = g.EndTime
        //               };
        //    return game;
        //    //return db.Games;
        //}

        //// GET: api/Games/5
        //[ResponseType(typeof(Games))]
        //public async Task<IHttpActionResult> GetGames(int id)
        //{
        //    var games = await db.Games.Include(g => g.GameId).Select(g => new GamesDTO()
        //    {
        //        GameId = g.GameId,
        //        StartTime = g.StartTime,
        //        EndTime = g.EndTime
        //    }).SingleOrDefaultAsync(g => g.GameId == id);
        //    //Games games = await db.Games.FindAsync(id);
        //    if (games == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(games);
        //}

        //// PUT: api/Games/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutGames(int id, Games games)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != games.GameId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(games).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GamesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// probably not needed
        // POST: api/Games
        //[ResponseType(typeof(Games))]
        //public async Task<IHttpActionResult> PostGames(Games games)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Games.Add(games);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = games.GameId }, games);
        //}

        //// DELETE: api/Games/5
        //[ResponseType(typeof(Games))]
        //public async Task<IHttpActionResult> DeleteGames(int id)
        //{
        //    Games games = await db.Games.FindAsync(id);
        //    if (games == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Games.Remove(games);
        //    await db.SaveChangesAsync();

        //    return Ok(games);
        //}*/
        //[Route("")]
        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    var res = db.Games.OrderByDescending(x => x.GameId);
        //    if (res == null)
        //        return NotFound();
        //    else
        //    {
        //        var val = res.FirstOrDefault();
        //        return Ok(val.Convert());
        //    }
        //}
    }
}