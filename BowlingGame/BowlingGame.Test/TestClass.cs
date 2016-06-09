using BowlingGame.Classes;
using BowlingGame.Helpers;
using BowlingGame.Languages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Test
{
    [TestFixture]
    public class TestClass
    {
        public TestData testData { get; private set; }

        public TestClass()
        {
            testData = new TestData();
        }
                
        [TestCase(Description ="Validation check on sample 1 from the specification")]
        public void ValidationTest1()
        {
            var gameValidation = GetGameValidation();
            var result = gameValidation.ValidateInput(testData.Test1);
            Assert.AreEqual(true, result.Success);
        }

        [TestCase(Description = "Validation check on sample 2 from the specification")]
        public void ValidationTest2()
        {
            var gameValidation = GetGameValidation();
            var result = gameValidation.ValidateInput(testData.Test2);
            Assert.AreEqual(true, result.Success);
        }


        [TestCase(Description = "Validation check on sample 3 from the specification")]
        public void ValidationTest3()
        {
            var gameValidation = GetGameValidation();
            var result = gameValidation.ValidateInput(testData.Test3);
            Assert.AreEqual(true, result.Success);
        }

        [TestCase(Description = "Validation check on sample 4 from the specification")]
        public void ValidationTest4()
        {
            /// spec test4
            var gameValidation = GetGameValidation();
            var result = gameValidation.ValidateInput(testData.Test4);
            Assert.AreEqual(true, result.Success);
        }

        [TestCase(Description = "Validation check on too short data")]
        public void ValidationTest5()
        {
            var gameValidation = GetGameValidation();
            var result = gameValidation.ValidateInput(testData.Test5);
            Assert.AreEqual(false, result.Success);
        }

        [TestCase(Description = "Validation check on too long data")]
        public void ValidationTest6()
        {
            var gameValidation = GetGameValidation();
            var result = gameValidation.ValidateInput(testData.Test6);
            Assert.AreEqual(false, result.Success);
        }

        [TestCase(Description = "Validation check on data with unrecognised symbols")]
        public void ValidationTest7()
        {
            var gameValidation = GetGameValidation();
            var result = gameValidation.ValidateInput(testData.Test7);
            Assert.AreEqual(false, result.Success);
        }

        [TestCase(Description = "Validation check on multiple end markers")]
        public void ValidationTest8()
        {
            var gameValidation = GetGameValidation();
            var result = gameValidation.ValidateInput(testData.Test8);
            Assert.AreEqual(false, result.Success);
        }

        [TestCase(Description = "Validation check on no end markers")]
        public void ValidationTest9()
        {
            var gameValidation = GetGameValidation();
            var result = gameValidation.ValidateInput(testData.Test9);
            Assert.AreEqual(false, result.Success);
        }

        [TestCase(Description = "Score check on sample 1 from the specification")]
        public void ScoreTest1()
        {
            var scoringLogic = new ScoringLogic();
            var result = scoringLogic.GetResult(testData.Test1, new EnGB());
            Assert.AreEqual(300, result.Score);
        }

        [TestCase(Description = "Score check on sample 2 from the specification")]
        public void ScoreTest2()
        {
            var scoringLogic = new ScoringLogic();
            var result = scoringLogic.GetResult(testData.Test2, new EnGB());
            Assert.AreEqual(90, result.Score);
        }

        [TestCase(Description = "Score check on sample 3 from the specification")]
        public void ScoreTest3()
        {
            var scoringLogic = new ScoringLogic();
            var result = scoringLogic.GetResult(testData.Test3, new EnGB());
            Assert.AreEqual(150, result.Score);
        }

        [TestCase(Description = "Score check on sample 4 from the specification")]
        public void ScoreTest4()
        {
            var scoringLogic = new ScoringLogic();
            var result = scoringLogic.GetResult(testData.Test4, new EnGB());
            Assert.AreEqual(167, result.Score);
        }

        [TestCase(Description = "Score check on sample 4 with custom symbols")]
        public void ChangeSymbolTest1()
        {
            var scoringLogic = new ScoringLogic('#','~','!','?');
            var result = scoringLogic.GetResult(testData.Test10, new EnGB());
            Assert.AreEqual(167, result.Score);
        }

        [TestCase(Description = "Score check on sample 4 when symbols entered wrongly, only STRIKE should be '?'")]
        public void ChangeSymbolTest2()
        {
            var scoringLogic = new ScoringLogic('?', '?', '?', '?');
            var result = scoringLogic.GetResult(testData.Test11, new EnGB());
            Assert.AreEqual(167, result.Score);
        }

        private GameValidation GetGameValidation()
        {
            Symbols symbols = new Symbols();
            Language lang = new EnGB();
            return new GameValidation(symbols, lang);
        }

        public static void Main(string[] args) { }
    }
}
