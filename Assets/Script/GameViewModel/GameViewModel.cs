using UnityEngine;
using View;
using GameModel;

public class GameViewModel : MonoBehaviour
{
    [SerializeField] private DrowBoard board = null;
    [SerializeField] private DrowBead bead = null;
    [SerializeField] private Indecator ind = null;
    [SerializeField] private MovebeadScript moveBead = null;

    private BeadScript selectedBead = null;
    private int currentPlayr = 2, cutPosition = -1;

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
        ind.MoveAllowPos(GameData.Gotopos, GameData.Board, board.SquareSize, board.allPositions, script.currentPos); // normal move
       
    }

    public void ClickIndicator(indecatorScript script)
    {
        ind.HideMoveIndicators();
        ind.HideHighliteIndicators();
        if(GameData.ForceCutBeadList.Count != 0)
        {
            cutPosition = CutMove.CutMoveBead(GameData.CutPosition, selectedBead.currentPos, script.currentpos, GameData.Board);
            if(cutPosition != -1) moveBead.MoveBead(selectedBead, script.currentpos, board.allPositions);
        }
        else
        {
             bool MoveLogic = NormalMove.MoveBeadNormal(GameData.Gotopos, GameData.Board, selectedBead.currentPos, script.currentpos);
             if (MoveLogic == true) moveBead.MoveBead(selectedBead, script.currentpos, board.allPositions);
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

    private void MoveMiddle()
    {
        RemoveCutBead();
    }

    private void MoveComplete() // invoke after complete a move
    {
        // remove cut bead
        //RemoveCutBead();
       // SetKing.SetBeadKing(GameData.Board, 1, Viewdata.beadData);
        currentPlayr = currentPlayr == 2 ? 1 : 2;
        bead.ActiveSite(currentPlayr);
        CheakForceMove.CheakFM(GameData.Board, GameData.CutPosition, Viewdata.beadData, 1, 2, currentPlayr);
        ind.HighliteMoveables(GameData.ForceCutBeadList, GameData.Gotopos, GameData.Board, 0, board.allPositions, currentPlayr);
        SetKing.SetBeadKing(GameData.Board, 1, Viewdata.beadData);
    }

    void Start()
    {
        moveBead.MoveStart += MoveMiddle;
        moveBead.MoveComplete += MoveComplete;

        board.DrowGameBoard();
        ind.StoreHighliteIndicators(board.SquareSize, ClickIndicator);
        ind.HighliteMoveables(GameData.ForceCutBeadList, GameData.Gotopos, GameData.Board, 0, board.allPositions, currentPlayr);
        bead.DrowBeads(GameData.Board, board.SquareSize, board.allPositions, ClickBead);
        // active site
        bead.ActiveSite(currentPlayr);
    }
   
    private void OnDisable()
    {
        moveBead.MoveStart -= MoveMiddle;
        moveBead.MoveComplete -= MoveComplete;
    }
}
