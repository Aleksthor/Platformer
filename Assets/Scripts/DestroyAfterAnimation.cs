using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Main
{
    public class DestroyAfterAnimation : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Destroy(animator.gameObject, stateInfo.length);
        }
    }
}