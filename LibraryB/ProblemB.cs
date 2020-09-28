using System.Collections.Generic;
using System.Linq;

namespace LibraryB
{
    public class ProblemB
    {
        public static IEnumerable<Result> ConvertInputForTestCases(IEnumerable<char[][]> testCases)
        {
            var kka = testCases.Select(x => ConvertForOneScreenGrid(x));
            return kka;
        }

        private static Result ConvertForOneScreenGrid(char[][] grid)
        {
            var output = new char[grid.Length][];
            for(int r = 0; r < grid.Length; r++)
            {
                output[r] = new char[grid[0].Length];
                for(int c = 0; c < grid[0].Length; c++)
                {
                    output[r][c] = ConvertCharInGrid(grid, r, c);
                }
            }

            return new Result()
            {
                IsPossible = output.SelectMany(x => x).Count(k => k == 'E') == 0,
                Map = output
            };
        }

        private static char ConvertCharInGrid(char[][] input, int r, int c)
        {
            if (input[r][c] == '0')
                return 'N';

            var hasInputOnRow = HasInputInRow(input[r]);
            var hasInputOnCol = HasInputInCol(input, c);

            if (hasInputOnCol && hasInputOnRow)
            {
                return 'I';
            }
            else if (!hasInputOnCol && hasInputOnRow)
            {
                return 'P';
            }
            else
            {
                return 'E';
            }
        }

        private static bool HasInputInCol(char[][] input, int c)
        {
            var count = 0;
            for(int r = 0; r < input.Length; r++)
            {
                if (input[r][c] == '1')
                    count++;
            }
            return count > 1;
        }

        private static bool HasInputInRow(char[] input)
        {
            return input.Count(x => x == '1') > 1;
        }
    }
}
