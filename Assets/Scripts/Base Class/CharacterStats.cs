using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Transform globalSpellCastFXTransform;
    public int healtLevel=10;
    public int maxHealth;
    public int currentHealth;

    public float maxStamina;
    public float currentStamina;
    public int staminaLevel=10;

    public int manaLevel=10;
    public float maxMana;
    public float currentMana;

    public bool isDead;

    public virtual void TakeDamage(int damage,string damageAnimation="TakeDamage"){}
}
