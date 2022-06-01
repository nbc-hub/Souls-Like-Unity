using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Weapon Item")]
public class WeaponItem : Item
{
    public GameObject weaponModel;
    public bool isUnarmed;
    [Header("Damage")]
    public int baseDamage=25;
    public int criticalDamageMultiplier=4;

    [Header("Absorption")]
    public float physicalDamageAbsorption;

    [Header("Idle Animation Strings")]
    public string leftArmIdle;
    public string rigthArmIdle;
    public string twoHandedIdle;

    [Header("Weapon Animation Strings")]
    public string LightAttack_1;
    public string LightAttack_2;
    public string twoHandedAttack_1;
    public string twoHandedAttack_2;
    public string HeavyAttack_1;

    [Header("Weapon Art")]
    public string weapon_art;

    [Header("Stamina Costs")]
    public int baseStamina;
    public float lightAttackMultiplier;
    public float heavyAttackMultiplier;

    [Header("Weapon Type")]
    public bool isSpellCaster;
    public bool isFaithCaster;
    public bool isPyroCaster;
    public bool isMeleeWeapon;
    public bool isShieldWeapon;
}
