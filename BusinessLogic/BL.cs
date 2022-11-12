using Model;
using System;

namespace BusinessLogic
{
    public class BL
    {
        public Game Game { get; set; } = new Game();

        public byte MaxScore { get; set; } = 11;

        public int GetScore(int side)
        {
            if (side != 1 | side != 2)
                throw new Exception("Side must be equal 1 or 2");
            if (side == 1)
                return Game.FirstSideScore;
            else
                return Game.SecondSideScore;
        }
        //TODO: GetMatchesScore, other methods and properties to get info about Game state 

        public void ResetMatch()
        {
            Game.FirstSideScore = 0;
            Game.SecondSideScore = 0;
        }

        public void ResetGame()
        {
            Game Match = new Game();
        }

        public void IncrementFirstSideScore()
        {
            Game.FirstSideScore++;

            if (Game.FirstSideScore >= MaxScore &&  
                Game.FirstSideScore - Game.SecondSideScore >= 2)
            {
                Game.FirstSideMatchesScore++;
                ResetMatch();
            }
        }

        public void IncrementSecondSideScore()
        {
            Game.SecondSideScore++;

            if (Game.SecondSideScore >= MaxScore &&
                Game.SecondSideScore - Game.FirstSideScore >= 2)
            {
                Game.SecondSideMatchesScore++;
                ResetMatch();
            }
        }
    }
}
