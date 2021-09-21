using UnityEngine;
using UnityEngine.UI;
using System;

namespace View 
{
    public class BeadScript : MonoBehaviour
    {
        [SerializeField] private Button BeadPrefeb = null;
        [SerializeField] private Sprite DarkBead1 = null;
        [SerializeField] private Sprite LightBead1 = null;
        [SerializeField] private Sprite DarkBead2 = null;
        [SerializeField] private Sprite LightBead2 = null;
        [SerializeField] private Sprite DarkBead3 = null;
        [SerializeField] private Sprite LightBead3 = null;
        [SerializeField] private Image KingImg = null;
        [SerializeField] private RectTransform rt = null;

        internal int currentPos= -1;
        internal int beadID = -1;
        internal int bead = -1;
        internal bool isKing = false;
        internal bool isAlive = true;

        internal static int BeadModelNumer = 0;
        internal RectTransform GetRt()
        {
            return rt;
        }

        internal void SetOnClick(Action<BeadScript> click)
        {
            BeadPrefeb.onClick.AddListener(delegate
            {
                click?.Invoke(this);
            });
        }

        internal void ChangeImg(int valu)
        {
            if (BeadModelNumer == 0)
            {
                if (valu == 1)
                {
                    BeadPrefeb.GetComponent<Image>().sprite = DarkBead1;
                }
                else if (valu == 2)
                {
                    BeadPrefeb.GetComponent<Image>().sprite = LightBead1;
                }
            }
            else if (BeadModelNumer == 1)
            {
                if (valu == 1)
                {
                    BeadPrefeb.GetComponent<Image>().sprite = DarkBead2;
                }
                else if (valu == 2)
                {
                    BeadPrefeb.GetComponent<Image>().sprite = LightBead2;
                }

            }
            else if (BeadModelNumer == 2)
            {
                if (valu == 1)
                {
                    BeadPrefeb.GetComponent<Image>().sprite = DarkBead3;
                }
                else if (valu == 2)
                {
                    BeadPrefeb.GetComponent<Image>().sprite = LightBead3;
                }
            }
        }
        internal void BtnActivation(int bead)
        {
            if (isAlive)
            {
                BeadPrefeb.interactable = this.bead == bead;
            }
        }
        internal void MakeItKing()
        {
            isKing = true;
            KingImg.enabled = true;
        }
    }
}
