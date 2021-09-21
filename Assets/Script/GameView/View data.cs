using System.Collections.Generic;

namespace View
{
    public static class Viewdata 
    {
        internal static List<BeadScript> beadData = new List<BeadScript>();
        internal static List<int> allowMoveBeads = new List<int>();
        internal static int Indecator = -1;
        internal static int playerMove = -1;
        internal const int TopBead = 1, BottomBead = 2, Empty = 0;
        internal static List<int> HighliteMoveable = new List<int>();
    }
}
