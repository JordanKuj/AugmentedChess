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
using static ChessTest.Board;
using Chess.Core.Dtos;
using Chess.Core.Tools;

namespace Chess.WebAPI.Controllers
{
    [RoutePrefix("Boardstates")]
    public class BoardstatesController : ApiController
    {
        private ChessWebAPIContext db = new ChessWebAPIContext();




        [Route("")]
        [HttpPost]
        public BoardstateDTO PutBoardstates(BoardstateDTO boardstates)
        {
            if (!ModelState.IsValid)
                return db.Games.Include(x => x.States).ToList().Last().States.Last().ToBoard();

            var lastgame = db.Games.ToList().Last();
            var bs = boardstates.ToBoard();
            bs.GameId = lastgame.GameId;
            db.Boardstates.Add(bs);

            db.SaveChanges();


            return bs.ToBoard();
        }

        [Route("{id}")]
        [HttpGet]
        public List<BoardstateDTO> GetStateByGameId(int gId)
        {
            var bs = db.Boardstates.Where(x => x.GameId == gId);
            var results = new List<BoardstateDTO>();

            foreach (var b in bs)
                results.Add(b.ToBoard());

            return results;
        }

        // get last move/most recently added boardstate
        [Route("")]
        [HttpGet]
        public BoardstateDTO GetMostRecentState()
        {
            Boardstates bs = db.Boardstates.ToList().LastOrDefault();
            BoardstateDTO bsDTO = bs.ToBoard();
            return bsDTO;
        }

        // predict
        [Route("Moves")]
        [HttpGet]
        public List<Moveset> predictMoves()
        {
            Boardstates lastMove = db.Boardstates.Last();
            ChessTest.Board last = BoardConversion.MakeBoard(lastMove.State);
            List<Moveset> moves = last.listAllMoves(last.turn);

            return moves;
        }







        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool BoardstatesExists(int id)
        {
            return db.Boardstates.Count(e => e.StateId == id) > 0;
        }
    }



    /*// POST: api/Boardstates
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
    }*/
    // probably not needed
    // GET: api/Boardstates
    //public IQueryable<BoardstateDTO> GetBoardstates()
    //{
    //    var board = from b in db.Boardstates
    //                select b.ToBoard();
    //    return board;
    //    //return db.Boardstates.Include(g => g.GameId);
    //}
    // add new state to bs
    //[HttpPost]
    //public bool AddState(ChessTest.Board b)
    //{
    //    Boardstates bs = new Boardstates();

    //    Boardstates lastMove = db.Boardstates.Last();
    //    ChessTest.Board last = BoardConversion.MakeBoard(lastMove.State);
    //    if (State.validState(b, last) == false)
    //        return false;

    //    string strB = BoardConversion.MakeString(b);
    //    bs.State = strB;
    //    bs.StateId = (lastMove.StateId)++;
    //    bs.GameId = lastMove.GameId;
    //    bs.Timestamp = DateTime.Now;

    //    db.Boardstates.Add(bs);
    //    int x = db.SaveChanges();
    //    //TODO: if checkmate check
    //    // successful db add
    //    if (x == 1)
    //        return true;

    //    return false;
    //}







    // get board by ids

}