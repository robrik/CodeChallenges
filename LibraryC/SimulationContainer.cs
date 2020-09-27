using System.Collections.Generic;
using System.Linq;

namespace LibraryC
{
    public class SimulationContainer
    {

        private Godzilla Godzilla { get; set; }
        private List<Mech> Mechs { get; set; }
        private Map Map { get; set; }

        public SimulationContainer(char[][] rawMap)
        {
            Map = MapHelper.BuildMap(rawMap);
            Godzilla = CreateGodzilla(Map);
            Mechs = CreateMechs(Map, Godzilla);
        }

        private Godzilla CreateGodzilla(Map map)
        {
           var godzillPosition = map.GetPositionsForEntityType('G').First();
           return new Godzilla(godzillPosition, map);
        }
        
        private List<Mech> CreateMechs(Map map, Godzilla godzilla)
        {
            var mechPositions = map.GetPositionsForEntityType('M');
            var mechs = mechPositions.Select(position => new Mech(position, godzilla, map)).ToList();
            return mechs;
        }

        public int RunSimulation()
        {
            do
            {
                Godzilla.TryMove();

            } while (!Mechs.Any(x => x.TryKillGodzilla()));

            return Map.NumberOfDestoryedResidentialSectors;
        }
    }
}
