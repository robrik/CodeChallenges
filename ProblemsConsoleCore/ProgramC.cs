using System;
using System.Linq;
using LibraryC;

namespace Sigma
{
    public class ProgramC
    {
        static void Main(string[] args)
        {
            var problemCInput = InputReader.ReadInputForProblemC();
            var parsedInput = InputParser.ParseForProblemC(problemCInput);
            var ProblemC = new ProblemC();
            var list =  ProblemC.Simulate(parsedInput).ToList();
            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
