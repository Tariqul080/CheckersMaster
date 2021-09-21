using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace View
{
     public class GameEnd : MonoBehaviour
    {
        [SerializeField] private  GameObject Trophy = null;
        [SerializeField] private  GameObject Congra =  null;
        [SerializeField] private  GameObject TopPlayer = null;
        [SerializeField] private  GameObject Bottom = null;
        [SerializeField] private  GameObject Board = null;
        [SerializeField] private  Transform TrophyTrans = null;
        [SerializeField] private  Transform CongraTrans = null;
        [SerializeField] private  Transform ResultTrans = null;

        internal  void Result(int MoveAbleBead, int playerMove)
        {
            float x = 0.3f;

            if(playerMove == Viewdata.TopBead && MoveAbleBead == 0 )
            {
                Board.SetActive(false);

                Trophy.transform.DOLocalMove( TrophyTrans.localPosition , x).OnComplete(()=>
                {
                Congra.transform.DOLocalMove(CongraTrans.localPosition , x).OnComplete(()=>
                    {
                        Bottom.transform.DOLocalMove(ResultTrans.localPosition, x);

                    }); 
                });
               
            }
            else if(playerMove == Viewdata.BottomBead && MoveAbleBead == 0)
            {
                 Board.SetActive(false);

                Trophy.transform.DOLocalMove( TrophyTrans.localPosition , x).OnComplete(()=>
                {
                    Congra.transform.DOLocalMove(CongraTrans.localPosition , x).OnComplete(()=>
                    {
                        TopPlayer.transform.DOLocalMove(ResultTrans.localPosition, x);

                    }); 

                });
            }
        }



        
    }

    
}
