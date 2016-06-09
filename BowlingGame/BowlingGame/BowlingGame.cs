using BowlingGame.Classes;
using BowlingGame.Helpers;
using BowlingGame.Languages;
using System;

namespace BowlingGame
{
    class BowlingGame
    {
        private static ScoringLogic logic;
        private static Language lang;

        static void Main(string[] args)
        {
            logic = new ScoringLogic();
            lang = new EnGB();
            while (true) { MainMenu(); }
        }

        private static void MainMenu()
        {
            /// defaults to en-GB
            Console.Clear();
            Console.WriteLine("1. " + lang.MENU_EnterScorecard);
            Console.WriteLine("2. " + lang.MENU_UsePresets);
            Console.WriteLine("3. " + lang.MENU_Language);

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    EnterScoreCard(null);
                    break;
                case "2":
                    RunTests();
                    break;
                case "3":
                    ChangeLanguage();
                    break;
                default: break;
            }
        }

        private static void ChangeLanguage()
        {
            /// switch the language from the helper file
            for (int i = 0; i < lang.AvailableLanguages.Length; i++)
            {
                Console.WriteLine(i+1 +". "+lang.AvailableLanguages[i].TITLE);
            }
            var input = Console.ReadLine();
            int inputAsInt;
            if (int.TryParse(input, out inputAsInt) && lang.AvailableLanguages.Length >= inputAsInt && inputAsInt > 0)
                lang = lang.AvailableLanguages[inputAsInt - 1];
            MainMenu();
        }

        private static void RunTests()
        {
            Console.Clear();

            var specificationTest = new TestData();
            
            Console.WriteLine("1. " + specificationTest.Test1);
            Console.WriteLine("2. " + specificationTest.Test2);
            Console.WriteLine("3. " + specificationTest.Test3);
            Console.WriteLine("4. " + specificationTest.Test4);
            Console.WriteLine("9. " + lang.MENU_AllPresets);
            Console.WriteLine("0. " + lang.MENU_Back);

            var input = Console.ReadLine();

            switch (input)
            {
                case "1": EnterScoreCard(specificationTest.Test1); break;
                case "2": EnterScoreCard(specificationTest.Test2); break;
                case "3": EnterScoreCard(specificationTest.Test3); break;
                case "4": EnterScoreCard(specificationTest.Test4); break;
                case "9":
                    foreach (var test in specificationTest.AllTests)
                    {
                        EnterScoreCard(test);
                    }
                    break;
                case "0": MainMenu(); break;
                default: break;
            }

        }

        private static void EnterScoreCard(string card)
        {
            var input = card;
            if (string.IsNullOrEmpty(card))
            {
                Console.WriteLine(lang.MENU_EnterScorecardNumber+":");
                input = Console.ReadLine();
            }
            else
                Console.WriteLine(card);
            var result = logic.GetResult(input, lang);
            if (result.Success) Console.WriteLine(result.Score); 
            Console.WriteLine(result.Message);
            Console.WriteLine(lang.MENU_Continue);
            Console.ReadLine();
        }
    }
}
