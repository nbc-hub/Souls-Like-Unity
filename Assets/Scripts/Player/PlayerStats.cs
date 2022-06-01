using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    AnimatorHandler animatorHandler;
    PlayerManager playerManager;
    HealthBar healthBar;

    ManaPointBar manaPointBar;
    StaminaBar staminaBar;

    public float staminaRegenAmount = 1f;
    public float staminaRegenTimer = 0f;
    private void Awake()
    {

        playerManager = GetComponent<PlayerManager>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        healthBar=FindObjectOfType<HealthBar>();
        staminaBar=FindObjectOfType<StaminaBar>();
        manaPointBar=FindObjectOfType<ManaPointBar>();
    }
    private void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
     //   currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetCurrentHealth(currentHealth);

        maxStamina = SetMaxStaminaFromStaminaLevel();
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);

        maxMana=SetMaxManaFromManaLevel();
        currentMana=maxMana;
        manaPointBar.SetMaxMana(currentMana);
        manaPointBar.SetCurrentMana(currentMana);
    }

    private void Update()
    {
        RegenStamina();
    }
    private float SetMaxStaminaFromStaminaLevel()
    {
        maxStamina = staminaLevel * 10;
        return maxStamina;
    }

    private float SetMaxManaFromManaLevel()
    {
        maxMana = manaLevel * 10;
        return maxMana;
    }
    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healtLevel * 10;
        return maxHealth;
    }

    public void TakeDamageNoAnimation(int damage){
        currentHealth=currentHealth-damage;
         if(currentHealth<=0){
         
            currentHealth=0;
            isDead=true;
        }
    }
    public override void TakeDamage(int damage,string damageAnimation="TakeDamage")
    {
        if (playerManager.isInvulnerable)
        {
            return;
        }
        if (isDead)
        {
            return;
        }
        currentHealth = currentHealth - damage;
        healthBar.SetCurrentHealth(currentHealth);
        animatorHandler.PlayTargetAnimation(damageAnimation, true);

        if (currentHealth <= 0)
        {
            healthBar.SetSliderImageStatu(false);
            currentHealth = 0;
            animatorHandler.PlayTargetAnimation("Death", true);
            isDead = true;
        }
    }

    public void TakeStaminaDamage(float damage)
    {
        currentStamina = currentStamina - damage;
        //Set Bar
        staminaBar.SetCurrentStamina(currentStamina);
        if (currentStamina <= 0)
        {

            currentStamina = 0;
            
        }
    }

    public void RegenStamina()
    {
        if (playerManager.isInteracting)
        {
            staminaRegenTimer = 0;
        }
        else
            staminaRegenTimer += Time.deltaTime;
        if (currentStamina < maxStamina && staminaRegenTimer > 1f)
        {
            
            currentStamina += staminaRegenAmount * Time.deltaTime;
            staminaBar.SetCurrentStamina(currentStamina);
            
        }
    }

    public void HealPlayer(int healAmount){
        currentHealth=currentHealth+healAmount;
        if(currentHealth > maxHealth){
            currentHealth=maxHealth;
        }
        healthBar.SetCurrentHealth(currentHealth);
    }

    public void DecreaseMana(int manaPoint){
        currentMana=currentMana-manaPoint;
        if(currentMana < 0){
            currentMana=0;
        }

        manaPointBar.SetCurrentMana(currentMana);
    }
}
