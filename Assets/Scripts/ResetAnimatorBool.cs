using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimatorBool : StateMachineBehaviour
{

    public string isInteractingBool="isInteracting";
    public bool isInteractingStatus=false;

    public string isFiringSpellBool="isFiringSpell";
    public bool isFiringSpellStatus=false;

    public string canRotateBool="canRotate";
    public bool canRotateStatus=true;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(isInteractingBool,isInteractingStatus);
        animator.SetBool(isFiringSpellBool,isFiringSpellStatus);
        animator.SetBool(canRotateBool,canRotateStatus);
    }

}
