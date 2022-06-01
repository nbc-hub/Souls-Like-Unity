using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Spells/HealingSpell")]
public class HealingSpell : SpellItem
{
    public int healAmount=40;
    public override void AttemptToCastSpell(AnimatorHandler animatorHandler,PlayerStats playerStats,WeaponSlotManager weaponSlotManager)
    {
        base.AttemptToCastSpell(animatorHandler,playerStats,weaponSlotManager);
        GameObject instantiatedWarmUpSpellFX=Instantiate(spellWarmUpFX,animatorHandler.transform);
        animatorHandler.PlayTargetAnimation(spellAnimation,true);
        Debug.Log("Healing Spell Warm Up");
        
            
        
    }

    public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler,PlayerStats playerStats,CameraHandler cameraHandler,WeaponSlotManager weaponSlotManager)
    {
        base.SuccessfullyCastSpell(animatorHandler,playerStats,cameraHandler,weaponSlotManager);
        GameObject instantiatedSpellFX=Instantiate(spellCastFX,animatorHandler.transform);
        playerStats.HealPlayer(healAmount);
        Debug.Log("Healing Spell Successfully");
    }

   
  
}
