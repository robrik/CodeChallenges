using System;
using System.Collections.Generic;

namespace LibraryA
{
    public class InputReader
    {
        public static IEnumerable<string> ReadInputForProblemA()
        {
            var strings = new List<string>();
            var linesToRead = int.Parse(Console.ReadLine());
            for (int a = 0; a < linesToRead; a++)
            {
                strings.Add(Console.ReadLine());
            }
            return strings;
        }
    }
}
