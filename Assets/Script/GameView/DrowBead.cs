using System;
using UnityEngine;

namespace View
{
    public class DrowBead :MonoBehaviour
    {
        [SerializeField] private  BeadScript beadFeb = null;

        private Action<int> BeadInteractables = null;

        internal void DrowBeads(int[,] boardFormate,Vector2 SquareSize,Vector2[,]allPositions,Action<BeadScript>clickAction)
        {
            byte Empty = 0;
            int counter = -1;
            for (byte row = 0; row < 8; row++)
            {
                for (byte col = 0; col < 8; col++)
                {
                    counter++;
                    int valu = boardFormate[row, col];
                    if (valu==Empty)
                    {
                        continue;
                    }
                    BeadScript bead = Instantiate(beadFeb, transform);
                    bead.ChangeImg(valu);
                    bead.currentPos = counter;
                    bead.bead = valu;
                    bead.beadID = counter;
                    bead.SetOnClick(clickAction);
                    bead.GetComponent<RectTransform>().sizeDelta = SquareSize * 0.85f;
                    bead.transform.localPosition = allPositions[row, col];
                    BeadInteractables += bead.BtnActivation;
                    Viewdata.beadData.Add(bead);
                }
            }
        }
        internal void ActiveSite(int bead)
        {
            BeadInteractables?.Invoke(bead);
        }
    }
}

