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

        internal Action OnMatching = null;

        private void Start()
        {
            PlayerVsPlayer.onClick.AddListener(delegate
            {
                GameViewModel.isMultiplayer = false;
                GameBoard.SetActive(true);
                Lobby.SetActive(false);
            });

            OnlinePlay.onClick.AddListener(delegate
            {
                GameViewModel.isMultiplayer = true;
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
