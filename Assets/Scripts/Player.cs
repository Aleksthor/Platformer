using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Main
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private bool hasStaff = false;


        public bool HasStaff()
        {
            return hasStaff;
        }

    }
}