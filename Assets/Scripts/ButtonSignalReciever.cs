using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Main
{
    public class ButtonSignalReciever : MonoBehaviour
    {
        private int numberOfButtons = 2;
        private int buttonsPressed = 0;

        public void SetNumberButtons(int num)
        {
            numberOfButtons = num;
        }

        public void ButtonPressed()
        {
            buttonsPressed++;
        }

        public int ButtonsPressed()
        {
            return buttonsPressed;
        }

        public bool AllButtonsPressed()
        {
            return numberOfButtons == buttonsPressed;
        }
    }
}
