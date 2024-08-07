using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Main
{
    public class Door : MonoBehaviour
    {
        public int numberOfButtons = 2;

        [SerializeField] private List<Sprite> TwoDoorSprite = new List<Sprite>();
        [SerializeField] private List<Sprite> ThreeDoorSprite = new List<Sprite>();

        private ButtonSignalReciever reciever;
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider;

        private void Awake()
        {
            reciever = GetComponent<ButtonSignalReciever>();
            reciever.SetNumberButtons(numberOfButtons);
            spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            boxCollider = GetComponent<BoxCollider2D>();

            switch (numberOfButtons)
            {
                case 2:
                    spriteRenderer.sprite = TwoDoorSprite[0];
                    break;
                case 3:
                    spriteRenderer.sprite = ThreeDoorSprite[0];
                    break;
                default: 
                    break;

            }
        }

        private void Update()
        {
            switch (numberOfButtons)
            {
                case 2:
                    spriteRenderer.sprite = TwoDoorSprite[reciever.ButtonsPressed()];
                    break;
                case 3:
                    spriteRenderer.sprite = ThreeDoorSprite[reciever.ButtonsPressed()];
                    break;
                default:
                    break;
            }

            boxCollider.enabled = !reciever.AllButtonsPressed();
        }
    }
}
