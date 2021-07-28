using UnityEngine;
using System;
using UnityEngine.UI;

namespace View
{

    public class indecatorScript : MonoBehaviour
    {
        [SerializeField] private indecatorScript indeFeb = null;
        [SerializeField] private Button IndecatorFeb = null;
        [SerializeField] private Image Img = null;

        internal int currentpos = -1;
        private bool isActive = false;

        internal void SetOnClick(Action<indecatorScript> click)
        {
            IndecatorFeb.onClick.AddListener(delegate
            {
                click?.Invoke(this);
            });
        }
        internal void Active(bool isActive)
        {
            IndecatorFeb.interactable = isActive;
            Img.enabled = isActive;
        }
    }
}

