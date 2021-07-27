using System;

namespace GameModel
{
    public class NormalMove
    {
        private static int[] ArrayPoint(int index)
        {
            int col = index % 8;
            int row = (index - col) / 8;
            int[] arr = new int[] { row, col };
            return arr;
        }
        internal static bool MoveBeadNormal(int[][] GotoPos,int[,] GameBoard,int from,int to)
        {
            int[] toPosition = ArrayPoint(to);
            int[] MovePos = GotoPos[from];
            int indexNumber = Array.IndexOf(MovePos, to);
            int toposValu = GameBoard[toPosition[0], toPosition[1]];
            int[] fromPosition = ArrayPoint(from);
            int fromPosValu = GameBoard[fromPosition[0], fromPosition[1]];

            if (indexNumber!=-1)
            {
                GameBoard[toPosition[0], toPosition[1]] = fromPosValu;
                GameBoard[fromPosition[0], fromPosition[1]] = toposValu;
                return true;
            }
            return false;
        }
    }


}
