using System.Collections.Generic;

namespace BowlingGame.Classes
{
    public class BowlingResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Score { get; set; }

        public List<char> GameFrames { get; set; }
        public List<char> BonusBalls { get; set; }
    }
}
