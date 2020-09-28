using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryB
{
    public class InputReader
    {
        public static IEnumerable<IEnumerable<string>> ReadInputForProblemB()
        {
            var strings = new List<IEnumerable<string>>();
            var testCases = int.Parse(Console.ReadLine());
            for (int a = 0; a < testCases; a++)
            {
                strings.Add(ReadOneTestCaseForProblemB());

            }
            return strings;
        }

        private static IEnumerable<string> ReadOneTestCaseForProblemB()
        {
            var mapHight = int.Parse(Console.ReadLine().Split(' ').First());
            var strings = new List<string>();
            for (int a = 0; a < mapHight; a++)
            {
                strings.Add(Console.ReadLine());
            }
            return strings;
        }
    }
}
