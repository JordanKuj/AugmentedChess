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
            Games g = _db.Games.Include(x => x.States).SingleOrDefault(x => x.GameId == gId);
            GamesDTO gDto = g.Convert();
            return gDto;
        }

        // get last game/most recently added game
        [Route("")]
        [HttpGet]
        public GamesDTO GetMostRecentGame()
        {
            Games g = _db.Games.Include(x => x.States).ToList().Last();
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
    }
}