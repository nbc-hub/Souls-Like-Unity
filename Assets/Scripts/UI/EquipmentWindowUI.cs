using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentWindowUI : MonoBehaviour
{
    public bool rightHandSlot1Selected;
    public bool rightHandSlot2Selected;
    public bool leftHandSlot1Selected;
    public bool leftHandSlot2Selected;

    public HandEquipmentSlotUI[] handEquipmentSlotUI;

    private void Awake() {

    }


    public  void LoadWeaponsOnEquipmentScreen(PlayerInventory playerInventory){
        for(int i =0;i<handEquipmentSlotUI.Length;i++){
            if(handEquipmentSlotUI[i].rightHandSlot1){
            handEquipmentSlotUI[i].AddItem(playerInventory.weaponRigthHandsSlot[0]);
            }else if(handEquipmentSlotUI[i].rightHandSlot2){
            handEquipmentSlotUI[i].AddItem(playerInventory.weaponRigthHandsSlot[1]);
            }else if(handEquipmentSlotUI[i].leftHandSlot1){
            handEquipmentSlotUI[i].AddItem(playerInventory.weaponLeftHandsSlot[0]);
            }else{
            handEquipmentSlotUI[i].AddItem(playerInventory.weaponLeftHandsSlot[1]);
            }
        }
    }
    public void SelectRightHandSlot1(){
        rightHandSlot1Selected=true;
    }

    public void SelectRightHandSlot2(){
        rightHandSlot2Selected=true;
    }

    public void SelectLeftHandSlot1(){
        leftHandSlot1Selected=true;
    }

    public void SelectLeftHandSlot2(){
        leftHandSlot2Selected=true;
    }
}
