using UnityEngine;

namespace View
{

    public class DrowBoard : MonoBehaviour
    {
        [SerializeField] RectTransform WhiteTails = null;
        [SerializeField] RectTransform BlackTails = null;

        internal Vector2[,] allPositions = new Vector2[8, 8];
        internal Vector2 SquareSize;
      
       
        internal void DrowGameBoard()
        {
            float tailsXPositon = -(Screen.width / 2f);
            float tailsYPositon = (Screen.width / 2f);

            float perS_Q_Size = (Screen.width / 8f);

            tailsXPositon += (perS_Q_Size / 2f);
            tailsYPositon -= (perS_Q_Size / 2f);

            SquareSize = new Vector2(perS_Q_Size, perS_Q_Size);

            bool IsWhiteTails = true;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    RectTransform getSquare = IsWhiteTails ? WhiteTails : BlackTails;

                    RectTransform square = Instantiate(getSquare, transform);
                    square.sizeDelta = SquareSize;
                    allPositions[row, col] = new Vector2(tailsXPositon + (perS_Q_Size * col), tailsYPositon - (perS_Q_Size * row));  //X,Y position record. 
                    square.transform.localPosition = allPositions[row, col];

                    IsWhiteTails = !IsWhiteTails;
                }
                IsWhiteTails = !IsWhiteTails;
            }
            
        }

      
    }

}