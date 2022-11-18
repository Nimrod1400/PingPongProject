using System;

namespace Model
{
    public class Game
    {
        public byte MaxScore { get; set; } = 11;
        public byte FirstSideScore { get; set; }
        public byte SecondSideScore { get; set; }
        public byte FirstSideMatchesScore { get; set; }
        public byte SecondSideMatchesScore { get; set; }
    }
}
