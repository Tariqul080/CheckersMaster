using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameModel;
using View;

namespace GameModel
{
        public class GameAI : MonoBehaviour
    {
        private static Indecator Indeca =  new Indecator();
        private static DrowBoard DBoard  =  new DrowBoard();


        internal static int AiMove()
        {
            CheakForceMove.CheakFM(GameData.Board, GameData.CutPosition, GameData.kingBoard, GameData.Empty);
            Indeca.HighliteMoveables(GameData.ForceCutBeadList, GameData.Gotopos, GameData.Board, GameData.kingBoard, DBoard.allPositions, GameData.TopBead);
            List<int> AllowMoveBead = new List<int>();
            List<int> forceCutMove = new List<int>();
            AllowMoveBead.Clear();
            forceCutMove.Clear();
            AllowMoveBead = Viewdata.allowMoveBeads;
            forceCutMove = GameData.ForceCutBeadList;
            if(forceCutMove.Count != 0)
            {
                return forceCutMove[0];

            }
            return AllowMoveBead[0];

        }
        
    }

    
}
