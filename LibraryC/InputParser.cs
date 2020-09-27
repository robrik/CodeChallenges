using System.Collections.Generic;
using System.Linq;

namespace LibraryC
{
    public class InputParser
    {
        public static IEnumerable<char[][]> ParseForProblemC(IEnumerable<IEnumerable<string>> testCases)
        {
            return testCases.Select(map => map.Select(line => line.ToCharArray()).ToArray());      
        }
    }
}
