using UnityEngine;
using View;
using GameModel;
using MyPhoton;
using Photon.Pun;
using UnityEngine.UI;
using Helper;

public class GameViewModel : MonoBehaviour
{
    [Header("Common Ref")]
    [SerializeField] private DrowBoard board = null;
    [SerializeField] private RectTransform boardTr = null;
    [SerializeField] private GameEnd result = null;
    [SerializeField] private DrowBead bead = null;
    [SerializeField] private Indecator ind = null;
    [SerializeField] private MovebeadScript moveBead = null;

    [Header("Photon Ref")]
    [SerializeField] private PhotonServer Server = null;
    [SerializeField] private PhotonView PView = null;
    [SerializeField] private Text PrintDebug = null;
    [SerializeField] private GameEntry gameStart = null;
    [SerializeField] private GameObject searchToplayer = null;
    [SerializeField] private GameObject gameBoard = null;


    internal bool isMultiplayer = false;
    private bool SendMultiplayerMoveToPhoton = false, IsItsMyMove = false, isMultiplayerWhite = false;

         
    private BeadScript selectedBead = null;
    private int currentPlayr = 2, cutPosition = -1;

    // Promote King
    private bool isPromoteKing = false;
    private int promoteKingPos = -1;
    public void ClickBead(BeadScript script)
    {
        if (GameData.ForceCutBeadList.Count > 0)
        {
            if (!GameData.ForceCutBeadList.Contains(script.currentPos))
            {
                return;
            }
            else
            {
                this.selectedBead = script;
                ind.HideMoveIndicators();
                ind.cutMoveIndecator(GameData.ForceCutBeadList, GameData.CutPosition, GameData.Board, board.allPositions, script.isKing, currentPlayr, selectedBead.currentPos);
                return;
            }
        }
        this.selectedBead = script;
        ind.HideMoveIndicators();
        ind.MoveAllowPos(GameData.Gotopos, GameData.Board, GameData.kingBoard, board.SquareSize, board.allPositions, script.currentPos); // normal move
    }
    public void ClickIndicator(indecatorScript script)
    {
        ind.HideMoveIndicators();
        ind.HideHighliteIndicators();

        if (isMultiplayer)
        {
            SendMultiplayerMoveToPhoton = true; // don't make it true another place
        }

        if(GameData.ForceCutBeadList.Count != 0)
        {
            cutPosition = CutMove.CutMoveBead(GameData.CutPosition, selectedBead.currentPos, script.currentpos, GameData.Board);
            if(cutPosition != -1) moveBead.MoveBead(selectedBead, script.currentpos, board.allPositions, true);
        }
        else
        {
            bool MoveLogic = NormalMove.MoveBeadNormal(GameData.Gotopos, GameData.Board, selectedBead.currentPos, script.currentpos);
            if (MoveLogic == true) moveBead.MoveBead(selectedBead, script.currentpos, board.allPositions);
        }
    }

    private void MoveByServerOrAI(int from, int to, bool isCutBead, BeadScript bead)
    {
        ind.HideMoveIndicators();
        ind.HideHighliteIndicators();

        if (isCutBead)
        {
            cutPosition = CutMove.CutMoveBead(GameData.CutPosition, from, to, GameData.Board);
            if (cutPosition != -1) moveBead.MoveBead(bead, to, board.allPositions, true);
        }
        else
        {
            bool MoveLogic = NormalMove.MoveBeadNormal(GameData.Gotopos, GameData.Board, from, to);
            if (MoveLogic == true) moveBead.MoveBead(bead, to, board.allPositions);
        }
    }

    private void RemoveCutBead()
    {
        if (cutPosition != -1)
        {
            for (int i = 0, len = Viewdata.beadData.Count; i < len; i++)
            {
                BeadScript item = Viewdata.beadData[i];
                if (item.isAlive == true && item.currentPos == cutPosition)
                {
                    item.isAlive = false;
                    item.gameObject.SetActive(false);
                }
            }
            cutPosition = -1;
        }
    }
    private void MoveStart(int from, int to, bool isCutMove)
    {
        if (isMultiplayer && SendMultiplayerMoveToPhoton)
        {
            SendMultiplayerMoveToPhoton = false;
            IsItsMyMove = true;
            SentDataToPhoton(from, to, isCutMove);
        }

        RemoveCutBead();
    }
    private void MoveComplete() // invoke after complete a move
    {
        if (!isPromoteKing)
        {
            int extraFM = CutExtraMove.ExtraMoveIndex(selectedBead.currentPos, GameData.CutPosition, GameData.kingBoard, GameData.Board);
            if(extraFM != -1 && GameData.NormalM == false)
            {
                GameData.ForceCutBeadList.Clear();
                GameData.ForceCutBeadList.Add(extraFM);
                MultiPlayerMoveableBeadIndecatorAndNormal();
                return;
            }
        }
        
        currentPlayr = currentPlayr == 2 ? 1 : 2;
        ActiveSaide();
        CheakForceMove.CheakFM(GameData.Board, GameData.CutPosition, GameData.kingBoard, currentPlayr);
        //new add.
        MultiPlayerMoveableBeadIndecatorAndNormal();
       
        GameData.NormalM = false;
        result.Result(Viewdata.Indecator , Viewdata.playerMove);
        
        // promote king
        if (isPromoteKing)
        {
            isPromoteKing = false;
            for (int i = 0, len = Viewdata.beadData.Count; i < len; i++)
            {
                BeadScript script = Viewdata.beadData[i];
                if (script.isAlive && script.currentPos == promoteKingPos)
                {
                    script.MakeItKing(); // make king on UI
                }
            }
        }
    }
    private void PromoteKing(int kingPosition)
    {
        isPromoteKing = true;
        promoteKingPos = kingPosition;
    }

    #region Multiplayer
    private void ReadyToGoMultiplayerGame(bool isMasterClient)
    {
        isMultiplayerWhite = isMasterClient;
        searchToplayer.SetActive(false);
        gameBoard.SetActive(true);

        if (isMultiplayer && !isMultiplayerWhite)
        {
            boardTr.Rotate180Deg();

            // rotate beads | fast
            for (int i = 0, len = Viewdata.beadData.Count; i < len; i++)
            {
                Viewdata.beadData[i].GetRt().RotateAsParent(boardTr);
            }
        }
    }

    private void SentDataToPhoton(int from, int to, bool isCutMove)
    {
        Server.sendData(PView, from, to, isCutMove);
    }

    private void DataFromPhotonServer(int moveFrom, int moveTo, bool isCutMove)
    {
        if (IsItsMyMove)
        {
            IsItsMyMove = false;
            return;
        }

        // make move
        this.selectedBead = null;
        for (int i = 0, len = Viewdata.beadData.Count; i < len; i++)
        {
            if (Viewdata.beadData[i].isAlive && Viewdata.beadData[i].currentPos == moveFrom)
            {
                this.selectedBead = Viewdata.beadData[i];
                break;
            }
        }

        if (this.selectedBead != null) // WARNING: if it found null multiplayer will broken now. 
        {
            // must be update backend. or you can paly only one move properly.
            //moveBead.MoveBead(multiplyaerScript, moveTo, board.allPositions);

            MoveByServerOrAI(moveFrom, moveTo, isCutMove, this.selectedBead);
        }
    }
    private void OnConnected()
    {
        Server.Connect();
    }
    private void Debuge(string sms)
    {
        if (PrintDebug != null && PrintDebug.gameObject.activeInHierarchy)
            PrintDebug.text += sms + "\n";
    }

    #endregion

    private void MultiPlayerMoveableBeadIndecatorAndNormal()
    {
        if (isMultiplayer)
        {
            if (isMultiplayerWhite && currentPlayr == 2)
            {
                ind.HighliteMoveables(GameData.ForceCutBeadList, GameData.Gotopos, GameData.Board, GameData.kingBoard, board.allPositions, currentPlayr);
            }
            else if (!isMultiplayerWhite && currentPlayr == 1)
            {
                ind.HighliteMoveables(GameData.ForceCutBeadList, GameData.Gotopos, GameData.Board, GameData.kingBoard, board.allPositions, currentPlayr);
            }
        }
        else
        {
            ind.HighliteMoveables(GameData.ForceCutBeadList, GameData.Gotopos, GameData.Board, GameData.kingBoard, board.allPositions, currentPlayr);
        }
    }

    private void ActiveSaide()
    {
        if (isMultiplayer)
        {
            if (isMultiplayerWhite && currentPlayr == 2)
            {
                bead.ActiveSite(currentPlayr);
            }
            else if (!isMultiplayerWhite && currentPlayr != 2)
            {
                bead.ActiveSite(currentPlayr);
            }
        }
        else
        {
            bead.ActiveSite(currentPlayr);
        }
    }

    private void StartGame(bool isMultiplayer)
    {
        this.isMultiplayer = isMultiplayer;
        ActiveSaide();
        MultiPlayerMoveableBeadIndecatorAndNormal();

        if (!isMultiplayer && boardTr.rotation.z != 0)
        {
            if (boardTr.rotation.z != 0)
            {
                boardTr.Rotate0Deg();
            }

            //using foreach loop | too slow
            //foreach (var item in Viewdata.beadData)
            //    {
            //        item.GetRt().Rotate0Deg();
            //    }
            for (int i = 0, len = Viewdata.beadData.Count; i < len; i++)
            {
                Viewdata.beadData[i].GetRt().RotateAsParent(boardTr);
            }
        }
    }

    void Start()
    {
        moveBead.MoveStart += MoveStart;
        moveBead.MoveComplete += MoveComplete;
        NormalMove.PromoteKing += PromoteKing;
        board.DrowGameBoard();
        ind.StoreHighliteIndicators(board.SquareSize, ClickIndicator);

        bead.DrowBeads(GameData.Board, board.SquareSize, board.allPositions, ClickBead);
        // active site
        // add multiplayer methods
        Server.IsReadyToGO += ReadyToGoMultiplayerGame;
        Server.DataFromPhoton += DataFromPhotonServer;
        Server.DebugText += Debuge;
        gameStart.OnMatching += OnConnected;
        gameStart.StartGame += StartGame;
    }
    private void OnDisable()
    {
        moveBead.MoveStart -= MoveStart;
        moveBead.MoveComplete -= MoveComplete;
        NormalMove.PromoteKing -= PromoteKing;
        Server.IsReadyToGO -= ReadyToGoMultiplayerGame;
        Server.DataFromPhoton -= DataFromPhotonServer;
        Server.DebugText -= Debuge;
        gameStart.OnMatching -= OnConnected;
        gameStart.StartGame -= StartGame;
    }

    
}
