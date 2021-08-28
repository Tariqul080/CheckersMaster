using UnityEngine;
using UnityEngine.UI;
using System;

namespace View
{
    public class GameEntry : MonoBehaviour
    {
        [SerializeField] private Button PlayerVsPlayer = null;
        [SerializeField] private Button OnlinePlay = null;
        [SerializeField] private GameObject GameBoard = null;
        [SerializeField] private GameObject Lobby = null;
        [SerializeField] private GameObject ConnectToServer = null;
        [SerializeField] private Button JoinToServer = null;
        [SerializeField] private GameObject PlayGameBackground = null;
        [SerializeField] private GameObject GameBackground = null;

        internal Action OnMatching = null;
        internal Action<bool> StartGame = null;
        internal Action LeaveToServer = null;

        private void Start()
        {
            PlayerVsPlayer.onClick.AddListener(delegate
            {
                StartGame?.Invoke(false);
                GameBackground.SetActive(false);
                PlayGameBackground.SetActive(true);
                GameBoard.SetActive(true);
                Lobby.SetActive(false);
            });

            OnlinePlay.onClick.AddListener(delegate
            {
                StartGame?.Invoke(true);
                GameBackground.SetActive(false);
                PlayGameBackground.SetActive(true);
                ConnectToServer.SetActive(true);
                Lobby.SetActive(false);
            });

            JoinToServer.onClick.AddListener(delegate
            {
                JoinToServer.interactable=false;
                OnMatching?.Invoke();
            });

        }
       



    }


}
