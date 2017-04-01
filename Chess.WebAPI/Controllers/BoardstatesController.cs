﻿using System;
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

namespace Chess.WebAPI.Controllers
{
    public class BoardstatesController : ApiController
    {
        private ChessWebAPIContext db = new ChessWebAPIContext();

        // GET: api/Boardstates
        public IQueryable<BoardstatesDTO> GetBoardstates()
        {
            var board = from b in db.Boardstates
                        select new BoardstatesDTO(b);

            return board;
            //return db.Boardstates.Include(g => g.GameId);
        }

        // GET: api/Boardstates/5
        [ResponseType(typeof(Boardstates))]
        public async Task<IHttpActionResult> GetBoardstates(int id)
        {
            var board = await db.Boardstates.Include(b => b.StateId).Select(b => new BoardstatesDTO(b)).SingleOrDefaultAsync(b => b.StateId == id);
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

        // probablly not needed
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

        // get board by ids
        public Boardstates GetStateById(int sId)
        {
            return db.Boardstates.SingleOrDefault(x => x.StateId == sId);
        }
        
        // add new state to bs
        public bool AddState(Board b)
        {
            Boardstates bs = new Boardstates();
            BoardConversion con = new BoardConversion();

            Boardstates lastMove = db.Boardstates.Last();
            Board last = con.MakeBoard(lastMove.State);
            // compare!

            string strB = con.MakeString(b);
            bs.State = strB;
            bs.StateId = (lastMove.StateId)++;
            bs.GameId = lastMove.GameId;
            bs.Timestamp = DateTime.Now;

            db.Boardstates.Add(bs);
            int x = db.SaveChanges();

            // successful db add
            if (x == 1)
                return true;

            return false;
        }
    }

    public class Board
    {
        Team turn;
        public Piece[,] board;

        public Piece GetPiece(int x, int y)
        {
            Piece p;
            p = board[x,y];

            // no piece there? return null
            if (p == null)
                return null;
            return p;
        }

        public void SetPiece(int x, int y, Team team, PieceType type)
        {
            board[x,y] = new Piece(team, type);
        }
    }

    public enum PieceType
    {
        pawn, rook, knight, bishop, king, queen, error = 0
    }

    public enum Team
    {
        black, white, error = 0
    }

    public class Piece
    {
        Team Team;
        PieceType Name;
        bool HasMoved;

        public Piece(Team t, PieceType n)
        {
            Team = t;
            Name = n;
            HasMoved = false;
        }

        public Team getTeam()
        {
            return Team;
        }

        public PieceType getName()
        {
            return Name;
        }

        public bool getHasMoved()
        {
            return HasMoved;
        }

        public void setHasMoved()
        {
            HasMoved = true;
        }

        public Piece copy()
        {
            return new Piece(Team, Name);
        }
    }
}