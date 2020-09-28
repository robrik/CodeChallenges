using FluentAssertions;
using LibraryB;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTest
{
    [TestFixture]
    public class ProblemBTest
    {
        [Test]
        public void Something_ShouldWork()
        {
            var map3x3 = new List<string>()  { "10", "01" };
            var testCases = new List<IEnumerable<string>>()
            {
                map3x3,
            };
            var parsedInput = InputParser.ParseForProblemB(testCases);
            var results = ProblemB.ConvertInputForTestCases(parsedInput).ToList();
            results.FirstOrDefault().IsPossible.Should().BeFalse();
        }

        [Test]
        public void Something_ShouldWork1()
        {
            var map3x3 = new List<string>() { "101", "000" };
            var testCases = new List<IEnumerable<string>>()
            {
                map3x3,
            };
            var parsedInput = InputParser.ParseForProblemB(testCases);
            var results = ProblemB.ConvertInputForTestCases(parsedInput).ToList();
            results.FirstOrDefault().Map.SelectMany(x => x).Should().BeEquivalentTo("PNPNNN".ToCharArray());
        }

        [Test]
        public void Something_ShouldWork3()
        {
            var map3x3 = new List<string>() { "110", "000", "110", "000" };
            var testCases = new List<IEnumerable<string>>()
            {
                map3x3,
            };
            var parsedInput = InputParser.ParseForProblemB(testCases);
            var results = ProblemB.ConvertInputForTestCases(parsedInput).ToList();
            results.FirstOrDefault().Map.SelectMany(x => x).Should().BeEquivalentTo("IINNNNIINNNN".ToCharArray());
        }
    }
}
