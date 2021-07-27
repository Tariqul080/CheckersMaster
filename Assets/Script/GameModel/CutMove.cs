using System;

namespace GameModel
{
    public class CutMove
    {
        private static int[] ArrayPoint(int index)
        {
            int col = index % 8;
            int row = (index - col) / 8;
            int[] arr = new int[] { row, col };
            return arr;
        }

        private static int PositionToRC(int row, int col)
        {
            return (row * 8) + col;
        }

        internal static  int CutMoveBead(int[][]cutGoPos, int from, int to, int[,] GameBoard) // -1 for failed to cut
        {
            int[] GoMovePos = cutGoPos[from];
            int[] fromArrPos = ArrayPoint(from);
            int[] toArrpos = ArrayPoint(to);
            if (Array.IndexOf(GoMovePos, to) == -1) return -1;
            int cutBeadRow = (fromArrPos[0] + toArrpos[0]) / 2;
            int cutBeadCol = (fromArrPos[1] + toArrpos[1]) / 2;
            int valu = GameBoard[cutBeadRow, cutBeadCol];
            if (valu!=0)
            {
                GameBoard[toArrpos[0], toArrpos[1]] = GameBoard[fromArrPos[0], fromArrPos[1]]; // normal bead move on backend
                GameBoard[fromArrPos[0], fromArrPos[1]] = 0;
                GameBoard[cutBeadRow, cutBeadCol] = 0;

                // check king move
                if (GameData.kingBoard[fromArrPos[0], fromArrPos[1]])  // king move on backend
                {
                    GameData.kingBoard[fromArrPos[0], fromArrPos[1]] = false;
                    GameData.kingBoard[toArrpos[0], toArrpos[1]] = true;
                }
                else
                {
                    // check promote king
                    bool promoteKing = SetKing.IsPromoteKing(GameBoard[toArrpos[0], toArrpos[1]], toArrpos[0]);
                    if (promoteKing)
                    {
                        GameData.kingBoard[toArrpos[0], toArrpos[1]] = true; // backend king
                        NormalMove.PromoteKing?.Invoke(to);
                    } 
                }

                return PositionToRC(cutBeadRow, cutBeadCol);
            }
            return -1;
        }
    }

}
