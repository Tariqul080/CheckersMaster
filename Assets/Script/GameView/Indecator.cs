using System.Collections.Generic;
using UnityEngine;
using System;

namespace View
{
    public class Indecator : MonoBehaviour
    {
        [SerializeField] private indecatorScript indFeb = null;
        [SerializeField] private Sprite cutInd = null;

        private indecatorScript[] HighliteIndicators = new indecatorScript[32];
        internal indecatorScript[] moveIndicators = new indecatorScript[4];
        internal void StoreHighliteIndicators(Vector2 Size, Action<indecatorScript> ClickAction)
        {
            for (byte i = 0; i < 36; i++)
            {
                indecatorScript indecator = Instantiate(indFeb, transform);
                indecator.GetComponent<RectTransform>().sizeDelta = Size * 0.85f;
                indecator.Active(false);
                if (i < 32)
                {
                    HighliteIndicators[i] = indecator;
                }
                else
                {
                    moveIndicators[i - 32] = indecator;
                    moveIndicators[i - 32].SetOnClick(ClickAction);
                }
            }
        }

        internal void HideHighliteIndicators()
        {
            for (byte i = 0; i < 32; i++)
            {
                HighliteIndicators[i].Active(false);
            }
        }

        internal void HideMoveIndicators()
        {
            for (byte i = 0; i < 4; i++)
            {
                moveIndicators[i].Active(false);
            }
        }

        //Cheaking Moveable Beads.
        internal void HighliteMoveables(List<int> cutableBead, int[][] movePos, int[,] gameBoard, bool[,] kingBoard, Vector2[,] allPoints, int player)
        {
            int counter = -1, indicatorCounter = 0, Empty = Viewdata.Empty;
            int indecatorValu = 0;
            Viewdata.HighliteMoveable.Clear();
            if (cutableBead.Count!=0)
            {
                for (int i = 0; i < cutableBead.Count; i++)
                {
                    int index = cutableBead[i];
                    int cut_colum = index % 8;
                    int cut_Row = (index - cut_colum) / 8;
                    HighliteIndicators[indicatorCounter].transform.localPosition = allPoints[cut_Row, cut_colum];
                    HighliteIndicators[indicatorCounter].Active(true);
                    HighliteIndicators[indicatorCounter].currentpos = (cut_Row * 8) + cut_colum;
                    Viewdata.allowMoveBeads.Add(index);
                    indicatorCounter++;
                }
            }
            else
            {
                for (int row = 0; row < 8; row++)
                {
                    for (int col = 0; col < 8; col++)
                    {
                        counter++;
                        int boardPosValu = gameBoard[row, col];
                        if (boardPosValu == Empty  || player != boardPosValu) continue;
                        int[] index = movePos[counter];
                        int BeadCol = counter % 8;
                        int BeadRow = (counter - BeadCol) / 8;
                        bool king = kingBoard[BeadRow , BeadCol];
                        for (int i = 0; i < index.Length; i++)
                        {
                            int indexValu = index[i];
                            int colum = indexValu % 8;
                            int Row = (indexValu - colum) / 8;
                            int valu = gameBoard[Row, colum];
                            if(valu == Empty && king == false && player == Viewdata.TopBead && BeadRow < Row)
                            {
                                indecatorValu++;
                            }
                            else if(king == true && player == Viewdata.TopBead && valu == Empty)
                            {
                                indecatorValu++;
                            }
                            else if(valu == Empty && king == false && player == Viewdata.BottomBead && BeadRow > Row)
                            {
                                indecatorValu++;
                            }
                            else if(king == true && player == Viewdata.BottomBead && valu == Empty )
                            {
                                indecatorValu++;
                            }
                        }
                        if (indecatorValu == Empty) continue;
                        HighliteIndicators[indicatorCounter].transform.localPosition = allPoints[row, col];
                        HighliteIndicators[indicatorCounter].Active(true);
                        HighliteIndicators[indicatorCounter].currentpos = (row * 8) + col;
                        Viewdata.HighliteMoveable.Add(counter);  //new adding 04-08-21.
                        indicatorCounter++;
                        indecatorValu = 0;
                    }
                }
            }
            Viewdata.playerMove = -1;
            Viewdata.Indecator = -1;
            Viewdata.playerMove = player;
            Viewdata.Indecator = indicatorCounter;
            
        }

        //Move Point Identify..
        internal void MoveAllowPos(int[][]movePos, int [,]gameBoard, bool [,] kingBoard, Vector2 Size, Vector2[,] allPoints, int beadCourrentPos)
        {
            int beadCol = beadCourrentPos % 8;
            int beadRow = (beadCourrentPos - beadCol) / 8;
            bool king = kingBoard[beadRow , beadCol];
            int beadValu = gameBoard[beadRow , beadCol]; 
            int[] MovePoint = movePos[beadCourrentPos];
            for (int i = 0, x = MovePoint.Length; i < x; i++)
            {
                if (i > 3) return;
                int positionID = MovePoint[i];
                int colum = positionID % 8;
                int Row = (positionID - colum) / 8;
                int valu = gameBoard[Row, colum];
                if (valu != 0) continue;
                if(beadValu == Viewdata.TopBead && king == false && beadRow < Row)
                {
                    moveIndicators[i].currentpos = positionID;
                    moveIndicators[i].Active(true);
                    moveIndicators[i].transform.localPosition = allPoints[Row, colum];
                }
                else if(beadValu == Viewdata.BottomBead && king == false && beadRow > Row)
                {
                    moveIndicators[i].currentpos = positionID;
                    moveIndicators[i].Active(true);
                    moveIndicators[i].transform.localPosition = allPoints[Row, colum];

                }
                if(king == false ) continue;
                moveIndicators[i].currentpos = positionID;
                moveIndicators[i].Active(true);
                moveIndicators[i].transform.localPosition = allPoints[Row, colum];
            }
        }
        //Move cut point Indicator..
        internal void cutMoveIndecator(List<int> cutBead, int [][]cutGoToPos, int[,] GameBoard, Vector2[,] allPoints, bool isking, int playerMove, int moveBeadCurPos)
        {
            int top = 1, bottom = 2, Empty = 0;
            for (int index = 0; index < cutBead.Count; index++)
            {
                int cutableBeadPos = cutBead[index];
                if(cutableBeadPos!=moveBeadCurPos)continue;
                int cutableBeadCol = cutableBeadPos % 8;
                int cutableBeadRow = (cutableBeadPos - cutableBeadCol)/8;
                int[] cutMovePosi = cutGoToPos[cutableBeadPos];
                for (int i = 0; i < cutMovePosi.Length; i++)
                {
                    int cutMovePos = cutMovePosi[i];
                    int movePosCol = cutMovePos % 8;
                    int movePosRow = (cutMovePos - movePosCol) / 8;
                    int movePointValu = GameBoard[movePosRow, movePosCol];
                    int cutPointRow = (cutableBeadRow + movePosRow) / 2;
                    int cutPointCol = (cutableBeadCol + movePosCol) / 2;
                    int cutPointValu = GameBoard[ cutPointRow , cutPointCol];
                    if (movePointValu != Empty || cutPointValu==0 || cutPointValu==playerMove) continue;
                    if (playerMove==top )
                    {
                        if (isking==false)
                        {
                            if (cutableBeadRow<movePosRow)
                            {
                                moveIndicators[i].currentpos = cutMovePos;
                                moveIndicators[i].Active(true);
                                moveIndicators[i].transform.localPosition = allPoints[movePosRow, movePosCol];
                            }
                        }
                        moveIndicators[i].currentpos = cutMovePos;
                        moveIndicators[i].Active(true);
                        moveIndicators[i].transform.localPosition = allPoints[movePosRow, movePosCol];
                    }
                    else if (playerMove == bottom)
                    {
                        if (isking == false)
                        {
                            if (cutableBeadRow > movePosRow)
                            {
                                moveIndicators[i].currentpos = cutMovePos;
                                moveIndicators[i].Active(true);
                                moveIndicators[i].transform.localPosition = allPoints[movePosRow, movePosCol];
                            }
                        }
                        moveIndicators[i].currentpos = cutMovePos;
                        moveIndicators[i].Active(true);
                        moveIndicators[i].transform.localPosition = allPoints[movePosRow, movePosCol];
                    }
                }
            }
        }
    }
}
