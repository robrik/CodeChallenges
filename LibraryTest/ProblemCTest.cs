using FluentAssertions;
using LibraryC;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTest
{
    [TestFixture]
    public class ProblemCTest
    {
        [Test]
        [Repeat(100)]
        public void Simulate_ShouldWork()
        {
            var map3x3 = new List<string>(){ { "RR." }, { "G.." }, { "M.R" } };
            var map7x5 = new List<string>() { { "M...RR." }, { "...G..." }, { "...RRR." }, { "......." }, { "..RR..M" } };

            var testCases = new List<IEnumerable<string>>()
            {
                map3x3,
                map7x5
            };

            var testCasesParsed = InputParser.ParseForProblemC(testCases);
            var target = new ProblemC();
            var result = target.Simulate(testCasesParsed).ToArray();

            result[0].Should().Be(1);
            result[1].Should().Be(2);
        }
    }
}
