using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager : AnimatorManager
{

    EnemyManager enemyManager;
    EnemyStats enemyStats;
    private void Awake() {
        anim=GetComponent<Animator>();
        enemyManager=GetComponentInParent<EnemyManager>();
        enemyStats =GetComponentInParent<EnemyStats>();
    }

    public override void TakeCriticalDamageAnimationEvent()
    {
        enemyStats.TakeDamageNoAnimation(enemyManager.pendingCriticalDamage);
        enemyManager.pendingCriticalDamage=0;
    }

    public void PlayTargetAnimationEnemy2(string targetAnim, bool isInteracting)
    {
        anim.applyRootMotion = isInteracting;
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnim, 0.2f);
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
        enemyManager.isParrying=false;
    }

     public void EnableIsParrying(){
        enemyManager.isParrying=true;
    }

    public void DisableCanBeRiposted(){
        enemyManager.canBeRiposted=false;
    }
    public void EnableCanBeRiposted(){
        enemyManager.canBeRiposted=true;
    }
    private void OnAnimatorMove() {
        float delta=Time.deltaTime;
        enemyManager.enemyRigidbody.drag=0;
        Vector3 deltaPosition=anim.deltaPosition;
        deltaPosition.y=0;
        Vector3 velocity=deltaPosition/delta;
        enemyManager.enemyRigidbody.velocity=velocity;
    }
}
