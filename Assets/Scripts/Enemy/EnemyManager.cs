using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : CharacterManager
{
    EnemyLocomotionManager enemyLocomotionManager;
    EnemyAnimatorManager enemyAnimatorManager;
  
    EnemyStats enemyStats;
    public State currentState;

    public NavMeshAgent navMeshAgent;
    public Rigidbody enemyRigidbody;
    public CharacterStats currentTarget;
    public bool isPerformingAction;
    public bool allowAIToPerfomCombos;
    public float comboLikelyHood;
    public bool isInteracting;
    public float rotationSpeed=15f;

    public bool canDoCombo;

    public float maximumAttackingRange=1f;
    [Header("Stats")]
    public float detectionRadius=20;
    public float minimumDetectionAngle=-50;
    public float maximumDetectionAngle=50;
    public float currentRecoveryTime=0;
    Animator anim;

    private void Awake() {
        enemyLocomotionManager=GetComponent<EnemyLocomotionManager>();
        enemyAnimatorManager=GetComponentInChildren<EnemyAnimatorManager>();
        navMeshAgent=GetComponentInChildren<NavMeshAgent>();
        enemyStats=GetComponent<EnemyStats>();
        backStabCollider=GetComponentInChildren<CriticalDamageCollider>();
        enemyRigidbody=GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start() {
        navMeshAgent.enabled=false;
        enemyRigidbody.isKinematic=false;
    }
    private  void Update() {
      HandleRecoveryTime();
      HandleStateMachine();
      isInteracting=enemyAnimatorManager.anim.GetBool("isInteracting");
      enemyAnimatorManager.anim.SetBool("isDead",enemyStats.isDead);
      canDoCombo=enemyAnimatorManager.anim.GetBool("canDoCombo");
    }

    private void LateUpdate() {
        navMeshAgent.transform.localPosition = Vector3.zero;
        navMeshAgent.transform.localRotation = Quaternion.identity;
    }
    private void HandleStateMachine(){
       if(currentState!=null){
           State newState=currentState.Tick(this,enemyStats,enemyAnimatorManager);
           if(newState!=null){
               SwitchToNextState(newState);
           }
       }
    }

    private void SwitchToNextState(State newState)
    {
        currentState=newState;
    }

    private void HandleRecoveryTime(){
        if(currentRecoveryTime >0){
            currentRecoveryTime-=Time.deltaTime;
        }

        if(isPerformingAction){
            if(currentRecoveryTime<=0){
                isPerformingAction=false;
            }
        }
    }
}
