using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Spells/Projectile Spells")]
public class ProjectTileSpell : SpellItem
{
    public float baseDamage;
    public float projectileForwardVelocity;
    public float projectileUpVelocity;
    public float projectileMass;
    public bool isEffectedByGravity;
    Rigidbody rigidbody;

    public override void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats,WeaponSlotManager weaponSlotManager)
    {
        base.AttemptToCastSpell(animatorHandler, playerStats,weaponSlotManager);
        GameObject instantiatedpellWarmUpFX=Instantiate(spellWarmUpFX,weaponSlotManager.rightHandSlot.transform);
        instantiatedpellWarmUpFX.gameObject.transform.localScale=new Vector3(100,100,100);
        animatorHandler.PlayTargetAnimation(spellAnimation,true);
    }

    public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats,CameraHandler cameraHandler,WeaponSlotManager weaponSlotManager)
    {
        base.SuccessfullyCastSpell(animatorHandler, playerStats,cameraHandler,weaponSlotManager);
        GameObject instantiatedSpellFx=Instantiate(spellCastFX,weaponSlotManager.rightHandSlot.transform.position,cameraHandler.cameraPivotTransform.rotation);
        rigidbody=instantiatedSpellFx.GetComponent<Rigidbody>();

        if(cameraHandler.currentLockOnTransform!=null){
            instantiatedSpellFx.transform.LookAt(cameraHandler.currentLockOnTransform.transform);
        }else{
            instantiatedSpellFx.transform.rotation=Quaternion.Euler(cameraHandler.cameraPivotTransform.eulerAngles.x,playerStats.transform.eulerAngles.y,0);
        }

        rigidbody.AddForce(instantiatedSpellFx.transform.forward*projectileForwardVelocity);
        rigidbody.AddForce(instantiatedSpellFx.transform.up*projectileUpVelocity);
        rigidbody.useGravity=isEffectedByGravity;
        rigidbody.mass=projectileMass;
        instantiatedSpellFx.transform.parent=null;

    }
}
