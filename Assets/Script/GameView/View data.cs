using System.Collections.Generic;

namespace View
{
    public static class Viewdata 
    {
        internal static List<BeadScript> beadData = new List<BeadScript>();
        internal static List<int> allowMoveBeads = new List<int>();

        internal const int TopBead = 1, BottomBead = 2, Empty = 0;
    }
}
