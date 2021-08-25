using UnityEngine;
using Photon.Pun;
using System;
using Photon.Realtime;

namespace MyPhoton
{
    public class PhotonServer : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject PhotonServers = null;
        private const int MaxPlayrerPerRoom = 2;
        private bool isConnected = false;
        internal string version = "1";

        internal Action<string> DebugText = null;
        internal Action<bool> IsReadyToGO = null;
        internal Action<int, int, bool> DataFromPhoton = null; // moveFrom, moveTo, isCutMove
        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        internal void Connect()
        {
            isConnected = true;
            if (PhotonNetwork.IsConnected)
            {
                DebugText?.Invoke("<Color=Green>Already Connected.Try to join randoom player</Color>");
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = version;
                DebugText?.Invoke("<Color=Green>Connecting to Photon server</Color>");
            }
        }

        internal void LeaveRoom()
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.LeaveRoom();
            }
        }

        internal void LeveToPhoton()
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.LeaveLobby();
                PhotonNetwork.Disconnect();
            }
        }

        //override Mathod all;
        public override void OnConnectedToMaster()
        {
            DebugText?.Invoke("<Color=Green>Successfully connected to server </Color>");
            if (isConnected)
            {
                DebugText?.Invoke("<Color=Green>Try again to join random room  </Color>");
                PhotonNetwork.JoinRandomRoom();
            }
        }
        public override void OnJoinedRoom()
        {
            DebugText?.Invoke("<Color=Green>Join room successfully done!.Total Playr in Room ="+PhotonNetwork.CurrentRoom.PlayerCount+"</Color>");
            if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayrerPerRoom)
            {
                IsReadyToGO?.Invoke(PhotonNetwork.IsMasterClient);
            }
            //IsReadyToGO?.Invoke(PhotonNetwork.IsMasterClient);
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            DebugText?.Invoke("<Color=Red>Join random Room Failed.</Color> Trying to Create a new Room");
            PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = MaxPlayrerPerRoom });
        }
        // Not Work start .......
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            DebugText?.Invoke("<Color=Green>Player Enter Room.IsMasterClient = " + PhotonNetwork.IsMasterClient + "Other Playrer Name = " + newPlayer);
            if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayrerPerRoom)
            {
                IsReadyToGO?.Invoke(PhotonNetwork.IsMasterClient);
            }
        }
        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            DebugText?.Invoke("<Color=Red>Player left room.</Color>. IsMasterClient = " + PhotonNetwork.IsMasterClient + " | NickName = " + otherPlayer.NickName);
        }
        public override void OnLeftRoom()
        {
            DebugText?.Invoke("<Color=Red>On Left Room</Color>");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            isConnected = false;
            DebugText?.Invoke("Disconnected fron photon server");
        }


        [PunRPC] private void SendDataFromPhotonToOthers(int from , int to, bool isCutMove)
        {
            DataFromPhoton?.Invoke(from, to, isCutMove);
        }

        internal void sendData(PhotonView view, int from , int to, bool isCutMove)
        {
            view.RPC("SendDataFromPhotonToOthers", RpcTarget.All, from, to, isCutMove);
        }


    }


}
