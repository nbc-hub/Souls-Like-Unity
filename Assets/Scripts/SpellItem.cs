using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellItem : Item
{
    public GameObject spellWarmUpFX;
    public GameObject spellCastFX;
    public string spellAnimation;

    [Header("Spell Costs")]
    public int spellManaCost;

    [Header("Spell Type")]
    public bool isFaithSpell;
    public bool isMagicSpell;
    public bool isPyroSpell;

    [Header("Description")]
    [TextArea]
    public string spellDescription;
    
    public virtual void AttemptToCastSpell(AnimatorHandler animatorHandler,PlayerStats playerStats,WeaponSlotManager weaponSlotManager){
        Debug.Log("Attempt");
    }

    public virtual void SuccessfullyCastSpell(AnimatorHandler animatorHandler,PlayerStats playerStats,CameraHandler cameraHandler,WeaponSlotManager weaponSlotManager){
        Debug.Log("Successfully");
        playerStats.DecreaseMana(spellManaCost);
    }
}
