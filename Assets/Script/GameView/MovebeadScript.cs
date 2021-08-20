using UnityEngine;
using DG.Tweening;
using System;

namespace View
{
    public class MovebeadScript : MonoBehaviour
    {
        [SerializeField] private BeadScript bead = null;
        internal Action MoveComplete = null;
        internal Action<int, int, bool> MoveStart = null; // from, to, isCutMove


        private const float moveTime = 0.3f;


        internal void MoveBead(BeadScript bead, int to, Vector2[,] allPosition, bool isCutMove = false)
        {
            MoveStart?.Invoke(bead.currentPos, to, isCutMove); // these data need for multiplayer

            bead.transform.DOLocalMove(allPosition[to / 8, to % 8], moveTime).OnComplete(() => 
            {
                bead.currentPos = to;
                MoveComplete?.Invoke();
            });
        }
    }

}
