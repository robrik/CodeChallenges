using LibraryA;
using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace LibrartTest
{
    [TestFixture]
    public class ProblemATest
    {
        [Test]
        public void Solve_ShouldWork()
        {
            var list = new List<int[]>()
            {
                new int[] { 0, 100, 70 },
                new int[] { 100, 130, 30 },
                new int[] { -100, -70, 40 }
            };
       
            var target = new ProblemA();
            var result =  target.Solve(list).ToArray();

            result[0].Should().Be("advertise");
            result[1].Should().Be("does not matter");
            result[2].Should().Be("do not advertise");
        }
    }
}
