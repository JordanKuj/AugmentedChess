using Chess.Core.Dtos;
using Chess.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.WebAPI.Tools
{
    public static class Extensions
    {

        public static Boardstates ToBoard(this BoardstatesDTO bs)
        {
            var b = new Boardstates();
            b.StateId = bs.StateId;
            b.Timestamp = bs.Timestamp;
            b.State = bs.State;
            b.GameId = bs.GameId;
            return b;
        }
        public static BoardstatesDTO ToBoard(this Boardstates bs)
        {
            var b = new BoardstatesDTO();
            b.StateId = bs.StateId;
            b.Timestamp = bs.Timestamp;
            b.State = bs.State;
            b.GameId = bs.GameId;
            return b;
        }

        public static Games Convert(this GamesDTO g)
        {
            var game = new Games();
            game.GameId = g.GameId;
            game.StartTime = g.StartTime;
            game.EndTime = g.EndTime;
            return game;
        }
        public static GamesDTO Convert(this Games g)
        {
            var game = new GamesDTO();
            game.GameId = g.GameId;
            game.StartTime = g.StartTime;
            game.EndTime = g.EndTime;
            return game;
        }
    }
}