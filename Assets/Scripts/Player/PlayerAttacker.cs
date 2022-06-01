using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    AnimatorHandler animatorHandler;
    PlayerManager playerManager;
    CameraHandler cameraHandler;
    PlayerStats playerStats;
    PlayerInventory playerInventory;
    PlayerEquipmentManager playerEquipmentManager;
    WeaponSlotManager weaponSlotManager;
    InputHandler inputHandler;
    public string lastAttack;

    LayerMask backStabLayer = 1 << 12;
    LayerMask riposteLayer = 1 << 13;

    private void Start()
    {
        animatorHandler = GetComponent<AnimatorHandler>();
        playerStats = GetComponentInParent<PlayerStats>();
        cameraHandler=FindObjectOfType<CameraHandler>();
        playerEquipmentManager=GetComponent<PlayerEquipmentManager>();
        playerManager = GetComponentInParent<PlayerManager>();
        playerInventory = GetComponentInParent<PlayerInventory>();
        weaponSlotManager = GetComponent<WeaponSlotManager>();
        inputHandler = GetComponentInParent<InputHandler>();
    }

    public void HandleWeaponCombo(WeaponItem weapon)
    {
        if (playerStats.currentStamina <= playerInventory.rightWeapon.baseStamina)
            return;
        if (inputHandler.comboFlag)
        {
            animatorHandler.anim.SetBool("canDoCombo", false);
            if (lastAttack == weapon.LightAttack_1)
            {
                animatorHandler.PlayTargetAnimation(weapon.LightAttack_2, true);
            }
            else if (lastAttack == weapon.twoHandedAttack_1)
            {
                animatorHandler.PlayTargetAnimation(weapon.twoHandedAttack_2, true);
            }
        }
    }
    public void HandleLightAttack(WeaponItem item)
    {
        if (playerStats.currentStamina <= playerInventory.rightWeapon.baseStamina)
            return;
        weaponSlotManager.attackingWeapon = item;
        if (inputHandler.twoHandedFlag)
        {
            animatorHandler.PlayTargetAnimation(item.twoHandedAttack_1, true);
            lastAttack = item.twoHandedAttack_1;
        }
        else
        {
            Debug.Log("BuradaLight" + item);
            animatorHandler.PlayTargetAnimation(item.LightAttack_1, true);
            lastAttack = item.LightAttack_1;
        }

    }

    public void HandleHeavyAttack(WeaponItem item)
    {
        if (playerStats.currentStamina <= playerInventory.rightWeapon.baseStamina)
            return;

        weaponSlotManager.attackingWeapon = item;
        if (inputHandler.twoHandedFlag)
        {
            animatorHandler.PlayTargetAnimation(item.HeavyAttack_1, true);
            lastAttack = item.HeavyAttack_1;
        }
        else
        {


            animatorHandler.PlayTargetAnimation(item.HeavyAttack_1, true);
            lastAttack = item.HeavyAttack_1;
        }


    }

    #region Input Actions
    public void HandleRBAction()
    {
        if (playerInventory.rightWeapon.isMeleeWeapon)
        {
            PerformRBMeleeAction();
        }
        else if (playerInventory.rightWeapon.isSpellCaster || playerInventory.rightWeapon.isFaithCaster || playerInventory.rightWeapon.isPyroCaster)
        {
            PerformRBMagicAction(playerInventory.rightWeapon);
        }
        else if (playerInventory.rightWeapon.isFaithCaster)
        {

        }
        else if (playerInventory.rightWeapon.isPyroCaster) { }

    }

    public void HandleLTAction()
    {
        if (playerInventory.leftWeapon.isShieldWeapon)
        {
            PerformLTActionArt(inputHandler.twoHandedFlag);
        }else if(playerInventory.leftWeapon.isMeleeWeapon)
        {
            // light attack
        }

    }

    public void HandleLBAction(){
        PerformLBBlockingAction();
    }
    #endregion

    #region AttackActions
    private void PerformRBMeleeAction()
    {
        if (playerManager.canDoCombo)
        {
            inputHandler.comboFlag = true;
            HandleWeaponCombo(playerInventory.rightWeapon);
            inputHandler.comboFlag = false;
        }
        else
        {
            if (playerManager.isInteracting)
            {
                return;
            }
            if (playerManager.canDoCombo)
                return;
            animatorHandler.anim.SetBool("isUsingRightHand", true);
            HandleLightAttack(playerInventory.rightWeapon);
        }
    }

    private void PerformLBBlockingAction(){
        if(playerManager.isInteracting)
            return;

        if(playerManager.isBlocking)
            return;
        animatorHandler.PlayTargetAnimation("Block Start",false,true);
        playerEquipmentManager.OpenBlockCollider();
        playerManager.isBlocking=true;
    }

    private void PerformRBMagicAction(WeaponItem weaponItem)
    {
        if (playerManager.isInteracting)
        {
            return;
        }

        Debug.Log("Pyro mu"+playerInventory.currentSpell);
        if (weaponItem.isFaithCaster)
        {
            if (playerInventory.currentSpell != null && playerInventory.currentSpell.isFaithSpell)
            {
                if (playerStats.currentMana >= playerInventory.currentSpell.spellManaCost)
                {
                    playerInventory.currentSpell.AttemptToCastSpell(animatorHandler, playerStats,weaponSlotManager);
                }
                else
                {
                    Debug.Log("Manan bitti paşam");
                }
            }
        
        }
        
        if(weaponItem.isPyroCaster){
            if (playerInventory.currentSpell != null && playerInventory.currentSpell.isPyroSpell)
            {
                if (playerStats.currentMana >= playerInventory.currentSpell.spellManaCost)
                {
                    Debug.Log("Atıyorum");
                    playerInventory.currentSpell.AttemptToCastSpell(animatorHandler, playerStats,weaponSlotManager);
                }
                else
                {
                    Debug.Log("Manan bitti paşam");
                }
            }
        }
    }

    private void PerformLTActionArt(bool isTwoHandling)
    {
        if (playerManager.isInteracting)
        {
            return;
        }

        if (isTwoHandling)
        {
        }
        else
        {
            animatorHandler.PlayTargetAnimation(playerInventory.leftWeapon.weapon_art,true);

        }
    }

    private void SuccessfullyCastSpell()
    {
        playerInventory.currentSpell.SuccessfullyCastSpell(animatorHandler, playerStats,cameraHandler,weaponSlotManager);
        animatorHandler.anim.SetBool("isFiringSpell",true);
    }
    #endregion

    public void AttemptBackstabOrRiposte()
    {

        if (playerStats.currentStamina <= playerInventory.rightWeapon.baseStamina)
            return;

        RaycastHit hit;


        if (Physics.Raycast(inputHandler.criticalAttackRayCastStartPoint.position, transform.TransformDirection(Vector3.forward), out hit, 0.5f, backStabLayer))
        {
            Debug.Log("Back Stab");
            CharacterManager enemyCharacterManager = hit.transform.gameObject.GetComponentInParent<CharacterManager>();
            DamageCollider rightWeapon = weaponSlotManager.rigthHandDamageCollider;
            if (enemyCharacterManager != null)
            {
                playerManager.transform.position = enemyCharacterManager.backStabCollider.criticalDamageStandPoint.position;

                Vector3 rotationDirection = playerManager.transform.root.eulerAngles;
                rotationDirection = hit.transform.position - playerManager.transform.position;
                rotationDirection.y = 0;
                rotationDirection.Normalize();
                Quaternion tr = Quaternion.LookRotation(rotationDirection);
                Quaternion targetRotation = Quaternion.Slerp(playerManager.transform.rotation, tr, 500 * Time.deltaTime);
                playerManager.transform.rotation = targetRotation;

                int criticalDamage = playerInventory.rightWeapon.criticalDamageMultiplier * rightWeapon.currentWeaponDamage;
                enemyCharacterManager.pendingCriticalDamage = criticalDamage;


                animatorHandler.PlayTargetAnimation("Back Stab", true);
                StartCoroutine(criticalAttackRoutine(enemyCharacterManager, "Back Stabbed"));
            }
        }
        else if (Physics.Raycast(inputHandler.criticalAttackRayCastStartPoint.position, transform.TransformDirection(Vector3.forward), out hit, 0.7f, riposteLayer))
        {
            Debug.Log("Riposte");
            CharacterManager enemyCharacterManager = hit.transform.gameObject.GetComponentInParent<CharacterManager>();
            DamageCollider rightWeapon = weaponSlotManager.rigthHandDamageCollider;
            if (enemyCharacterManager != null && enemyCharacterManager.canBeRiposted)
            {
                playerManager.transform.position = enemyCharacterManager.riposteCollider.criticalDamageStandPoint.position;

                Vector3 rotationDirection = playerManager.transform.root.eulerAngles;
                rotationDirection = hit.transform.position - playerManager.transform.position;
                rotationDirection.y = 0;
                rotationDirection.Normalize();
                Quaternion tr = Quaternion.LookRotation(rotationDirection);
                Quaternion targetRotation = Quaternion.Slerp(playerManager.transform.rotation, tr, 500 * Time.deltaTime);
                playerManager.transform.rotation = targetRotation;

                int criticalDamage = playerInventory.rightWeapon.criticalDamageMultiplier * rightWeapon.currentWeaponDamage;
                enemyCharacterManager.pendingCriticalDamage = criticalDamage;


                animatorHandler.PlayTargetAnimation("Riposte", true);
                StartCoroutine(criticalAttackRoutine(enemyCharacterManager, "Riposted"));
            }
        }
    }

    IEnumerator criticalAttackRoutine(CharacterManager enemyCharacterManager, string stringAnimation)
    {
        yield return new WaitForSeconds(1.2f);
        enemyCharacterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation(stringAnimation, true);
    }
}
