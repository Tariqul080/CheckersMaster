using System.Collections;
using System.Collections.Generic;
using View;

namespace GameModel
{
    public class SetKing 
    {
        private static int[] ArrayPoint(int index)
        {
            int col = index % 8;
            int row = (index - col) / 8;
            int[] arr = new int[] { row, col };
            return arr;
        }

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

        // internal static void SetBeadKing(int [,] gameBoard, int top, List<BeadScript> allbead)
        // {
        //     int counter =-1;
        //     for(int row = 0; row < 8; row++)
        //     {
        //         for(int col = 0; col < 8; col++)
        //         {
        //             counter++;
        //             int valu = gameBoard[row , col];
        //             if(valu == 0)continue;
        //             int[] arry = ArrayPoint(counter);
        //             int correntRow = arry[0];
        //             BeadScript bead = allbead[counter];
        //             if(valu == top)
        //             {
        //                 if(correntRow == 7)
        //                 {
        //                     bead.isKing = true;
        //                 }
        //                 continue;
        //             }
        //             else
        //             {
        //                 if(correntRow==0)
        //                 {
        //                     bead.isKing = true;
        //                 }
        //                 continue;
        //             }
        //         }
        //     }
        // }
    }
}