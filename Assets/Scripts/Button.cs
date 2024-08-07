using Codice.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Main
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private ButtonSignalReciever signalReciever;

        bool isPressed = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !isPressed)
            {
                isPressed = true;
                signalReciever.ButtonPressed();
                transform.Find("InActive").gameObject.SetActive(false);
            }
        }
    }
}