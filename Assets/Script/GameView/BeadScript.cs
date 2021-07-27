using UnityEngine;
using UnityEngine.UI;
using System;
namespace View 
{
    public class BeadScript : MonoBehaviour
    {
        [SerializeField] private Button BeadPrefeb = null;
        [SerializeField] private Sprite DarkBead = null;
        [SerializeField] private Sprite LightBead = null;

        internal int currentPos= -1;
        internal int beadID = -1;
        internal int bead = -1;
        internal bool isKing = false;
        internal bool isAlive = true;

        internal void SetOnClick(Action<BeadScript> click)
        {
            BeadPrefeb.onClick.AddListener(delegate
            {
                click?.Invoke(this);
            });
        }

        internal void ChangeImg(int valu)
        {
            if (valu==1)
            {
                BeadPrefeb.GetComponent<Image>().sprite = DarkBead;
            }
            else if (valu==2)
            {
                BeadPrefeb.GetComponent<Image>().sprite = LightBead;
            }
        }

        internal void BtnActivation(int bead)
        {
            if (isAlive)
            {
                BeadPrefeb.interactable = this.bead == bead;
            }
        }
    }
}
