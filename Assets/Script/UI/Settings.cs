using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using View;

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
        [SerializeField] private GameObject GameViewModelSean = null;
        [Header("Falg")]
        [SerializeField] Sprite International = null;
        [SerializeField] Sprite Argentina = null;
        [SerializeField] Sprite Brazil = null;
        [SerializeField] Sprite Italy = null;
        [SerializeField] Sprite Spanish = null;
        [SerializeField] Sprite American = null;
        [SerializeField] Sprite Turkish = null;
        [SerializeField] Sprite britain = null;
        [SerializeField] Sprite Russian = null;
        [SerializeField] Sprite France = null;
        [SerializeField] Sprite Germany = null;
        [SerializeField] GameObject Falg = null;
        [SerializeField] Button FalgForward = null;
        [SerializeField] Button FalgBack = null;
        [SerializeField] Text GameRules = null;

        [SerializeField] Button KingRules = null;
        [SerializeField] Button MenRules = null;
        [SerializeField] Button Cancel = null;
        [SerializeField] GameObject UpdatePopUp  = null;




        internal int BoardCounter = 0;
        internal static int BeadCounter = 0;
        internal int FalgCounter = 0;

        private void Start()
        {
            KingRules.onClick.AddListener(delegate 
            {
                UpdatePopUp.SetActive(true);
                KingRules.interactable = false;
                MenRules.interactable = false;
                BackToMainMenu.interactable = false;
                ForwardBeadButton.interactable = false;
                BackBeadButton.interactable = false;
                ForwardBoardButton.interactable = false;
                BackBoardButton.interactable = false;
                FalgForward.interactable = false;
                FalgBack.interactable = false;
                
            });
            MenRules.onClick.AddListener(delegate
            {
                UpdatePopUp.SetActive(true);
                KingRules.interactable = false;
                MenRules.interactable = false;
                BackToMainMenu.interactable = false;
                ForwardBeadButton.interactable = false;
                BackBeadButton.interactable = false;
                ForwardBoardButton.interactable = false;
                BackBoardButton.interactable = false;
                FalgForward.interactable = false;
                FalgBack.interactable = false;

            });
            Cancel.onClick.AddListener(delegate
            {
                UpdatePopUp.SetActive(false);
                KingRules.interactable = true;
                MenRules.interactable = true;
                BackToMainMenu.interactable = true;
                ForwardBeadButton.interactable = true;
                BackBeadButton.interactable = true;
                ForwardBoardButton.interactable = true;
                BackBoardButton.interactable = true;
                FalgForward.interactable = true;
                FalgBack.interactable = true;

            });
            BoardImagePosition.GetComponent<Image>().sprite = GameBoard1;
            BeadImagePosition.GetComponent<Image>().sprite = BeadLight1;
            Falg.GetComponent<Image>().sprite = International;
            GameRules.text = "International";
            FalgForward.onClick.AddListener(delegate
            {
                FalgCounter++;
                switch (FalgCounter)
                {
                    case 1:
                        Falg.GetComponent<Image>().sprite = Argentina;
                        GameRules.text = "Argentina";
                        break;
                    case 2:
                        Falg.GetComponent<Image>().sprite = Brazil;
                        GameRules.text = "Brazil";
                        break;
                    case 3:
                        Falg.GetComponent<Image>().sprite = Italy;
                        GameRules.text = "Italy";
                        break;
                    case 4:
                        Falg.GetComponent<Image>().sprite = Spanish;
                        GameRules.text = "Spanish";
                        break;
                    case 5:
                        Falg.GetComponent<Image>().sprite = American;
                        GameRules.text = "American";
                        break;
                    case 6:
                        Falg.GetComponent<Image>().sprite = Turkish;
                        GameRules.text = "Turkish";
                        break;
                    case 7:
                        Falg.GetComponent<Image>().sprite = britain;
                        GameRules.text = "Britain";
                        break;
                    case 8:
                        Falg.GetComponent<Image>().sprite = Russian;
                        GameRules.text = "Russian";
                        break;
                    case 9:
                        Falg.GetComponent<Image>().sprite = France;
                        GameRules.text = "France";
                        break;
                    case 10:
                        Falg.GetComponent<Image>().sprite = Germany;
                        GameRules.text = "Germany";
                        break;
                    default:
                        Falg.GetComponent<Image>().sprite = International;
                        GameRules.text = "International";
                        FalgCounter = 0;
                        break;
                }
            });
            FalgBack.onClick.AddListener(delegate
            {
                FalgCounter--;
                if (FalgCounter<0)
                {
                    FalgCounter = 10;
                }
                switch (FalgCounter)
                {
                    case 1:
                        Falg.GetComponent<Image>().sprite = Argentina;
                        GameRules.text = "Argentina";
                        break;
                    case 2:
                        Falg.GetComponent<Image>().sprite = Brazil;
                        GameRules.text = "Brazil";
                        break;
                    case 3:
                        Falg.GetComponent<Image>().sprite = Italy;
                        GameRules.text = "Italy";
                        break;
                    case 4:
                        Falg.GetComponent<Image>().sprite = Spanish;
                        GameRules.text = "Spanish";
                        break;
                    case 5:
                        Falg.GetComponent<Image>().sprite = American;
                        GameRules.text = "American";
                        break;
                    case 6:
                        Falg.GetComponent<Image>().sprite = Turkish;
                        GameRules.text = "Turkish";
                        break;
                    case 7:
                        Falg.GetComponent<Image>().sprite = britain;
                        GameRules.text = "Britain";
                        break;
                    case 8:
                        Falg.GetComponent<Image>().sprite = Russian;
                        GameRules.text = "Russian";
                        break;
                    case 9:
                        Falg.GetComponent<Image>().sprite = France;
                        GameRules.text = "France";
                        break;
                    case 10:
                        Falg.GetComponent<Image>().sprite = Germany;
                        GameRules.text = "Germany";
                        break;
                    default:
                        Falg.GetComponent<Image>().sprite = International;
                        GameRules.text = "International";
                        FalgCounter = 0;
                        break;
                }
            });
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
                BoardCounter--;
                if (BoardCounter < 0) BoardCounter = 5;
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
                        View.BeadScript.BeadModelNumer = BeadCounter;
                        break;
                    case 2:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight3;
                        View.BeadScript.BeadModelNumer = BeadCounter;
                        break;
                    default:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight1;
                        BeadCounter = 0;
                        View.BeadScript.BeadModelNumer = BeadCounter;
                        break;
                }
               
            });
            BackBeadButton.onClick.AddListener(delegate
            {
                BeadCounter--;
                if (BeadCounter < 0) BeadCounter = 2;
                switch (BeadCounter)
                {
                    case 1:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight2;
                        View.BeadScript.BeadModelNumer = BeadCounter;
                        break;
                    case 2:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight3;
                        View.BeadScript.BeadModelNumer = BeadCounter;
                        break;
                    default:
                        BeadImagePosition.GetComponent<Image>().sprite = BeadLight1;
                        BeadCounter = 0;
                        View.BeadScript.BeadModelNumer = BeadCounter;
                        break;
                }
            });
            BackToMainMenu.onClick.AddListener(delegate
            {
                GameSetting.SetActive(false);
                MainMenu.SetActive(true);
            });

        }


    }
}
