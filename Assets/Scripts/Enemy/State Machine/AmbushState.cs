using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushState : State
{
    public bool isSleeping;
    public float detectionRadius = 5f;
    public string sleepAnimation;
    public string wakeAnimation;
    public LayerMask detectionLayer;
    public FollowTargetState followTargetState;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        if (isSleeping && enemyManager.isInteracting == false)
        {
            enemyAnimatorManager.PlayTargetAnimationEnemy2(sleepAnimation, true);
        }

        #region  detection
        Collider[] colliders = Physics.OverlapSphere(enemyManager.transform.position, detectionRadius, detectionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats character = colliders[i].transform.GetComponent<CharacterStats>();
            if (character != null)
            {
                Vector3 targetDirectiom = character.transform.position - enemyManager.transform.position;
                float distanceFromTarget= Vector3.Distance(character.transform.position,enemyManager.transform.position);
                float viewableAngle = Vector3.Angle(targetDirectiom, transform.forward);

                if (viewableAngle < enemyManager.maximumDetectionAngle && viewableAngle > enemyManager.minimumDetectionAngle)
                {
                    enemyManager.currentTarget = character;
                    isSleeping = false;
                    enemyAnimatorManager.PlayTargetAnimationEnemy2(wakeAnimation, true);
                }
            }

        }
        #endregion
    
        if(enemyManager.currentTarget!=null){
            return followTargetState;
        }else{
            return this;
        }
    
    }
}
