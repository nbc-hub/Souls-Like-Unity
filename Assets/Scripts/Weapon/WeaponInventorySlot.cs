using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventorySlot : MonoBehaviour
{
    public Image icon;
    WeaponItem weaponItem;
    UIManager uiManager;

    WeaponSlotManager weaponSlotManager;
    PlayerInventory playerInventory;

    private void Awake() {
        uiManager=FindObjectOfType<UIManager>();
        playerInventory=FindObjectOfType<PlayerInventory>();
        weaponSlotManager=FindObjectOfType<WeaponSlotManager>();
    }
    public void AddItem(WeaponItem newItem){
        weaponItem=newItem;
        icon.sprite=newItem.itemIcon;
        icon.enabled=true;
        gameObject.SetActive(true);
    }

    public void ClearInventorySlot(){
        weaponItem=null;
        icon.sprite=null;
        icon.enabled=false;
        gameObject.SetActive(false);

    }

    public void EquipTheItem(){
        if(uiManager.rightHandSlot1Selected){
            playerInventory.weaponInventory.Add(playerInventory.weaponRigthHandsSlot[0]);
            playerInventory.weaponRigthHandsSlot[0]=weaponItem;
            playerInventory.weaponInventory.Remove(weaponItem);
        }else if (uiManager.rightHandSlot2Selected){
            playerInventory.weaponInventory.Add(playerInventory.weaponRigthHandsSlot[1]);
            playerInventory.weaponRigthHandsSlot[1]=weaponItem;
            playerInventory.weaponInventory.Remove(weaponItem);
        }else if(uiManager.leftHandSlot1Selected){
            playerInventory.weaponInventory.Add(playerInventory.weaponLeftHandsSlot[0]);
            playerInventory.weaponLeftHandsSlot[0]=weaponItem;
            playerInventory.weaponInventory.Remove(weaponItem);
        }else if (uiManager.leftHandSlot2Selected){
            playerInventory.weaponInventory.Add(playerInventory.weaponLeftHandsSlot[1]);
            playerInventory.weaponLeftHandsSlot[1]=weaponItem;
            playerInventory.weaponInventory.Remove(weaponItem);
        }else {
            return;
        }
        playerInventory.rightWeapon=playerInventory.weaponRigthHandsSlot[playerInventory.currentRightWeaponIndex];
        playerInventory.leftWeapon=playerInventory.weaponLeftHandsSlot[playerInventory.currentLeftWeaponIndex];
        weaponSlotManager.LoadWeaponOnSlot(playerInventory.rightWeapon,false);
        weaponSlotManager.LoadWeaponOnSlot(playerInventory.leftWeapon,true);

        uiManager.equipmentWindowUI.LoadWeaponsOnEquipmentScreen(playerInventory);
        uiManager.ResetAllSelectedSlots();
    }
}
