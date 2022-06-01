using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    public WeaponHolderSlot leftHandSlot;
    public WeaponHolderSlot rightHandSlot;

    WeaponHolderSlot backSlot;
    public WeaponItem attackingWeapon;

    Animator animator;

    public DamageCollider leftHandDamageCollider;
    public DamageCollider rigthHandDamageCollider;

    QuickSlotsUI quickSlotsUI;

    PlayerManager playerManager;
    PlayerInventory playerInventory;
    PlayerStats playerStats;
    InputHandler inputHandler;


    private void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
        animator = GetComponent<Animator>();
        quickSlotsUI = FindObjectOfType<QuickSlotsUI>();
        playerStats = GetComponentInParent<PlayerStats>();
        playerInventory=GetComponentInParent<PlayerInventory>();
        inputHandler = GetComponentInParent<InputHandler>();
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponSlot;
            }
            else if (weaponSlot.isRightHandSlot)
            {
                rightHandSlot = weaponSlot;
            }
            else if (weaponSlot.isBackSlot)
            {
                backSlot = weaponSlot;
            }
        }

    }

    public void LoadWeaponOnSlot(WeaponItem item, bool isLeft)
    {
        if (isLeft)
        {
            leftHandSlot.currentWeapon = item;
            leftHandSlot.LoadWeaponModel(item);
            LoadLeftHandDamageCollider();
            quickSlotsUI.UpdateWeaponSlotUI(true, item);
            #region leftHandIdleAnimation
            if (item != null)
            {
                animator.CrossFade(item.leftArmIdle, 0.2f);
            }
            else
            {
                animator.CrossFade("Left_Arm_Empty", 0.2f);
            }
            #endregion
        }
        else
        {
            #region  rightHandIdleAnimation
            if (inputHandler.twoHandedFlag)
            {
                backSlot.LoadWeaponModel(leftHandSlot.currentWeapon);
                leftHandSlot.UnloadWeaponAndDestroy();
                animator.CrossFade(item.twoHandedIdle, 0.2f);
            }
            else
            {
                animator.CrossFade("Both Arms Empty", 0.2f);
                backSlot.UnloadWeaponAndDestroy();
                if (item != null)
                {
                    animator.CrossFade(item.rigthArmIdle, 0.2f);
                }
                else
                {
                    animator.CrossFade("Right_Arm_Empty", 0.2f);
                }
            }
            rightHandSlot.currentWeapon = item;
            rightHandSlot.LoadWeaponModel(item);
            LoadRigthtHandDamageCollider();
            quickSlotsUI.UpdateWeaponSlotUI(false, item);

            #endregion
        }
    }

    public void DrainStaminaLigthAttack()
    {

        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
    }

    public void DrainStaminaHeavyAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
    }
    #region collider

    private void LoadLeftHandDamageCollider()
    {
        if(!leftHandSlot.currentWeapon.isUnarmed){
        leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        leftHandDamageCollider.currentWeaponDamage=playerInventory.leftWeapon.baseDamage;
        }
    }

    private void LoadRigthtHandDamageCollider()
    {
        rigthHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        rigthHandDamageCollider.currentWeaponDamage=playerInventory.rightWeapon.baseDamage;
    }


    public void OpenHandDamageCollider()
    {
        if (playerManager.isUsingRightHand)
        {
            rigthHandDamageCollider.EnableDamageCollider();
        }
        else if (playerManager.isUsingLeftHand)
        {
            leftHandDamageCollider.EnableDamageCollider();
        }
    }



    public void CloseHandDamageCollider()
    {
        if (rigthHandDamageCollider != null)
        {
            rigthHandDamageCollider.DisableDamageCollider();

        }

        if (leftHandDamageCollider != null)
        {

            leftHandDamageCollider.DisableDamageCollider();
        }
    }
    #endregion
}
