using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    CharacterManager characterManager;
    Collider damageCollider;
    public bool enabledDamageColliderOnStart=false;
    public int currentWeaponDamage = 25;
    private void Awake()
    {
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = enabledDamageColliderOnStart;
        characterManager=GetComponentInParent<CharacterManager>();
        
        
    }

    public void EnableDamageCollider()
    {
        if (damageCollider != null)
        {
            damageCollider.enabled = true;
        }

    }

    public void DisableDamageCollider()
    {
        if (damageCollider != null)
        {
            damageCollider.enabled = false;
        }

    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            CharacterManager enemyCharacterManager = other.GetComponent<CharacterManager>();
            BlockCollider shield=other.GetComponentInChildren<BlockCollider>();



            if (enemyCharacterManager != null)
            {
                if (enemyCharacterManager.isParrying)
                {
                    Debug.Log("Enemy Parried");
                    characterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Parried",true);
                    return;
                }else if (shield!=null && enemyCharacterManager.isBlocking){
                    float physicalDamageAfterBlock=currentWeaponDamage-(currentWeaponDamage*shield.blockingPhysicalDamageAbsorption)/100;

                    if(playerStats!=null){
                        playerStats.TakeDamage(Mathf.RoundToInt(physicalDamageAfterBlock),"Block Hit");
                        return;
                    }
                }
            }

            if (playerStats != null)
            {
                playerStats.TakeDamage(currentWeaponDamage);
            }
        }

        if (other.tag == "Enemy")
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            CharacterManager enemyCharacterManager = other.GetComponent<CharacterManager>();
            BlockCollider shield=other.GetComponentInChildren<BlockCollider>();
            
            Debug.Log("Enemy");
            if (enemyCharacterManager != null)
            {
                if (enemyCharacterManager.isParrying)
                {
                    characterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Parried",true);
                    return;
                }
                else if (shield!=null && enemyCharacterManager.isBlocking){
                    float physicalDamageAfterBlock=currentWeaponDamage-(currentWeaponDamage*shield.blockingPhysicalDamageAbsorption)/100;

                    if(enemyStats!=null){
                        enemyStats.TakeDamage(Mathf.RoundToInt(physicalDamageAfterBlock),"Block Hit");
                        return;
                    }
                }
            }

            if (enemyStats != null)
            {
                enemyStats.TakeDamage(currentWeaponDamage);
            }
        }
    }
}
