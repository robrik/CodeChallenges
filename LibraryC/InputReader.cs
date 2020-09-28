using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryC
{
    public class InputReader
    {
        public static IEnumerable<IEnumerable<string>> ReadInputForProblemC()
        {
            var strings = new List<IEnumerable<string>>();
            var testCases = int.Parse(Console.ReadLine());
            for(int a = 0; a < testCases; a++)
            {
                strings.Add(ReadOneTestCaseForProblemC());
              
            }
            return strings;
        }

        private static IEnumerable<string> ReadOneTestCaseForProblemC()
        {
            var mapHight = int.Parse(Console.ReadLine().Split(' ').Last());
            var strings = new List<string>();
            for (int a = 0; a < mapHight; a++)
            {
                strings.Add(Console.ReadLine());
            }
            return strings;
        }
    }
}
