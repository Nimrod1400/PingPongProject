using System;

namespace Model
{
    public delegate void MatchEnd();

    public class Logic
    {
        public MatchEnd OnMatchEnd; // to sub from view

        private Game Game { get; set; } = new Game();
        public byte MaxScore
        {
            get { return Game.MaxScore; }
            set { Game.MaxScore = value; }
        }
        private bool IsMoreThanMaxScore
        {
            get
            {
                return Game.FirstSideScore >= 11 || Game.SecondSideScore >= 11;
            }
        }
        public byte WhoStartedGame { get; set; } = 1;
        public byte WhoStartedMatch
        {
            get
            {
                int amountOfMatches = Game.FirstSideMatchesScore + Game.SecondSideMatchesScore;

                if (amountOfMatches % 2 == 0)
                    return WhoStartedGame;
                else
                    return InverseServe(WhoStartedGame);
            }
        }
        public byte WhoIsServing
        {
            get
            {
                if (!IsMoreThanMaxScore)
                    return ClassicServingLogic();
                else
                    return MoreThanMaxScoreServingLogic();
            }
        }

        public int GetScore(int side)
        {
            if (side == 1)
                return Game.FirstSideScore;
            if (side == 2)
                return Game.SecondSideScore;
            else { throw new Exception("Side must be equal 1 or 2"); }
        }

        public int GetMatchesScore(int side) 
        {
            if (side == 1)
                return Game.FirstSideMatchesScore;
            if (side == 2)
                return Game.SecondSideMatchesScore;
            else { throw new Exception("Side must be equal 1 or 2"); }
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

            if (side == 2)
            {
                Game.SecondSideScore++;

                if (CheckMatchEnding())
                {
                    Game.SecondSideMatchesScore++;
                    ResetMatch();
                }
            }

            else if (side != 1 & side != 2) { throw new Exception("Side must be equal 1 or 2"); }
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

        private byte ClassicServingLogic()
        {
            byte servesAmount = (byte)(Game.SecondSideScore + Game.FirstSideScore + 1);

            if (servesAmount % 4 == 0 || (servesAmount + 1) % 4 == 0)
                return InverseServe(WhoStartedMatch);
            else
                return WhoStartedMatch;
        }

        private byte MoreThanMaxScoreServingLogic()
        {
            byte servesAmount = (byte)(Game.SecondSideScore + Game.FirstSideScore + 1
                - (MaxScore - 1) * 2);
            if (servesAmount % 2 == 0 || (servesAmount + 1) % 2 == 0)
                return InverseServe(WhoStartedMatch);
            else
                return WhoStartedMatch;
        }

        private byte InverseServe(byte currentServe)
        {
            if (currentServe == 1) { return 2; }
            else if (currentServe == 2) { return 1; }
            else { throw new Exception("Side must be equal 1 or 2"); }
        }
    }
}
