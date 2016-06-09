using BowlingGame.Helpers;
using BowlingGame.Languages;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BowlingGame.Classes
{
    public class GameValidation
    {
        Symbols symbols;
        Language lang;

        public GameValidation(Symbols symbols, Language lang)
        {
            this.symbols = symbols;
            this.lang = lang;
        }

        /// <summary>
        /// Perform some basic validation on the input string
        /// </summary>
        /// <param name="scorecard">Bowling game scorecard in agreed format</param>
        /// <param name="symbols">Symbol set we are using</param>
        public BowlingResult ValidateInput(string scorecard)
        {
            /// create a new data transfer object
            var result = new BowlingResult() { Success = true };

            /// remove whitespaces
            var input = new string(scorecard.Where(score => score != ' ').ToArray()); 

            /// check input string for valid lengths
            if (input.Length < 23 || input.Length > 32)
            {
                /// minimum length not met or maximum length exceeded
                result.Success = false;
                result.Message = lang.ERROR_GameLength;
                return result;
            }

            /// check if we have enough frames
            if (input.Count(boundary => boundary == symbols.Boundary) != 11)
            {
                /// invalid game format, not enough frame boundaries
                result.Success = false;
                result.Message = lang.ERROR_GameFormat;
                return result;
            }

            /// check character format
            var regexString = "(\\d|" + string.Format("([{0}{1}{2}{3}*]))", symbols.Strike, symbols.Boundary, symbols.Spare, @"\" + symbols.Miss) + "{23,32}";
            var regex = new Regex(regexString);
            if (!regex.Match(input).Success)
            {
                result.Success = false;
                result.Message = lang.ERROR_GameFormat;
                return result;
            }

            /// we need to split off the bonus balls for use later, if we split the input on the game end symbol now we can perform some validation while getting the result
            /// we add an arbitary character here to normalise the pattern of games without bonus frames
            input = input + symbols.NoBonusSub;
            var endGameSplit = new string[] { symbols.GameEnd };
            var gameSplit = input.Split(endGameSplit, StringSplitOptions.RemoveEmptyEntries);
            if (gameSplit.Length != 2)
            {
                /// we should only have one instance of end game character
                result.Success = false;
                result.Message = lang.ERROR_CharacterSequence;
                return result;
            }
            else
            {
                result.GameFrames = gameSplit[0].ToList();
                result.BonusBalls = gameSplit[1].ToList();
                result.BonusBalls.Remove(symbols.NoBonusSub);
            }
            return result;
        }
    }
}
