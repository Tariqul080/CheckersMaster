using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameModel
{
    public class CutExtraMove : MonoBehaviour
    {
        internal static int ExtraMoveIndex(int SbeadCurrentPos, int[][] cutMove, bool[,] king, int[,] GameBoard)
        {
            int beadCol = SbeadCurrentPos % 8;
            int beadRow = (SbeadCurrentPos - beadCol) / 8;
            int beadValu = GameBoard[beadRow , beadCol];
            bool isking = king[beadRow , beadCol];
            int [] index = cutMove[SbeadCurrentPos];
            for(int i = 0, len = index.Length; i < len; i++)
            {
                int posValu = index[i];
                int movePosCol = posValu % 8;
                int movePosRow = (posValu - movePosCol) / 8;
                int movePosValu = GameBoard[movePosRow , movePosCol];

                int cutPoitRow = (beadRow + movePosRow ) / 2 ;
                int cutPointCol = (beadCol + movePosCol ) / 2;
                int cutPosValu = GameBoard[cutPoitRow , cutPointCol];

                if( beadValu == cutPosValu || cutPosValu ==  GameData.Empty || movePosValu != GameData.Empty) continue;

                if(isking == false && beadValu == GameData.TopBead && beadRow < movePosRow)
                {
                    return SbeadCurrentPos ;
                }
                else if(isking == false && beadValu == GameData.BottomBead && beadRow > movePosRow) 
                {
                    return SbeadCurrentPos ;
                }
                else if(isking == true)
                {
                    return SbeadCurrentPos ;
                }
            } 
            return -1;
        }
    }
}
