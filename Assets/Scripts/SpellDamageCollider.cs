using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamageCollider : DamageCollider
{
    public GameObject impactParticles;
    public GameObject projectileParticles;
    public GameObject muzzlesParticles;

    CharacterStats spellTarget;
    Rigidbody rigidbody;
    public bool hasCollided=false;
    Vector3 impactNormal;

    private void Awake() {
        rigidbody=GetComponent<Rigidbody>();
    }
    private void Start() {
        projectileParticles=Instantiate(projectileParticles,transform.position,transform.rotation);
        projectileParticles.transform.parent=transform;

        if(muzzlesParticles){
            muzzlesParticles=Instantiate(muzzlesParticles,transform.position,transform.rotation);
            Destroy(muzzlesParticles,2f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(!hasCollided){

            spellTarget=collision.transform.GetComponent<CharacterStats>();

            if(spellTarget!=null){
                spellTarget.TakeDamage(currentWeaponDamage);
            }

            hasCollided=true;
            impactParticles=Instantiate(impactParticles,transform.position,Quaternion.FromToRotation(Vector3.up,impactNormal));

            Destroy(projectileParticles);
            Destroy(impactParticles,5f);
            Destroy(gameObject,5f);
        }
    }
}
