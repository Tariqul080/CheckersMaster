using System.Collections.Generic;
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
        internal static void CheakFM(int[,] Board, int[][] Cutpos, bool[,] kingBoard, int PlayerMove )
        {
            int counter = -1;
            List<int> forceMB = new List<int>();
            GameData.ForceCutBeadList.Clear();

            for (byte row = 0; row <8; row++)
            {
                for (byte col = 0; col < 8; col++)
                {
                    counter++;
                    int pointValu = Board[row, col];
                    if (pointValu == GameData.Empty || pointValu!=PlayerMove) continue;

                    if (pointValu==PlayerMove)
                    {
                        int[] BeadPosition = ArrayPoint(counter);
                        int beadRow = BeadPosition[0];
                        int beadColum = BeadPosition[1];
                        bool CheckKing = kingBoard[beadRow , beadColum];
                        int[] MoveCutPosIndex = Cutpos[counter];
                        for (int index = 0, leg = MoveCutPosIndex.Length; index < leg ; index++)
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

                            if (CutMovePosValu != GameData.Empty || cutBeadValu == GameData.Empty || cutBeadValu == PlayerMove) continue;
                            if (PlayerMove == GameData.TopBead)
                            {
                                if ( CheckKing == false)
                                {
                                    if (beadRow < CutMovePosRow)
                                    {
                                        forceMB.Add(counter);
                                    }
                                }
                                else
                                {
                                    forceMB.Add(counter);
                                }
                            }
                            else if (PlayerMove == GameData.BottomBead)
                            {
                                if (CheckKing == false)
                                {
                                    if (beadRow > CutMovePosRow)
                                    {
                                        forceMB.Add(counter);
                                    }
                                }
                                else
                                {
                                    forceMB.Add(counter);
                                }
                            }
                        }
                    }
                    continue;
                }
            }
            forceMB.Sort();
            if (forceMB.Count != GameData.Empty)
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
