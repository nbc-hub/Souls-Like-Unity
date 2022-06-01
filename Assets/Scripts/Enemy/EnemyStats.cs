using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{

    Animator anim;

    
   

    private void Awake() {
        
        anim=GetComponentInChildren<Animator>();
    }
    private void Start() {
        
        maxHealth=SetMaxHealthFromHealthLevel();
        currentHealth=maxHealth;
       
    }

    private int SetMaxHealthFromHealthLevel(){
        maxHealth=healtLevel*10;
        return maxHealth;
    }

    public void TakeDamageNoAnimation(int damage){
        currentHealth=currentHealth-damage;
         if(currentHealth<=0){
         
            currentHealth=0;
            isDead=true;
        }
    }

    public override void  TakeDamage(int damage,string damageAnimation ="TakeDamage"){
        if(isDead)
            return;
        currentHealth=currentHealth-damage;
       
        anim.Play(damageAnimation);

        if(currentHealth<=0){
         
            currentHealth=0;
            anim.Play("Back Stabbed");
            isDead=true;
        }
    }
}
