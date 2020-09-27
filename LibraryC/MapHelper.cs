using System.Collections.Generic;

namespace LibraryC
{
    public class MapHelper
    {
        public static Map BuildMap(char[][] rawMap)
        {
            var simpleMap = new Dictionary<string,(Position, char)>();
            for(int outer = 0; outer < rawMap.Length; outer++)
            {
                for (int inner = 0; inner < rawMap[0].Length; inner++)
                { 
                    var position = new Position(inner, outer);
                    simpleMap.Add(position.ToString(), (position, rawMap[outer][inner]));
                }

            }
            var map = new Map(simpleMap, rawMap.Length, rawMap[0].Length);
            return map;
        }
    }
}
