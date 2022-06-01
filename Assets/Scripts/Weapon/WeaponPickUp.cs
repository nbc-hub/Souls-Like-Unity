using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickUp : Interactable
{
    public WeaponItem weaponItem;

 
    public override void Interact(PlayerManager playerManager)
    {
        base.Interact(playerManager);
        PickUpItem(playerManager);

    }

    private void PickUpItem(PlayerManager playerManager){
        PlayerMovement playerMovement;
        PlayerInventory playerInventory;
        AnimatorHandler animatorHandler;

        playerMovement=playerManager.GetComponent<PlayerMovement>();
        playerInventory=playerManager.GetComponent<PlayerInventory>();
        animatorHandler=playerManager.GetComponentInChildren<AnimatorHandler>();

        playerMovement.rigidbody.velocity=Vector3.zero;
        animatorHandler.PlayTargetAnimation("Pick Up Item",true);
        playerInventory.weaponInventory.Add(weaponItem);
        playerManager.itemInteractableGameObject.GetComponentInChildren<Text>().text=weaponItem.itemName;
        playerManager.itemInteractableGameObject.GetComponentInChildren<RawImage>().texture=weaponItem.itemIcon.texture;
        playerManager.itemInteractableGameObject.SetActive(true);
        Destroy(gameObject);
    }
    
}
