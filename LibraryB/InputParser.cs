using System.Collections.Generic;
using System.Linq;

namespace LibraryB
{
    public class InputParser
    {
        public static IEnumerable<char[][]> ParseForProblemB(IEnumerable<IEnumerable<string>> testCases)
        {
            return testCases.Select(map => map.Select(line => line.ToCharArray()).ToArray());      
        }
    }
}
