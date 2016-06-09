using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Helpers
{
    /// <summary>
    /// Basic tests from original specification, plus some extras for validation checks
    /// </summary>
    public class TestData
    {
        /// valid
        private string test1 = "X|X|X|X|X|X|X|X|X|X||XX";
        private string test2 = "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||";
        private string test3 = "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5";
        private string test4 = "X|7/|9-|X|-8|8/|-6|X|X|X||81";
        
        /// invalid
        private string test5 = "X|7X|X||81";
        private string test6 = "X|7|X|X|X|7|X|X|X|7|X|X|7|X|X|X|7|X|X|X|7|X|X|7|X|X|X|7|X|X|X|7|X|X||81";
        private string test7 = "X|X|X|X|X|X|?|X|X|X||XX";
        private string test8 = "X|X|X|X|X|X|X||X|X|X||XX";
        private string test9 = "X|X|X|X|X|X|X|X|X|X|X|X|X";
        private string test10 = "#?7~?9!?#?!8?8~?!6?#?#?#??81";
        private string test11 = "?|7/|9-|?|-8|8/|-6|?|?|?||81";

        public string Test1 { get { return test1; } }
        public string Test2 { get { return test2; } }
        public string Test3 { get { return test3; } }
        public string Test4 { get { return test4; } }
        public string Test5 { get { return test5; } }
        public string Test6 { get { return test6; } }
        public string Test7 { get { return test7; } }
        public string Test8 { get { return test8; } }
        public string Test9 { get { return test9; } }
        public string Test10 { get { return test10; } }
        public string Test11 { get { return test11; } }

        public string[] AllTests { get { return new string[] { test1, test2, test3, test4 }; } }
    }
}
