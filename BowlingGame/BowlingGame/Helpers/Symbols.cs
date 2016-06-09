using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Helpers
{
    /// <summary>
    /// Symbols used in game input
    /// </summary>
    public class Symbols
    {
        private readonly char strike = 'X';
        private readonly char spare = '/';
        private readonly char miss = '-';
        private readonly char boundary = '|';
        private readonly string gameEnd = "||";
        private readonly char noBonusSub = 'z';

        public Symbols() { }

        public Symbols(char strike, char spare, char miss, char boundary)
        {
            /// check for duplicates
            this.strike = AllChars.Exists(sym => sym == strike)? this.strike : strike;
            this.spare = AllChars.Exists(sym => sym == spare) ? this.spare : spare;
            this.miss = AllChars.Exists(sym => sym == miss) ? this.miss : miss;
            this.boundary = AllChars.Exists(sym => sym == boundary) ? this.boundary : boundary;
            this.gameEnd = this.boundary.ToString() + this.boundary.ToString();
        }

        public char Strike { get { return strike; } }
        public char Spare { get { return spare; } }
        public char Miss { get { return miss; } }
        public char Boundary { get { return boundary; } }
        public string GameEnd { get { return gameEnd; } }
        public char NoBonusSub { get { return noBonusSub; } }

        public List<char> AllChars
        {
            get
            {
                var symbolArray = new List<char>() {
                    strike,
                    spare,
                    miss,
                    boundary,
                    noBonusSub};
                return symbolArray;
            }
        }

        private bool DuplicateCheck(char symbol)
        {
            var array = AllChars;
            return array.Exists(sym => sym == symbol);
        }
    }
}
