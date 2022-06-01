using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetState : State
{
   public CombatStanceState combatStanceState;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        if(enemyStats.isDead)
            return this;
        
        if(enemyManager.isInteracting){
            return this;
        }
        if (enemyManager.isPerformingAction){
            enemyAnimatorManager.anim.SetFloat("Vertical",0,0.1f,Time.deltaTime);
            return this;
        }

        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, enemyManager.transform.forward);
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

        if (distanceFromTarget > enemyManager.maximumAttackingRange)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
        }


        HandleRotateTowardsTarget(enemyManager,distanceFromTarget);

        if (distanceFromTarget <= enemyManager.maximumAttackingRange)
        {
            return combatStanceState;
        }
        else
        {
            return this;
        }
    }

    private void HandleRotateTowardsTarget(EnemyManager enemyManager,float distanceFromTarget)
    {
        if (enemyManager.isPerformingAction)
        {
            Vector3 dir = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
            dir.y = 0;
            dir.Normalize();
            if (dir == Vector3.zero)
            {
                dir = enemyManager.transform.forward;
            }
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            enemyManager.transform.rotation = Quaternion.Slerp(enemyManager.transform.rotation, targetRotation, enemyManager.rotationSpeed / Time.deltaTime);
        }
         else
        {
          
            enemyManager.navMeshAgent.enabled = true;
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);

            float rotationToApplyToDynamicEnemy = Quaternion.Angle(enemyManager.transform.rotation, Quaternion.LookRotation(enemyManager.navMeshAgent.desiredVelocity.normalized));
            if (distanceFromTarget > 5) enemyManager.navMeshAgent.angularSpeed = 500f;
            else if (distanceFromTarget < 5 && Mathf.Abs(rotationToApplyToDynamicEnemy) < 30) enemyManager.navMeshAgent.angularSpeed = 50f;
            else if (distanceFromTarget < 5 && Mathf.Abs(rotationToApplyToDynamicEnemy) > 30) enemyManager.navMeshAgent.angularSpeed = 500f;

            Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
            Quaternion rotationToApplyToStaticEnemy = Quaternion.LookRotation(targetDirection);


            if (enemyManager.navMeshAgent.desiredVelocity.magnitude > 0)
            {
                enemyManager.navMeshAgent.updateRotation = false;
                enemyManager.transform.rotation = Quaternion.RotateTowards(enemyManager.transform.rotation,
                Quaternion.LookRotation(enemyManager.navMeshAgent.desiredVelocity.normalized), enemyManager.navMeshAgent.angularSpeed * Time.deltaTime);
            }
            else
            {
                enemyManager.transform.rotation = Quaternion.RotateTowards(enemyManager.transform.rotation, rotationToApplyToStaticEnemy, enemyManager.navMeshAgent.angularSpeed * Time.deltaTime);
            }
    }

        enemyManager.navMeshAgent.transform.localPosition = Vector3.zero;
        enemyManager.navMeshAgent.transform.localRotation = Quaternion.identity;
    }
}
