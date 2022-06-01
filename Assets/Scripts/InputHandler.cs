using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    public bool b_Input;
    public bool rb_Input;
    public bool rt_Input;
    public bool lt_Input;
    public bool lb_Input;
    public bool y_Input;

    public bool jump_Input;
    public bool inventory_Input;
    public bool lockOn_Input;
    public bool enter_Input;
    public bool upArrow_Input;
    public bool downArrow_Input;
    public bool leftArrow_Input;
    public bool rigthArrow_Input;
    public bool critical_Attack_Input;

    public bool left_Input;
    public bool right_Input;

    public float rollInputTimer;
    public bool rollFlag;
    public bool sprintFlag;
    public bool comboFlag;
    public bool lockOnFlag;
    public bool twoHandedFlag;
    public bool inventoryFlag;

    public Transform criticalAttackRayCastStartPoint;


    PlayerControls inputActions;
    PlayerAttacker playerAttacker;
    PlayerInventory playerInventory;
    PlayerManager playerManager;
    CameraHandler cameraHandler;
    PlayerStats playerStats;
    AnimatorHandler animatorHandler;
    BlockCollider blockCollider;

    WeaponSlotManager weaponSlotManager;
    UIManager uiManager;
    Vector2 movementInput;
    Vector2 cameraInput;



    private void Awake()
    {
        y_Input = false;
        playerAttacker = GetComponentInChildren<PlayerAttacker>();
        playerInventory = GetComponent<PlayerInventory>();
        playerStats = GetComponent<PlayerStats>();
        playerManager = GetComponent<PlayerManager>();
        blockCollider=GetComponentInChildren<BlockCollider>();
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        uiManager = FindObjectOfType<UIManager>();
        cameraHandler = FindObjectOfType<CameraHandler>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
    }
    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            inputActions.PlayerAction.RB.performed += i => rb_Input = true;
            inputActions.PlayerAction.RT.performed += i => rt_Input = true;
            inputActions.PlayerAction.LT.performed += i => lt_Input = true;
            inputActions.KeyboardArrows.Rigth_Arrow.performed += i => rigthArrow_Input = true;
            inputActions.KeyboardArrows.Left_Arrow.performed += i => leftArrow_Input = true;
            inputActions.PlayerAction.LB.performed += i => lb_Input = true;
            inputActions.PlayerAction.LB.canceled += i => lb_Input = false;
            inputActions.PlayerAction.Roll.performed += i => b_Input = true;
            inputActions.PlayerAction.Roll.canceled += i => b_Input = false;
            inputActions.PlayerAction.Enter.performed += i => enter_Input = true;
            inputActions.PlayerAction.Space.performed += i => jump_Input = true;
            inputActions.PlayerAction.Inventory.performed += i => inventory_Input = true;
            inputActions.PlayerAction.LockOn.performed += i => lockOn_Input = true;
            inputActions.PlayerAction.LockOnLeft.performed += i => left_Input = true;
            inputActions.PlayerAction.LockOnRight.performed += i => right_Input = true;
            inputActions.PlayerAction.Y.performed += i => y_Input = true;
            inputActions.PlayerAction.CriticalAttack.performed += i => critical_Attack_Input = true;
        }
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


    public void TickInput(float delta)
    {

        MoveInput(delta);
        HandleRollInput(delta);
        HandleCombatInput(delta);
        HandleQuickSlotInput();
        HandleInventoryInput();
        HandleLockOnInput();
        HandleTwoHand();
        HandleCriticalAttackInput();
    }
    private void MoveInput(float delta)
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    private void HandleRollInput(float delta)
    {


        if (b_Input)
        {
            rollInputTimer += delta;
            if (playerStats.currentStamina <= 1)
            {
                b_Input = false;
                sprintFlag = false;
            }

            if (moveAmount > 0.5f && playerStats.currentStamina > 1)
            {
                sprintFlag = true;
            }


        }
        else
        {
            sprintFlag = false;
            if (rollInputTimer > 0 && rollInputTimer < 0.5)
            {
                rollFlag = true;
            }
            rollInputTimer = 0;
        }
    }

    private void HandleCombatInput(float delta)
    {

        if (rb_Input)
        {
            playerAttacker.HandleRBAction();
        }

        if (rt_Input)
        {
            playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
        }

        if(lb_Input){
            
            playerAttacker.HandleLBAction();
        }else{
            playerManager.isBlocking=false;
            if(blockCollider.blockCollider.enabled){
                blockCollider.DisableBlockCollider();
            }
        }

        if(lt_Input){
            if(twoHandedFlag){

            }else {
                playerAttacker.HandleLTAction();
            }
        }
    }

    private void HandleQuickSlotInput()
    {

        if (rigthArrow_Input)
        {
            playerInventory.ChangeRigthWeapon();
        }
        else if (leftArrow_Input)
        {
            playerInventory.ChangeLeftWeapon();
        }
    }


    private void HandleInventoryInput()
    {

        if (inventory_Input)
        {
            inventoryFlag = !inventoryFlag;
            if (inventoryFlag)
            {
                uiManager.OpenSelectWindow();
                uiManager.UpdateUI();
                uiManager.hudWindow.SetActive(false);
            }
            else
            {
                uiManager.CloseSelectWindow();
                uiManager.CloseAllInventoryWindow();
                uiManager.hudWindow.SetActive(true);
            }
        }
    }

    private void HandleLockOnInput()
    {
        if (lockOn_Input && lockOnFlag == false)
        {

            lockOn_Input = false;
            cameraHandler.HandleLockOn();
            if (cameraHandler.nearestLockOnTarget != null)
            {
                cameraHandler.currentLockOnTransform = cameraHandler.nearestLockOnTarget;
                lockOnFlag = true;
            }
        }
        else if (lockOn_Input && lockOnFlag)
        {
            lockOn_Input = false;
            lockOnFlag = false;
            cameraHandler.ClearLockOnTargets();
        }

        if (lockOnFlag && left_Input)
        {
            left_Input = false;
            cameraHandler.HandleLockOn();
            if (cameraHandler.leftLockTarget != null)
            {
                cameraHandler.currentLockOnTransform = cameraHandler.leftLockTarget;
            }
        }

        if (lockOnFlag && right_Input)
        {
            right_Input = false;
            cameraHandler.HandleLockOn();
            if (cameraHandler.rigthLockTarget != null)
            {
                cameraHandler.currentLockOnTransform = cameraHandler.rigthLockTarget;
            }
        }

        cameraHandler.SetCameraHeight();
    }

    private void HandleTwoHand()
    {
        if (y_Input)
        {
            y_Input = false;
            twoHandedFlag = !twoHandedFlag;
            if (twoHandedFlag)
            {
                weaponSlotManager.LoadWeaponOnSlot(playerInventory.rightWeapon, false);
            }
            else
            {
                weaponSlotManager.LoadWeaponOnSlot(playerInventory.rightWeapon, false);
                weaponSlotManager.LoadWeaponOnSlot(playerInventory.leftWeapon, true);
            }
        }
    }

    private void HandleCriticalAttackInput()
    {
        if (critical_Attack_Input)
        {
            critical_Attack_Input = false;
            playerAttacker.AttemptBackstabOrRiposte();
        }
    }
}
