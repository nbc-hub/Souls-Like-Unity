using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    InputHandler inputHandler;
    CameraHandler cameraHandler;
    PlayerMovement playerMovement;
    PlayerStats playerStats;
    AnimatorHandler animatorHandler;
    InteractableUI interactableUI;

    public GameObject interactableUIGameObject;

    public GameObject itemInteractableGameObject;
    [Header("Flags")]
    public bool isInteracting;
    public bool isSprinting;
    public bool isInAir;
    public bool isGrounded;
    public bool canDoCombo;
    public bool isUsingRightHand;
    public bool isUsingLeftHand;
    public bool isInvulnerable;

    public CapsuleCollider characterCollider;
    public CapsuleCollider  characterCollisionBlockerCollider;
    Animator anim;

    private void Awake()
    {
        cameraHandler = FindObjectOfType<CameraHandler>();
        inputHandler = GetComponent<InputHandler>();
        playerMovement = GetComponent<PlayerMovement>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        interactableUI = FindObjectOfType<InteractableUI>();
        anim = GetComponentInChildren<Animator>();
        backStabCollider=GetComponentInChildren<CriticalDamageCollider>();
        playerStats=GetComponent<PlayerStats>();
        Physics.IgnoreCollision(characterCollider,characterCollisionBlockerCollider,true);
    }
    

    private void FixedUpdate()
    {
        float delta = Time.deltaTime;
        if (cameraHandler != null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
        }
    }

    private void Update()
    {
        float delta = Time.deltaTime;
        isInteracting = anim.GetBool("isInteracting");
        canDoCombo = anim.GetBool("canDoCombo");
        isUsingRightHand=anim.GetBool("isUsingRightHand");
        isUsingLeftHand=anim.GetBool("isUsingLeftHand");
        isInvulnerable=anim.GetBool("isInvulnerable");
        isFiringSpell=anim.GetBool("isFiringSpell");
        anim.SetBool("isBlocking",isBlocking);
        anim.SetBool("isInAir",isInAir);
        anim.SetBool("isDead",playerStats.isDead);
        

        inputHandler.TickInput(delta);
        animatorHandler.canRotate= anim.GetBool("canRotate");
        playerMovement.HandleMovement(delta);
        playerMovement.HandleRotation(delta);
        playerMovement.HandleRollingAndSprinting(delta);
        playerMovement.HandleFalling(delta, playerMovement.moveDirection);
        playerMovement.HandleJumping();
        CheckInteractingObject();
    }

    private void LateUpdate()
    {

        
        inputHandler.rollFlag = false;
        inputHandler.sprintFlag = false;
        inputHandler.rb_Input = false;
        inputHandler.rt_Input = false;
        inputHandler.upArrow_Input = false;
        inputHandler.lt_Input=false;
        inputHandler.downArrow_Input = false;
        inputHandler.rigthArrow_Input = false;
        inputHandler.leftArrow_Input = false;
        inputHandler.enter_Input = false;
        inputHandler.jump_Input=false;
        inputHandler.inventory_Input=false;


        if (isInAir)
        {
            playerMovement.inAirTimer += Time.deltaTime;
        }
    }


    public void CheckInteractingObject()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 1f, cameraHandler.ignoreLayers))
        {
            if (hit.collider.tag == "Interactable")
            {
                Interactable interactableObject = hit.collider.GetComponent<Interactable>();
                if (interactableObject != null)
                {
                    string interactableText = interactableObject.InteractableText;
                    interactableUI.interactableText.text=interactableText;
                    interactableUIGameObject.SetActive(true);
                    if (inputHandler.enter_Input)
                    {
                        hit.collider.GetComponent<Interactable>().Interact(this);
                    }
                }
            }
        }else {
            if(interactableUIGameObject!=null){
                interactableUIGameObject.SetActive(false);
            }

            if(itemInteractableGameObject!=null && inputHandler.enter_Input){
                itemInteractableGameObject.SetActive(false);
            }
        }
    }

    public void OpenChestInteracting(Transform playerChestTransform){
        playerMovement.rigidbody.velocity=Vector3.zero;
        transform.position=playerChestTransform.transform.position;
        animatorHandler.PlayTargetAnimation("Open Chest",true);
    }
}
