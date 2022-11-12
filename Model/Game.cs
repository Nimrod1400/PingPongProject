using System;

namespace Model
{
    public class Game
    {
        public byte MaxScore { get; set; } = 11;

        public byte WhoStartedGame { get; set; } = 1; // 1 (first side) or 2 (second side);
                                                 // defines who was kicking off when first match in a game started
        public byte WhoStartedMatch
        {
            get
            {
                int amountOfMatches = FirstSideMatchesScore + SecondSideMatchesScore;

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
                    return ClassicServing();
                else
                    return MoreThanMaxScoreServing();
            }
        } // defines who must be kicking off rn
        public byte FirstSideScore { get; set; }
        public byte SecondSideScore { get; set; }
        public byte FirstSideMatchesScore { get; set; }
        public byte SecondSideMatchesScore { get; set; }
        public bool IsMoreThanMaxScore
        {
            get
            {
                return FirstSideScore >= 11 || SecondSideScore >= 11;
            }
        }

        private byte ClassicServing()
        {
            byte servesAmount = (byte)(SecondSideScore + FirstSideScore + 1);

            if (servesAmount % 4 == 0 || (servesAmount + 1) % 4 == 0)
                return InverseServe(WhoStartedMatch);
            else
                return WhoStartedMatch;
        }

        private byte MoreThanMaxScoreServing()
        {
            byte servesAmount = (byte)(SecondSideScore + FirstSideScore + 1
                - (MaxScore - 1) * 2);
            if (servesAmount % 2 == 0 || (servesAmount + 1) % 2 == 0)
                return InverseServe(WhoStartedMatch);
            else
                return WhoStartedMatch;
        }

        private byte InverseServe(byte currentServe)
        {
            if (currentServe == 1) { return 2; }
            else { return 1; }
        }
    }
}
