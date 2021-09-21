using UnityEngine;
using UnityEngine.UI;

namespace View
{

    public class DrowBoard : MonoBehaviour
    {
        [SerializeField] RectTransform WhiteTails = null;
        [SerializeField] RectTransform BlackTails = null;

        [Header("MultyBoard...")]
        [SerializeField] Sprite BoardTailsDark1 = null;
        [SerializeField] Sprite BoardTailsLight1 = null;
        [SerializeField] Sprite BoardTailsDark2 = null;
        [SerializeField] Sprite BoardTailsLight2 = null;
        [SerializeField] Sprite BoardTailsDark3 = null;
        [SerializeField] Sprite BoardTailsLight3 = null;
        [SerializeField] Sprite BoardTailsDark4 = null;
        [SerializeField] Sprite BoardTailsLight4 = null;
        [SerializeField] Sprite BoardTailsDark5 = null;
        [SerializeField] Sprite BoardTailsLight5 = null;
        [SerializeField] Sprite BoardTailsDark6 = null;
        [SerializeField] Sprite BoardTailsLight6 = null;


        internal Vector2[,] allPositions = new Vector2[8, 8];
        internal Vector2 SquareSize;

        internal void DrowGameBoard(int bordNumber)
        {

            
            
            switch (bordNumber)
            {
                case 0:
                    WhiteTails.GetComponent<Image>().sprite = BoardTailsLight1;
                    BlackTails.GetComponent<Image>().sprite = BoardTailsDark1;
                    break;
                case 1:
                    WhiteTails.GetComponent<Image>().sprite = BoardTailsLight2;
                    BlackTails.GetComponent<Image>().sprite = BoardTailsDark2;
                    break;
                case 2:
                    WhiteTails.GetComponent<Image>().sprite = BoardTailsLight3;
                    BlackTails.GetComponent<Image>().sprite = BoardTailsDark3;
                    break;
                case 3:
                    WhiteTails.GetComponent<Image>().sprite = BoardTailsLight4;
                    BlackTails.GetComponent<Image>().sprite = BoardTailsDark4;
                    break;
                case 4:
                    WhiteTails.GetComponent<Image>().sprite = BoardTailsLight5;
                    BlackTails.GetComponent<Image>().sprite = BoardTailsDark5;
                    break;
                case 5:
                    WhiteTails.GetComponent<Image>().sprite = BoardTailsLight6;
                    BlackTails.GetComponent<Image>().sprite = BoardTailsDark6;
                    break;
                    
            }
            
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