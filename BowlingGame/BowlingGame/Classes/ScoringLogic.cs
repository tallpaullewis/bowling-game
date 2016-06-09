using System.Collections.Generic;
using System.Linq;
using BowlingGame.Helpers;
using BowlingGame.Languages;

namespace BowlingGame.Classes
{
    public class ScoringLogic
    {
        private Symbols symbols;
        private GameValidation gameValidation;

        /// <summary>
        /// Base constructor
        /// </summary>
        public ScoringLogic()
        {
            if (symbols == null) symbols = new Symbols();
        }

        /// <summary>
        /// Constructor if we want to use a custom symbol set
        /// </summary>
        public ScoringLogic(char strike, char spare, char miss, char boundary) : base()
        {
            symbols = new Symbols(strike, spare, miss, boundary);
        }

        /// <summary>
        /// To just get a result directly from a string input
        /// </summary>
        /// <param name="input">Bowling game</param>
        /// <returns>Result and message</returns>
        public BowlingResult GetResult(string input, Language lang)
        {
            if(gameValidation==null) gameValidation = new GameValidation(symbols, lang);
            var result = gameValidation.ValidateInput(input);
            if (!result.Success)
                return result;
            else
            {
                result.Score = CalculateScore(result.GameFrames, result.BonusBalls);
            }

            return result;
        }

        /// <summary>
        /// Calculate score based on a split input
        /// </summary>
        /// <param name="_gameFrames">Normal game frames</param>
        /// <param name="_bonusBalls">Bonus balls</param>
        /// <returns>Total score</returns>
        private int CalculateScore(List<char> _gameFrames, List<char> _bonusBalls)
        {
            var bonusBalls = _bonusBalls;
            var gameFrames = _gameFrames;
            var cumulativeScore = 0;

            /// insert another boundary symbol so that all game frames are the same
            gameFrames.Insert(0, symbols.Boundary);

            /// count total frames, should be 10 but just in case this is an unusual game
            var totalGameFrames = gameFrames.Count(divider => divider == symbols.Boundary);

            /// loop through every game
            for (int i = 0; i < totalGameFrames; i++)
            {
                /// we will reduce the game frame count by one frame each iteration
                if (gameFrames.Count > 0)
                {
                    /// set default values
                    var strike = false;
                    var spare = false;
                    var frameTurnLength = 1;
                    var frameScore = 0;

                    /// filter out misses & boundaries
                    /// gameFrames[0] is always aboundary
                    if (gameFrames[1] != symbols.Boundary && gameFrames[1] != symbols.Miss)
                    {
                        /// strikes can only occur in the first turn
                        if (gameFrames[1] == symbols.Strike) strike = true;
                        /// if it's not a strike it must be a normal score
                        else frameScore += ScoreFromSymbol(gameFrames[1]);
                    }
                    /// check if there are still balls in this frame
                    if (gameFrames.Count > 2 && gameFrames[2] != symbols.Boundary)
                    {
                        frameTurnLength = 2;
                        if (gameFrames[2] != symbols.Miss)
                        {
                            /// spares can only occur in the second turn
                            if (gameFrames[2] == symbols.Spare)
                            {
                                spare = true;
                                /// make this frame's score up to 10
                                frameScore += 10 - frameScore;
                            }
                            /// if it's not a spare it must be a normal score
                            else frameScore += ScoreFromSymbol(gameFrames[2]);
                        }
                    }

                    /// remove this frame, it is no longer required
                    gameFrames.RemoveRange(0, frameTurnLength + 1);

                    /// check strike or spare flags
                    if (strike)
                    {
                        /// strike score calculation looks 2 turns ahead
                        frameScore += 10;

                        /// check that we have enough buffer to avoid NPE when looking for the first next ball
                        if (i + 1 < totalGameFrames)
                        {
                            if (gameFrames[1] != symbols.Boundary && gameFrames[1] != symbols.Miss)
                                /// this is a nonspecific next frame so we can use it's score
                                frameScore += ScoreFromSymbol(gameFrames[1]);
                        }
                        else
                            /// this must be last frame so add the second bonus ball
                            frameScore += ScoreFromSymbol(bonusBalls[1]);

                        /// check again that we have enough buffer to avoid NPE when looking for the second next ball
                        if (i + 2 < totalGameFrames)
                            if (gameFrames[2] == symbols.Spare)
                                /// this is a spare so we need to make this frame up to 10
                                frameScore += 10 - ScoreFromSymbol(gameFrames[1]);

                            else if (gameFrames[2] == symbols.Boundary && gameFrames.Count > 3)
                                /// if the first next was a strike, we need to look on one more
                                frameScore += ScoreFromSymbol(gameFrames[3]);

                            else
                                /// this is a nonspecific next frame so we can use it's score
                                frameScore += ScoreFromSymbol(gameFrames[2]);
                        else
                            /// this must either be the last or the penultimate frame so we need the first bonus ball
                            frameScore += ScoreFromSymbol(bonusBalls[0]);
                    }
                    if (spare)
                    {
                        /// spares only look ahead 1 turn
                        if (i + 1 < totalGameFrames)
                        {
                            /// this is a nonspecific next frame so we can use it's score
                            frameScore += ScoreFromSymbol(gameFrames[1]);
                        }
                        else
                            /// this must be last frame so add the first (and only) bonus ball
                            frameScore += ScoreFromSymbol(bonusBalls[0]);
                    }
                    cumulativeScore += frameScore;
                }
            }
            return cumulativeScore;
        }

        /// <summary>
        /// Convert char from input string to a numerical score
        /// </summary>
        /// <param name="score">Score as char</param>
        /// <returns>Score as int</returns>
        private int ScoreFromSymbol(char score)
        {
            int result;
            /// output int if numeric, or 10 if a strike
            if (!int.TryParse(score.ToString(), out result))
                if (score == symbols.Strike) result = 10;
            return result;
        }
    }
}
