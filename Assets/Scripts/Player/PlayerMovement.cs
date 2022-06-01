using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform cameraObject;
    InputHandler inputHandler;
    PlayerStats playerStats;
    CameraHandler cameraHandler;
    public Vector3 moveDirection;
    [HideInInspector]
    public Transform myTransform;
    [HideInInspector]
    public AnimatorHandler animatorHandler;
    public PlayerManager playerManager;

    public new Rigidbody rigidbody;
    public GameObject normalCamera;

    [Header("Movement Stats")]
    [SerializeField]
    float groundDetectedFallStartPoint = 0.5f;
    [SerializeField]
    float minimumDistanceNeededToBeginFall = 1;
    [SerializeField]
    float groundDirectionRayDistance = 0.2f;
    LayerMask ignoreGroundCheck;
    public float inAirTimer;


    [Header("Movement Stats")]
    [SerializeField]
    private float movementSpeed = 5;
    [SerializeField]
    private float rotationSpeed = 10;
    public float sprintSpeed = 7f;
    public float fallingSpeed = 45;

    [Header("Stamina Costs")]
    int rollingStaminaCost=15;
    int backStabStaminaCost=12;
    float sprintStaminaCost=0.3f;
    private void Awake()
    {

        cameraHandler = FindObjectOfType<CameraHandler>();
        rigidbody = GetComponent<Rigidbody>();
        playerManager = GetComponent<PlayerManager>();
        playerStats = GetComponent<PlayerStats>();
        inputHandler = GetComponent<InputHandler>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
    }
    private void Start()
    {
        cameraObject = Camera.main.transform;
        myTransform = transform;
        animatorHandler.Initialize();

        playerManager.isGrounded = true;
        ignoreGroundCheck = ~(1 << 8 | 1 << 11);
    }



    #region movement
    Vector3 normalVector;
    Vector3 targetVector;

    public void HandleRotation(float delta)
    {

        if (animatorHandler.canRotate)
        {
            if (inputHandler.lockOnFlag)
            {
                if (inputHandler.sprintFlag || inputHandler.rollFlag)
                {
                    Vector3 targetDir = Vector3.zero;
                    targetDir = cameraHandler.cameraTransform.forward * inputHandler.vertical;
                    targetDir += cameraHandler.cameraTransform.right * inputHandler.horizontal;

                    targetDir.Normalize();
                    targetDir.y = 0;

                    if (targetDir == Vector3.zero)
                        targetDir = transform.forward;

                    Quaternion tr = Quaternion.LookRotation(targetDir);
                    Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, rotationSpeed * Time.deltaTime);
                    transform.rotation = targetRotation;
                }
                else
                {
                    Vector3 rotationDirection = moveDirection;
                    rotationDirection = cameraHandler.currentLockOnTransform.transform.position - transform.position;
                    rotationDirection.y = 0;
                    rotationDirection.Normalize();
                    Quaternion tr = Quaternion.LookRotation(rotationDirection);
                    Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, rotationSpeed * Time.deltaTime);
                    transform.rotation = targetRotation;
                }

            }
            else
            {
                Vector3 targetDir = Vector3.zero;
                float moveOverride = inputHandler.moveAmount;

                targetDir = cameraObject.forward * inputHandler.vertical;
                targetDir += cameraObject.right * inputHandler.horizontal;

                targetDir.Normalize();
                targetDir.y = 0;

                if (targetDir == Vector3.zero)
                    targetDir = myTransform.forward;

                float rs = rotationSpeed;

                Quaternion tr = Quaternion.LookRotation(targetDir);
                Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);
                myTransform.rotation = targetRotation;
            }

        }

    }

    public void HandleMovement(float delta)
    {
        if (inputHandler.rollFlag)
        {
            return;
        }

        if (playerManager.isInteracting)
        {
            return;
        }
        moveDirection = cameraObject.forward * inputHandler.vertical;
        moveDirection += cameraObject.right * inputHandler.horizontal;
        moveDirection.Normalize();
        moveDirection.y = 0;

        float speed = movementSpeed;
        if (inputHandler.sprintFlag && inputHandler.moveAmount > 0.5f)
        {
            speed = sprintSpeed;
            playerManager.isSprinting = true;
            moveDirection *= speed;
            playerStats.TakeStaminaDamage(sprintStaminaCost);
        }
        else
        {
            if (inputHandler.moveAmount < 0.5f)
            {
                moveDirection *= movementSpeed;
                playerManager.isSprinting = false;
            }
            else
            {

                moveDirection *= speed;
                playerManager.isSprinting = false;
            }
        }


        Vector3 projectedVector = Vector3.ProjectOnPlane(moveDirection, normalVector);
        rigidbody.velocity = projectedVector;
        if (inputHandler.lockOnFlag && inputHandler.sprintFlag == false)
        {
            animatorHandler.UpdateAnimatorValues(inputHandler.vertical, inputHandler.horizontal, playerManager.isSprinting);
        }
        else
        {
            animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0, playerManager.isSprinting);
        }


    }

    public void HandleRollingAndSprinting(float delta)
    {
        if (animatorHandler.anim.GetBool("isInteracting"))
            return;

        if (playerStats.currentStamina <= 1)
            return;

        if (inputHandler.rollFlag)
        {
            moveDirection = cameraObject.forward * inputHandler.vertical;
            moveDirection += cameraObject.right * inputHandler.horizontal;
            if (inputHandler.moveAmount > 0)
            {
                animatorHandler.PlayTargetAnimation("Rolling", true);
                moveDirection.y = 0;
                Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                myTransform.rotation = rollRotation;
                playerStats.TakeStaminaDamage(rollingStaminaCost);
            }
            else
            {
                animatorHandler.PlayTargetAnimation("BackStep", true);
                playerStats.TakeStaminaDamage(backStabStaminaCost);
            }
        }
    }

    public void HandleFalling(float delta, Vector3 moveDirection)
    {
        playerManager.isGrounded = false;
        RaycastHit hit;
        Vector3 origin = myTransform.position;
        origin.y += groundDetectedFallStartPoint;

        if (Physics.Raycast(origin, myTransform.forward, out hit, 0.4f))
        {
            moveDirection = Vector3.zero;
        }

        if (playerManager.isInAir)
        {
            rigidbody.AddForce(fallingSpeed * -Vector3.up);
            rigidbody.AddForce(moveDirection * fallingSpeed / 5f);
        }

        Vector3 dir = moveDirection;
        dir.Normalize();
        origin += dir * groundDirectionRayDistance;
        targetVector = myTransform.position;

        Debug.DrawRay(origin, -Vector3.up * minimumDistanceNeededToBeginFall, Color.red, 0.1f, false);
        if (Physics.Raycast(origin, -Vector3.up, out hit, minimumDistanceNeededToBeginFall, ignoreGroundCheck))
        {
            normalVector = hit.normal;
            Vector3 tp = hit.point;
            playerManager.isGrounded = true;
            targetVector.y = tp.y;


            if (playerManager.isInAir)
            {
                if (inAirTimer > 0.5f)
                {

                    animatorHandler.PlayTargetAnimation("Land", true);
                    inAirTimer = 0;
                }
                else
                {
                    animatorHandler.PlayTargetAnimation("Empty", false);
                    inAirTimer = 0;
                }
                playerManager.isInAir = false;
            }

        }
        else
        {
            if (playerManager.isGrounded)
            {
                playerManager.isGrounded = false;
            }

            if (playerManager.isInAir == false)
            {
                if (playerManager.isInteracting == false)
                {
                    animatorHandler.PlayTargetAnimation("Falling", true);
                }

                Vector3 vel = rigidbody.velocity;
                vel.Normalize();
                rigidbody.velocity = vel * (movementSpeed / 2);
                playerManager.isInAir = true;
            }
        }

        if (playerManager.isGrounded)
        {
            if (playerManager.isInteracting || inputHandler.moveAmount > 0)
            {
                myTransform.position = Vector3.Lerp(myTransform.position, targetVector, Time.deltaTime / 0.1f);
            }
            else
            {
                myTransform.position = targetVector;
            }
        }
    }

    public void HandleJumping()
    {
        if (playerManager.isInteracting)
        {
            return;
        }

        if (playerStats.currentStamina <= 1)
            return;

        if (inputHandler.jump_Input)
        {
            if (inputHandler.moveAmount > 0)
            {
                moveDirection = cameraObject.forward * inputHandler.vertical;
                moveDirection += cameraObject.right * inputHandler.horizontal;
                animatorHandler.PlayTargetAnimation("Jumping", true);
                moveDirection.y = 0;
                Quaternion jumpRotation = Quaternion.LookRotation(moveDirection);
                myTransform.rotation = jumpRotation;
            }
        }
    }
    #endregion
}
