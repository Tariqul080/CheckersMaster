using System;
namespace GameModel
{
    public class NormalMove
    {
        internal static Action<int> PromoteKing = null; // int = Bead current position
        private static int[] ArrayPoint(int index)
        {
            int col = index % 8;
            int row = (index - col) / 8;
            int[] arr = new int[] { row, col };
            return arr;
        }
        internal static bool MoveBeadNormal(int[][] GotoPos, int[,] GameBoard, int from, int to)
        {
            int[] toPosition = ArrayPoint(to);
            int[] MovePos = GotoPos[from];
            int indexNumber = Array.IndexOf(MovePos, to);
            int toposValu = GameBoard[toPosition[0], toPosition[1]];
            int[] fromPosition = ArrayPoint(from);

            if (indexNumber != -1)
            {
                GameBoard[toPosition[0], toPosition[1]] = GameBoard[fromPosition[0], fromPosition[1]]; // move normal bead on Board Array
                GameBoard[fromPosition[0], fromPosition[1]] = 0;
                GameData.NormalM = true;

                // check king move
                if (GameData.kingBoard[fromPosition[0], fromPosition[1]]) // move King on king array
                {
                    GameData.kingBoard[fromPosition[0], fromPosition[1]] = false;
                    GameData.kingBoard[toPosition[0], toPosition[1]] = true;
                }
                else
                {
                    // check promote king
                    bool promoteKing = SetKing.IsPromoteKing(GameBoard[toPosition[0], toPosition[1]], toPosition[0]);
                    if (promoteKing) 
                    {
                        GameData.kingBoard[toPosition[0], toPosition[1]] = true; // backend King
                        PromoteKing?.Invoke(to);
                    }
                }
                return true;
            }
            return false;
        }
    }
}
