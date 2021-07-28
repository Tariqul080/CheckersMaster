using System.Collections;
using System.Collections.Generic;
using View;

namespace GameModel
{
    public class SetKing 
    {
        internal static bool IsPromoteKing(int bead, int row)
        {
            if (row == 0 || row == 7)
            {
                if (bead == GameData.TopBead && row == 7)
                {
                    return true;
                }
                if (bead == GameData.BottomBead && row == 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}