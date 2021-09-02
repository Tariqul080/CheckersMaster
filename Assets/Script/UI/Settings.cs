using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace settings
{
    public class Settings : MonoBehaviour
    {
        [Header("Board Ref")]
        [SerializeField] Sprite GameBoard1 = null;
        [SerializeField] Sprite GameBoard2 = null;
        [SerializeField] Sprite GameBoard3 = null;
        [SerializeField] Sprite GameBoard4 = null;
        [SerializeField] Sprite GameBoard5 = null;
        [SerializeField] Sprite GameBoard6 = null;
        [SerializeField] GameObject BoardImagePosition = null;
        [SerializeField] Button ForwardBoardButton = null;
        [SerializeField] Button BackBoardButton = null;
        [Header("Bead Ref")]
        [SerializeField] Sprite BeadLight1 = null;
        [SerializeField] Sprite BeadLight2 = null;
        [SerializeField] Sprite BeadLight3 = null;
        [SerializeField] GameObject BeadImagePosition = null;
        [SerializeField] Button ForwardBeadButton = null;
        [SerializeField] Button BackBeadButton = null;
        [Header("Back Menu Ref")]
        [SerializeField] Button BackToMainMenu = null;
        [SerializeField] GameObject MainMenu = null;
        [SerializeField] GameObject GameSetting = null;

        private int BoardCounter = 0;
        private int BeadCounter = 0;

        private void Start()
        {
            BoardImagePosition.GetComponent<Image>().sprite = GameBoard1;
            BeadImagePosition.GetComponent<Image>().sprite = BeadLight1;
            ForwardBoardButton.onClick.AddListener(delegate
            {
                BoardCounter++;
                switch (BoardCounter)
                {
                    case 1:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard2;
                        break;
                    case 2:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard3;
                        break;
                    case 3:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard4;
                        break;
                    case 4:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard5;
                        break;
                    case 5:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard6;
                        break;
                    default:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard1;
                        BoardCounter = 0;
                        break;
                }

            });
            BackBoardButton.onClick.AddListener(delegate
            {
                if (BoardCounter == 0) return;
                BoardCounter--;
                switch (BoardCounter)
                {
                    case 1:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard2;
                        break;
                    case 2:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard3;
                        break;
                    case 3:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard4;
                        break;
                    case 4:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard5;
                        break;
                    case 5:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard6;
                        break;
                    default:
                        BoardImagePosition.GetComponent<Image>().sprite = GameBoard1;
                        BoardCounter = 0;
                        break;
                }

            });
            ForwardBeadButton.onClick.AddListener(delegate
            {
                BeadCounter++;
                switch (BeadCounter)
                {
                    case 1:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight2;
                        break;
                    case 2:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight3;
                        break;
                    default:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight1;
                        BeadCounter = 0;
                        break;
                }
            });
            BackBeadButton.onClick.AddListener(delegate
            {
                if (BeadCounter == 0) return;
                BeadCounter--;
                switch (BeadCounter)
                {
                    case 1:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight2;
                        break;
                    case 2:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight3;
                        break;
                    default:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight1;
                        BeadCounter = 0;
                        break;
                }
            });
            BackToMainMenu.onClick.AddListener(delegate
            {
                BeadCounter = 0;
                BoardCounter = 0;
                GameSetting.SetActive(false);
                MainMenu.SetActive(true);
            });

        }


    }
}
