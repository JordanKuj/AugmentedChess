using Chess.WebAPIClient;
using ChessTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch.Tools
{
    public class LocalGameManager
    {

        private List<BoardState> States = new List<BoardState>();
        public IBoardState LastMove => (IBoardState)States.Last();
        public event Action NewState;
        private WebClient _wc;
        private Task TInitalizing;
        public LocalGameManager()
        {
            _wc = new WebClient();
            TInitalizing = Task.Factory.StartNew(Initalize);
        }
        private async void Initalize()
        {
            var currentGame = await _wc.GetCurrentGame();
            if (currentGame == null)
            {
                currentGame = new GamesDTO();
                await _wc.CreateGame(currentGame);
                //TODO:Try web api
                var b = new Board();
                b.fillNewBoard();
                States.Add(b.ToBoard());
            }else
            {
                _wc.GetCurrentGameState()
            }
        }

        public bool SubmitNewState(BoardState state)
        {
            if (!TInitalizing.IsCompleted)
                return false;

            if (!State.getDiff(state.ToBoard(), LastMove.ToBoard()))
                if (State.validState(LastMove.ToBoard(), state.ToBoard()))
                {
                    States.Add(state);
                    NewState?.Invoke();
                    return true;
                }
            return false;
        }








    }
}
