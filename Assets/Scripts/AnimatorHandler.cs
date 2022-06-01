using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler : AnimatorManager
{
    public InputHandler inputHandler;
    public PlayerMovement playerMovement;
    public PlayerManager playerManager;
    public PlayerStats playerStats;
    int vertical;
    int horizontal;
    

    public void Initialize()
    {
        anim = GetComponent<Animator>();
        inputHandler=GetComponentInParent<InputHandler>();
        playerManager=GetComponentInParent<PlayerManager>();
        playerMovement=GetComponentInParent<PlayerMovement>();
        playerStats=GetComponentInParent<PlayerStats>();
        vertical = Animator.StringToHash("Vertical");
        horizontal = Animator.StringToHash("Horizontal");
    }

    public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement,bool isSprinting)
    {

        #region  vertical
        float v = 0;
        if (verticalMovement > 0 && verticalMovement < 0.55f)
        {
            v = 0.5f;
        }
        else if (verticalMovement > 0.55f)
        {
            v = 1;
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
        {
            v = -0.5f;
        }
        else if (verticalMovement < -0.55f)
        {
            v = -1;
        }
        else
        {
            v = 0;
        }
        #endregion

        #region  horizontal
        float h = 0;
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            h = 0.5f;
        }
        else if (horizontalMovement > 0.55f)
        {
            h = 1;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            h = -0.5f;
        }
        else if (horizontalMovement < -0.55f)
        {
            h = -1;
        }
        else
        {
            h = 0;
        }
        #endregion


        if(isSprinting){
            v=2;
            h=horizontalMovement;
        }
        anim.SetFloat(vertical,v,0.1f,Time.deltaTime);
        anim.SetFloat(horizontal,h,0.1f,Time.deltaTime);
    }


    
    public void CanRotate(){
        anim.SetBool("canRotate",true);
    }
    public void StopRotation(){
        anim.SetBool("canRotate",false);
    }

    public void EnableCombo(){
        anim.SetBool("canDoCombo",true);
    }

    public void DisableCombo(){
        anim.SetBool("canDoCombo",false);
    }

    public void EnableIsInvulnerable(){
        anim.SetBool("isInvulnerable",true);
    }

    public void DisableIsInvulnerable(){
        anim.SetBool("isInvulnerable",false);
    }

    public void DisableIsParrying(){
        playerManager.isParrying=false;
    }

     public void EnableIsParrying(){
        playerManager.isParrying=true;
    }

    public void DisableCanBeRiposted(){
        playerManager.canBeRiposted=false;
    }
    public void EnableCanBeRiposted(){
        playerManager.canBeRiposted=true;
    }


    public override void TakeCriticalDamageAnimationEvent()
    {
        playerStats.TakeDamageNoAnimation(playerManager.pendingCriticalDamage);
        playerManager.pendingCriticalDamage=0;
    }

    private void OnAnimatorMove() {
           if(playerManager.isInteracting==false)
            return;

        float delta=Time.deltaTime;
        playerMovement.rigidbody.drag=0;
        Vector3 deltaPosition=anim.deltaPosition;
        deltaPosition.y=0;
        Vector3 velocity=deltaPosition/delta;
        playerMovement.rigidbody.velocity=velocity;
    }
}


