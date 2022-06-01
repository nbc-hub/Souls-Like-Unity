using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public EquipmentWindowUI equipmentWindowUI;

    public bool rightHandSlot1Selected;
    public bool rightHandSlot2Selected;
    public bool leftHandSlot1Selected;
    public bool leftHandSlot2Selected;
    public GameObject selectWindow;
    public GameObject hudWindow;
    public GameObject weaponInventoryWindow;
    public GameObject equipmentWindow;
    public GameObject weaponInventorySlotPrefab;
    public Transform weaponInventorySlotParent;
    WeaponInventorySlot[] weaponInventorySlots;

   
    private void Start() {
        weaponInventorySlots=weaponInventorySlotParent.GetComponentsInChildren<WeaponInventorySlot>();
        equipmentWindowUI.LoadWeaponsOnEquipmentScreen(playerInventory);
    }
    public void UpdateUI(){
        for (int i =0;i<weaponInventorySlots.Length;i++){
            if(i<playerInventory.weaponInventory.Count){
                if(weaponInventorySlots.Length<playerInventory.weaponInventory.Count){

                    Instantiate(weaponInventorySlotPrefab,weaponInventorySlotParent);
                    weaponInventorySlots=weaponInventorySlotParent.GetComponentsInChildren<WeaponInventorySlot>();
                }
                weaponInventorySlots[i].AddItem(playerInventory.weaponInventory[i]);
            }
            else{
                weaponInventorySlots[i].ClearInventorySlot();
            }
        }
    }
    public void OpenSelectWindow(){
        selectWindow.SetActive(true);
    }

    public void CloseSelectWindow(){
        selectWindow.SetActive(false);
    }

    public void CloseAllInventoryWindow(){
        ResetAllSelectedSlots();
        weaponInventoryWindow.SetActive(false);
        equipmentWindow.SetActive(false);
    }

    public void ResetAllSelectedSlots(){
        rightHandSlot1Selected=false;
        rightHandSlot2Selected=false;
        leftHandSlot1Selected=false;
        leftHandSlot2Selected=false;
    }
}
