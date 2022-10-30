using System;

namespace Model
{
    public class Game
    {

        public byte MaxScore { get; set; } = 11;
        public byte WhoStartedGame { get; set; } // 1 (first side) or 2 (second side);
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
                byte servesAmount = (byte)(SecondSideScore + FirstSideScore + 1);

                if (servesAmount % 4 == 0 || (servesAmount + 1) % 4 == 0)                
                    return InverseServe(WhoStartedMatch);                
                else                
                    return WhoStartedMatch;                
            }
        } // defines who must be kicking off rn
        public byte FirstSideScore { get; set; }
        public byte SecondSideScore { get; set; }
        public byte FirstSideMatchesScore { get; set; }
        public byte SecondSideMatchesScore { get; set; }

        private byte InverseServe(byte currentServe)
        {
            if (currentServe == 1) { return 2; }
            else { return 1; }
        }
    }
}
