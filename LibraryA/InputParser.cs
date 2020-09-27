using System.Collections.Generic;
using System.Linq;

namespace LibraryA
{
    public class InputParser
    {
        public static IEnumerable<int[]> ParseForProblemA(IEnumerable<string> advertisementNumberLines)
        {
            return advertisementNumberLines.Select(advLine =>
                advLine.Split(" ").Select(advValue => int.Parse(advValue)).ToArray());
        }

        public static IEnumerable<char[][]> ParseForProblemC(IEnumerable<IEnumerable<string>> testCases)
        {
            return testCases.Select(map => map.Select(line => line.ToCharArray()).ToArray());      
        }
    }
}
