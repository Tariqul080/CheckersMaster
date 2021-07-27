using UnityEngine;
using DG.Tweening;
using System;

namespace View
{
    public class MovebeadScript : MonoBehaviour
    {
        [SerializeField] private BeadScript bead = null;
        internal Action MoveStart = null, MoveMiddle = null, MoveComplete = null;
        
        private const float moveTime = 0.3f;
       

        internal void MoveBead(BeadScript bead, int to, Vector2[,] allPosition)
        {
            MoveStart?.Invoke();
            
            if (MoveMiddle != null) Invoke(nameof(MoveMiddle.Invoke), (moveTime / 2f));

            bead.transform.DOLocalMove(allPosition[to / 8, to % 8], moveTime).OnComplete(() => 
            {
                bead.currentPos = to;
                MoveComplete?.Invoke();
            });
        }
    }

}
