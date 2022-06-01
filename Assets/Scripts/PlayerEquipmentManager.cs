using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    InputHandler InputHandler;
    PlayerInventory playerInventory;
    public BlockCollider blockCollider;

    private void Awake()
    {
        InputHandler = GetComponentInParent<InputHandler>();
        playerInventory = GetComponentInParent<PlayerInventory>();
    }

    public void OpenBlockCollider()
    {
        if (InputHandler.twoHandedFlag)
        {
            blockCollider.SetColliderDamageAbsorption(playerInventory.rightWeapon);
        }
        else
        {

            blockCollider.SetColliderDamageAbsorption(playerInventory.leftWeapon);
        }
        blockCollider.EnableBlockCollider();
    }
    public void CloseBlockCollider()
    {

        blockCollider.DisableBlockCollider();
    }
}
