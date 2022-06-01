using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLocomotionManager : MonoBehaviour
{
    EnemyManager enemyManager;
    EnemyAnimatorManager enemyAnimatorManager;

    public CapsuleCollider characterCollider;
    public CapsuleCollider  characterCollisionBlockerCollider;
  

   
    private void Awake() {
        enemyManager=GetComponent<EnemyManager>();
        enemyAnimatorManager=GetComponentInChildren<EnemyAnimatorManager>();
        
    }

    private void Start() {
        Physics.IgnoreCollision(characterCollider,characterCollisionBlockerCollider,true);
    }
}
