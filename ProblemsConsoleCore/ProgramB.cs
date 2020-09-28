
using LibraryB;
using System;
using System.Linq;

namespace ProblemsConsoleCore
{
    public class ProgramB
    {
        public static void Main(string[] args)
        {
            var input = InputReader.ReadInputForProblemB();
            var parsedInput = InputParser.ParseForProblemB(input);
            var result = ProblemB.ConvertInputForTestCases(parsedInput);
            result.ToList().ForEach(testCase =>
            {
                if (testCase.IsPossible)
                {
                    testCase.Map.ToList().ForEach(convertedLine => Console.WriteLine(new string(convertedLine)));
                }
                else
                {
                    Console.WriteLine("impossible");
                }
                Console.WriteLine("----------");
            });
        }
    }
}
