using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Main
{
    public class RespawnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Movement>().Respawn();
            }
        }
    }
}