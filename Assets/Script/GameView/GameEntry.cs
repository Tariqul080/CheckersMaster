using UnityEngine;
using UnityEngine.UI;
using System;

namespace View
{
    public class GameEntry : MonoBehaviour
    {
        [SerializeField] private Button PlayerVsPlayer = null;
        [SerializeField] private Button OnlinePlay = null;
        [SerializeField] private Button PlayWithComputer = null;
        [SerializeField] private GameObject GameBoard = null;
        [SerializeField] private GameObject Lobby = null;
        [SerializeField] private GameObject ConnectToServer = null;
        [SerializeField] private Button JoinToServer = null;
        [SerializeField] private GameObject PlayGameBackground = null;
        [SerializeField] private GameObject GameBackground = null;
        [SerializeField] private Button Settings = null;
        [SerializeField] private GameObject SettingMode = null;
        [SerializeField] private GameObject LobbyMode = null;
        [SerializeField] private Button GoldCoin = null;
        [SerializeField] private Button Thunder = null;
        [SerializeField] private Button Tresure = null;
        [SerializeField] private Button statastic = null;
        [SerializeField] private Button surprise = null;
        [SerializeField] private Button shop = null;
        [SerializeField] private GameObject UpdatePopup = null;
        [SerializeField] private Button Cancel = null;



        internal Action OnMatching = null;
        internal Action<bool> StartGame = null;
        internal Action LeaveToServer = null;
        internal Action BoardAndBeadSetting = null;

        private void Start()
        {
            GoldCoin.onClick.AddListener(delegate
            {
                UpdatePopup.SetActive(true);
                GoldCoin.interactable = false;
                Thunder.interactable = false;
                Tresure.interactable = false;
                statastic.interactable = false;
                surprise.interactable = false;
                shop.interactable = false;
                Settings.interactable = false;
                PlayerVsPlayer.interactable = false;
                OnlinePlay.interactable = false;
                PlayWithComputer.interactable = false;
            });

            Thunder.onClick.AddListener(delegate
            {
                UpdatePopup.SetActive(true);
                GoldCoin.interactable = false;
                Thunder.interactable = false;
                Tresure.interactable = false;
                statastic.interactable = false;
                surprise.interactable = false;
                shop.interactable = false;
                Settings.interactable = false;
                PlayerVsPlayer.interactable = false;
                OnlinePlay.interactable = false;
                PlayWithComputer.interactable = false;
            });

            Tresure.onClick.AddListener(delegate
            {
                UpdatePopup.SetActive(true);
                GoldCoin.interactable = false;
                Thunder.interactable = false;
                Tresure.interactable = false;
                statastic.interactable = false;
                surprise.interactable = false;
                shop.interactable = false;
                Settings.interactable = false;
                PlayerVsPlayer.interactable = false;
                OnlinePlay.interactable = false;
                PlayWithComputer.interactable = false;
            });
            PlayWithComputer.onClick.AddListener(delegate
            {
                UpdatePopup.SetActive(true);
                GoldCoin.interactable = false;
                Thunder.interactable = false;
                Tresure.interactable = false;
                statastic.interactable = false;
                surprise.interactable = false;
                shop.interactable = false;
                Settings.interactable = false;
                PlayerVsPlayer.interactable = false;
                OnlinePlay.interactable = false;
                PlayWithComputer.interactable = false;
            });
            statastic.onClick.AddListener(delegate
            {
                UpdatePopup.SetActive(true);
                GoldCoin.interactable = false;
                Thunder.interactable = false;
                Tresure.interactable = false;
                statastic.interactable = false;
                surprise.interactable = false;
                shop.interactable = false;
                Settings.interactable = false;
                PlayerVsPlayer.interactable = false;
                OnlinePlay.interactable = false;
                PlayWithComputer.interactable = false;
            });
            surprise.onClick.AddListener(delegate
            {
                UpdatePopup.SetActive(true);
                GoldCoin.interactable = false;
                Thunder.interactable = false;
                Tresure.interactable = false;
                statastic.interactable = false;
                surprise.interactable = false;
                shop.interactable = false;
                Settings.interactable = false;
                PlayerVsPlayer.interactable = false;
                OnlinePlay.interactable = false;
                PlayWithComputer.interactable = false;
            });
            shop.onClick.AddListener(delegate
            {
                UpdatePopup.SetActive(true);
                GoldCoin.interactable = false;
                Thunder.interactable = false;
                Tresure.interactable = false;
                statastic.interactable = false;
                surprise.interactable = false;
                shop.interactable = false;
                Settings.interactable = false;
                PlayerVsPlayer.interactable = false;
                OnlinePlay.interactable = false;
                PlayWithComputer.interactable = false;
            });
            Cancel.onClick.AddListener(delegate
            {
                UpdatePopup.SetActive(false);
                GoldCoin.interactable = true;
                Thunder.interactable = true;
                Tresure.interactable = true;
                statastic.interactable = true;
                surprise.interactable = true;
                shop.interactable = true;
                Settings.interactable = true;
                PlayerVsPlayer.interactable = true;
                OnlinePlay.interactable = true;
                PlayWithComputer.interactable = true;
            });

            PlayerVsPlayer.onClick.AddListener(delegate
            {
                StartGame?.Invoke(false);
                BoardAndBeadSetting?.Invoke();
                GameBackground.SetActive(false);
                PlayGameBackground.SetActive(true);
                GameBoard.SetActive(true);
                Lobby.SetActive(false);
            });

            OnlinePlay.onClick.AddListener(delegate
            {
                StartGame?.Invoke(true);
                BoardAndBeadSetting?.Invoke();
                GameBackground.SetActive(false);
                PlayGameBackground.SetActive(true);
                ConnectToServer.SetActive(true);
                Lobby.SetActive(false);
            });

            JoinToServer.onClick.AddListener(delegate
            {
                JoinToServer.interactable=false;
                BoardAndBeadSetting?.Invoke();
                OnMatching?.Invoke();
            });
            Settings.onClick.AddListener(delegate
            {
                LobbyMode.SetActive(false);
                SettingMode.SetActive(true);
            });

        }
       



    }


}
