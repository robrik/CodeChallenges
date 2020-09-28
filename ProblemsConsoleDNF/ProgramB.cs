using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemsConsoleDNF.ProgramB
{
    public class ProgramB
    {
        public static void Main(string [] args)
        {
            var input = InputReader.ReadInputForProblemB();
            var parsedInput = InputParser.ParseForProblemB(input);
            var result = ProblemB.ConvertInputForTestCases(parsedInput);
            result.ToList().ForEach(x =>
            {
                if (x.IsPossible)
                {
                    x.Map.ToList().ForEach(y => {
                        foreach (char a in y)
                        {
                            Console.Write(a);
                        }
                        Console.WriteLine();                
                    });
                }
                else
                {
                    Console.WriteLine("impossible");
                }
                Console.WriteLine("----------");
            });
        }
    }
    public class Result
    {
        public bool IsPossible { get; set; }
        public char[][] Map { get; set; }
    }
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
            for (int r = 0; r < grid.Length; r++)
            {
                output[r] = new char[grid[0].Length];
                for (int c = 0; c < grid[0].Length; c++)
                {
                    output[r][c] = ConvertCharInGrid(grid, r, c);
                }
            }

            return new Result()
            {
                IsPossible = output.SelectMany(x => x).Count(k => k == 'E') == 0 && !output.SelectMany(x => x).All(x => x == 'N'),
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
            for (int r = 0; r < input.Length; r++)
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
    public class InputParser
    {
        public static IEnumerable<char[][]> ParseForProblemB(IEnumerable<IEnumerable<string>> testCases)
        {
            return testCases.Select(map => map.Select(line => line.ToCharArray()).ToArray());
        }
    }

}
