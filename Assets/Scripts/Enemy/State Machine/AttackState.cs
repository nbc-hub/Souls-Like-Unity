using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public CombatStanceState combatStanceState;
    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;
    
    bool willDoCombo=false;
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {

        if (enemyStats.isDead)
            return this;

        if (enemyManager.isInteracting && enemyManager.canDoCombo==false)
        {
            return this;
        }
        else if (enemyManager.isInteracting && enemyManager.canDoCombo){
            if (willDoCombo){
            enemyAnimatorManager.PlayTargetAnimationEnemy2(currentAttack.animationString, true);
            willDoCombo=false;
        }
        }

        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, enemyManager.transform.forward);
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

        if (enemyManager.isPerformingAction)
        {
            return combatStanceState;
        }

        HandleRotateTowardsTarget(enemyManager, distanceFromTarget);
        GetNewAttack(enemyManager);

        if (currentAttack != null)
        {
            if (distanceFromTarget < currentAttack.minimumAttackDistance)
            {
                return this;
            }
            else if (distanceFromTarget < currentAttack.maximumAttackDistance)
            {
                if (viewableAngle <= currentAttack.maximumAttackAngle
                    && viewableAngle >= currentAttack.minimumAttackAngle)
                {
                    if (enemyManager.currentRecoveryTime <= 0 && enemyManager.isPerformingAction == false)
                    {
                        enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                        enemyAnimatorManager.anim.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);
                        enemyAnimatorManager.PlayTargetAnimationEnemy2(currentAttack.animationString, true);
                        enemyManager.isPerformingAction = true;
                        RollForComboChance(enemyManager);
                        if (currentAttack.canDoCombo && willDoCombo)
                        {
                            currentAttack = currentAttack.comboAction;
                            return this;

                        }
                        else
                        {
                            enemyManager.currentRecoveryTime = currentAttack.recoveryTime;
                            currentAttack = null;
                            return combatStanceState;
                        }
                    }
                }
            }
        }
        else
        {
            GetNewAttack(enemyManager);
        }

        return combatStanceState;



    }
    private void GetNewAttack(EnemyManager enemyManager)
    {

        Vector3 targetDir = enemyManager.currentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDir, transform.forward);
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

        int maxScore = 0;

        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            if (distanceFromTarget < enemyAttackAction.maximumAttackDistance
                && distanceFromTarget >= enemyAttackAction.minimumAttackDistance)
            {
                if (viewableAngle < enemyAttackAction.maximumAttackAngle && viewableAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    maxScore += enemyAttackAction.attackScore;
                }
            }
        }

        int randomValue = Random.Range(0, maxScore);
        int tempScore = 0;

        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            if (distanceFromTarget < enemyAttackAction.maximumAttackDistance
                && distanceFromTarget >= enemyAttackAction.minimumAttackDistance)
            {
                if (viewableAngle < enemyAttackAction.maximumAttackAngle && viewableAngle >= enemyAttackAction.minimumAttackAngle)
                {
                    if (currentAttack != null)
                    {
                        return;
                    }
                    tempScore += enemyAttackAction.attackScore;
                    if (tempScore > randomValue)
                    {
                        currentAttack = enemyAttackAction;
                    }
                }
            }
        }
    }

    private void HandleRotateTowardsTarget(EnemyManager enemyManager, float distanceFromTarget)
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


    private void RollForComboChance(EnemyManager enemyManager){
        float comboChange=Random.Range(0,100);
        if(enemyManager.allowAIToPerfomCombos && comboChange <=enemyManager.comboLikelyHood){
            willDoCombo=true;
        }
    }
}
