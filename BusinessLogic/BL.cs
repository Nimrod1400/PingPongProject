using Model;
using System;

namespace BusinessLogic
{
    public class BL
    {
        public Game Game { get; set; } = new Game();

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

            if (Game.FirstSideScore >= Game.MaxScore && 
                Game.FirstSideScore - Game.SecondSideScore == 2)
            {
                Game.FirstSideMatchesScore++;
                ResetGame();
            }
        }

        public void IncrementSecondSideScore()
        {
            Game.SecondSideScore++;

            if (Game.SecondSideScore >= Game.MaxScore &&
                Game.SecondSideScore - Game.FirstSideScore == 2)
            {
                Game.SecondSideMatchesScore++;
                ResetGame();
            }
        }
    }
}
