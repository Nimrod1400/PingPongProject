using Model;
using System;

namespace BusinessLogic
{
    public delegate void MatchEnd();
    public class Logic
    {
        public MatchEnd OnMatchEnd; // to sub from view

        public Game Game { get; set; } = new Game();

        public byte MaxScore
        {
            get { return Game.MaxScore; }
            set { Game.MaxScore = value; }
        }

        public int GetScore(int side)
        {

            if (side != 1 & side != 2)
                throw new Exception("Side must be equal 1 or 2");
            if (side == 1)
                return Game.FirstSideScore;
            else
                return Game.SecondSideScore;
        }

        public int GetMatchesScore(int side) 
        {
            if (side != 1 & side != 2)
                throw new Exception("Side must be equal 1 or 2");
            if (side == 1)
                return Game.FirstSideMatchesScore;
            else
                return Game.SecondSideMatchesScore;
        }

        public int GetServingSide()
        {
            return Game.WhoIsServing;
        }

        public void ResetMatch()
        {
            Game.FirstSideScore = 0;
            Game.SecondSideScore = 0;
        }

        public void ResetGame()
        {
            Game = new Game();
        }

        public void IncrementScore(int side)
        {
            if (side == 1)
            {
                Game.FirstSideScore++;

                if (CheckMatchEnding())
                {
                    Game.FirstSideMatchesScore++;
                    ResetMatch();
                }
            }

            else if (side == 2)
            {
                Game.SecondSideScore++;

                if (CheckMatchEnding())
                {
                    Game.SecondSideMatchesScore++;
                    ResetMatch();
                }
            }
        }


        private bool CheckMatchEnding()
        {
            bool isEnd = (Game.FirstSideScore >= Game.MaxScore &&
                Game.FirstSideScore - Game.SecondSideScore >= 2) ||
                (Game.SecondSideScore >= Game.MaxScore &&
                Game.SecondSideScore - Game.FirstSideScore >= 2);

            if (isEnd) 
                OnMatchEnd();

            return isEnd;
        }
    }
}
