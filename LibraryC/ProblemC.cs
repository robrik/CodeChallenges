using System.Collections.Generic;
using System.Linq;

namespace LibraryC
{
    public class ProblemC
    {
        public IEnumerable<int> Simulate(IEnumerable<char[][]> testCases)
        {
            var simCon = testCases.Select(x => new SimulationContainer(x));
            var list = simCon.Select(sim => sim.RunSimulation());
            return list;
        }
    }
}
