using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Spells/GlobalSpell")]
public class GlobalSpell : SpellItem
{
    public LayerMask detectionLayer;
    public float detectionRadius=30;
    public GameObject enemyWarmUpFX;
    public GameObject enemySpellCastFX;

    public override void AttemptToCastSpell(AnimatorHandler animatorHandler,PlayerStats playerStats,WeaponSlotManager weaponSlotManager)
    {
        base.AttemptToCastSpell(animatorHandler,playerStats,weaponSlotManager);

        Collider[] colliders = Physics.OverlapSphere(playerStats.transform.position,detectionRadius, detectionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();
            AnimatorManager animatorManager=colliders[i].transform.GetComponentInChildren<AnimatorManager>();
            if (characterStats != null)
            {
                GameObject instantiatedEnemyWarmUpSpellFX=Instantiate(enemyWarmUpFX,animatorManager.transform);
                Destroy(instantiatedEnemyWarmUpSpellFX,2f);
                
            }
        }
        animatorHandler.PlayTargetAnimation(spellAnimation,true);
        Debug.Log("Global Spell Warm Up");
        
            
        
    }

    public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler,PlayerStats playerStats,CameraHandler cameraHandler,WeaponSlotManager weaponSlotManager)
    {
        base.SuccessfullyCastSpell(animatorHandler,playerStats,cameraHandler,weaponSlotManager);
        Collider[] colliders = Physics.OverlapSphere(playerStats.transform.position,detectionRadius, detectionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();
            AnimatorManager animatorManager=colliders[i].transform.GetComponentInChildren<AnimatorManager>();
            if (characterStats != null)
            {
                GameObject instantiatedEnemyCastSpellFX=Instantiate(enemySpellCastFX,characterStats.globalSpellCastFXTransform.transform);
                Destroy(instantiatedEnemyCastSpellFX,3f);
                characterStats.TakeDamage(100);
                
            }
        }

        Debug.Log("Global Spell Successfully");
    }
}
