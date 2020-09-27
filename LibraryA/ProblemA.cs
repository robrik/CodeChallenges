using System.Collections.Generic;
using System.Linq;

namespace LibraryA
{
    public class ProblemA
    {
        public IEnumerable<string> Solve(IEnumerable<int[]> inputList)
        {
           return inputList.Select(x => AdvertiseDesition(AdvertiseCalculation(x)));
        }

        private int AdvertiseCalculation(int[] advNumbers)
        {
            var expectedRevenue = advNumbers[0];
            var expectedRevenueAdvertise = advNumbers[1];
            var advertiseCost = advNumbers[2];
            return expectedRevenue.CompareTo(expectedRevenueAdvertise - advertiseCost);
        }

        private string AdvertiseDesition(int result)
        {
            if(result == 0)
            {
                return "does not matter";
            }
            else if (result > 0)
            {
                return "do not advertise";
            }
            else if(result < 0 )
            {
                return "advertise";
            }
            else
            {
                return "error";
            }
        }
    }
}
