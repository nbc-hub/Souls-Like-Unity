using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollider : MonoBehaviour
{
    public BoxCollider blockCollider;

    public float blockingPhysicalDamageAbsorption;

    private void Awake() {
        blockCollider=GetComponent<BoxCollider>();
    }

    public void SetColliderDamageAbsorption(WeaponItem weapon){
        if(weapon!=null){
            blockingPhysicalDamageAbsorption=weapon.physicalDamageAbsorption;
        }
    }

    public void EnableBlockCollider(){
        blockCollider.enabled=true;
    }

    public void DisableBlockCollider(){
        blockCollider.enabled=false;
    }
}
