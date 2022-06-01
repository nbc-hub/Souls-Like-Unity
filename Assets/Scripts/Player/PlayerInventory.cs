using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager weaponSlotManager;

    public SpellItem currentSpell;
    public WeaponItem rightWeapon;
    public WeaponItem leftWeapon;

    public WeaponItem unarmedWeapon;
    public WeaponItem[] weaponRigthHandsSlot = new WeaponItem[1];
    public WeaponItem[] weaponLeftHandsSlot = new WeaponItem[1];

    public int currentRightWeaponIndex=0;
    public int currentLeftWeaponIndex=0;

    public List<WeaponItem> weaponInventory;

    private void Awake() {
        weaponSlotManager=GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start() {
        rightWeapon=weaponRigthHandsSlot[0];
        weaponSlotManager.LoadWeaponOnSlot(rightWeapon,false);
        weaponSlotManager.LoadWeaponOnSlot(leftWeapon,true);
        
    }

    public void ChangeRigthWeapon(){
        currentRightWeaponIndex++;
        if(currentRightWeaponIndex==0 && weaponRigthHandsSlot[0]!=null){
            rightWeapon=weaponRigthHandsSlot[currentRightWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponRigthHandsSlot[currentRightWeaponIndex],false);
        }
        else if(currentRightWeaponIndex==0 && weaponRigthHandsSlot[0]==null){
            currentRightWeaponIndex++;
        }
        else if(currentRightWeaponIndex==1 && weaponRigthHandsSlot[1]!=null){
            rightWeapon=weaponRigthHandsSlot[currentRightWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponRigthHandsSlot[currentRightWeaponIndex],false);
        }else{
            currentRightWeaponIndex++;
        }

        if(currentRightWeaponIndex > weaponRigthHandsSlot.Length-1){
            
            currentRightWeaponIndex=-1;
            rightWeapon=unarmedWeapon;
            weaponSlotManager.LoadWeaponOnSlot(unarmedWeapon,false);
        }
    }

    public void ChangeLeftWeapon(){
        currentLeftWeaponIndex++;
        if(currentLeftWeaponIndex==0 && weaponLeftHandsSlot[0]!=null){
            leftWeapon=weaponLeftHandsSlot[currentLeftWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponLeftHandsSlot[currentLeftWeaponIndex],true);
        }
        else if(currentLeftWeaponIndex==0 && weaponLeftHandsSlot[0]==null){
            currentLeftWeaponIndex++;
        }
        else if(currentLeftWeaponIndex==1 && weaponLeftHandsSlot[1]!=null){
            leftWeapon=weaponLeftHandsSlot[currentLeftWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponLeftHandsSlot[currentLeftWeaponIndex],true);
        }else{
            currentLeftWeaponIndex++;
        }

        if(currentLeftWeaponIndex > weaponLeftHandsSlot.Length-1){
            currentLeftWeaponIndex=-1;
            leftWeapon=unarmedWeapon;
            weaponSlotManager.LoadWeaponOnSlot(unarmedWeapon,true);
        }
    }
}
