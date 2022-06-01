using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Transform LockOnTransform;
    public BoxCollider backStapBoxCollider;
    public CriticalDamageCollider backStabCollider;
    public CriticalDamageCollider riposteCollider;

    [Header("Combo Flags")]
    public bool canBeRiposted;
    public bool isParrying;
    public bool isBlocking;
    public bool canBeParried;

    [Header("Spell")]
    public bool isFiringSpell;


    public int pendingCriticalDamage;
}
