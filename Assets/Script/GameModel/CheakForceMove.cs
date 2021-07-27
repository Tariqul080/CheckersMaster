using System.Collections.Generic;
using View;
using UnityEngine;

    

namespace GameModel
{
    public class CheakForceMove
    {
        private static int[] ArrayPoint(int index)
        {
            int col = index % 8;
            int row = (index - col) / 8;
            int[] arr = new int[] { row, col };
            return arr;
        }

        private static int PointValu(int[] array, int[,] board)
        {
            int row = array[0];
            int col = array[1];
            int valu = board[row, col];
            return valu;
        }

          //update 27-7-21
        internal static void CheakFM(int[,] Board, int[][] Cutpos, List<BeadScript> allBeads, int top, int bottom, int PlayerMove )
        {
            BeadScript Bead = null;
            int counter = -1;
            int empty = 0;
            List<int> forceMB = new List<int>();
            GameData.ForceCutBeadList.Clear();

            for (byte row = 0; row <8; row++)
            {
                for (byte col = 0; col < 8; col++)
                {
                    counter++;
                    int pointValu = Board[row, col];
                    if (pointValu == empty || pointValu!=PlayerMove) continue;

                    if (pointValu==PlayerMove)
                    {
                        int[] BeadPosition = ArrayPoint(counter);
                        int beadRow = BeadPosition[0];
                        int beadColum = BeadPosition[1];
                        int[] MoveCutPosIndex = Cutpos[counter];
                        for (byte index = 0; index < MoveCutPosIndex.Length ; index++)
                        {
                            int CutMovePos = MoveCutPosIndex[index];
                            int[] CutMovePosArr=ArrayPoint(CutMovePos);
                            int CutMovePosRow = CutMovePosArr[0];
                            int CutMovePosColum = CutMovePosArr[1];
                            //cut bead valu...
                            int cutBeadRow = (beadRow + CutMovePosRow) / 2;
                            int cutBeadCol = (beadColum + CutMovePosColum) / 2;
                            int cutBeadValu = Board[cutBeadRow, cutBeadCol];
                            int CutMovePosValu = PointValu(CutMovePosArr, Board);
                            if (CutMovePosValu!=empty || cutBeadValu==empty || cutBeadValu==PlayerMove) continue;
                            for(int number = 0; number<allBeads.Count; number++)
                                {
                                    BeadScript beads = allBeads[number];
                                    if(beads.currentPos == counter)
                                    {
                                        Bead = beads;
                                    }
                                }
                            if (PlayerMove==top)
                            {
                                if ( Bead.isKing == false)
                                {
                                    if (beadRow < CutMovePosRow)
                                    {
                                        forceMB.Add(counter);
                                        Bead = null;
                                    }
                                }
                                else
                                {
                                    forceMB.Add(counter);
                                    Bead = null;
                                }
                            }
                            else if (PlayerMove == bottom)
                            {
                                if (Bead.isKing == false)
                                {
                                    if (beadRow > CutMovePosRow)
                                    {
                                        forceMB.Add(counter);
                                        Bead = null;
                                    }
                                }
                                else
                                {
                                    forceMB.Add(counter);
                                    Bead = null;
                                }
                            }
                        }
                    }
                    continue;
                }
            }
            forceMB.Sort();
            if (forceMB.Count != empty)
            {
                int ForcePoint = forceMB[0];
                GameData.ForceCutBeadList.Add(ForcePoint);
                for (byte i = 1; i < forceMB.Count; i++)
                {
                    int index = forceMB[i];
                    if (ForcePoint!= index)
                    {
                        GameData.ForceCutBeadList.Add(index);

                        ForcePoint = index;
                    }
                }
            }
        }
    }
}
