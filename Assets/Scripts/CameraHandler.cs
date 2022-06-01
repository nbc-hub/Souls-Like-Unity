using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform targetTransform;
    public Transform cameraTransform;
    public Transform cameraPivotTransform;
    private Transform myTransform;
    private Vector3 cameraTransformPosition;
    public LayerMask ignoreLayers;
    public LayerMask environmentLayer;
    private Vector3 cameraFollowVelocity = Vector3.zero;

    public static CameraHandler singleton;
    PlayerManager playerManager;
    InputHandler inputHandler;
    public float lookSpeed = 0.1f;
    public float followSpeed = 0.1f;
    public float pivotSpeed = 0.03f;

    private float lookAngle;
    private float pivotAngle;
    private float targetPosition;
    private float defaultPosition;
    public float minimumPivot = -35f;
    public float maximumPivot = 35f;

    public float cameraSphereRadius = 0.2f;
    public float cameraCollisionOffSet = 0.2f;
    public float minimumCollisionOffSet = 0.2f;

    public float maximumLockOnDistance = 30f;
    public float lockedPivotPosition = 2.25f;
    public float unlockedPivotPosition = 1.65f;
    public CharacterManager currentLockOnTransform;
    public CharacterManager nearestLockOnTarget;

    public CharacterManager leftLockTarget;
    public CharacterManager rigthLockTarget;
    List<CharacterManager> availableTargets = new List<CharacterManager>();

    private void Awake()
    {

        singleton = this;
        myTransform = transform;
        defaultPosition = cameraTransform.localPosition.z;
        ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10 | 1 << 12 | 1 << 13);
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        inputHandler = FindObjectOfType<InputHandler>();
        playerManager=FindObjectOfType<PlayerManager>();
    }

    private void Start() {
        environmentLayer=LayerMask.NameToLayer("Environment");
    }
    public void FollowTarget(float delta)
    {
        Vector3 targetPosition = Vector3.SmoothDamp(myTransform.position, targetTransform.position, ref cameraFollowVelocity, delta / followSpeed);
        myTransform.position = targetPosition;

        CameraHandleCollision(delta);
    }

    public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
    {
        if (inputHandler.lockOnFlag == false && currentLockOnTransform == null)
        {
            lookAngle += (mouseXInput * lookSpeed) / delta;
            pivotAngle -= (mouseYInput * pivotSpeed) / delta;
            pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);

            Vector3 rotation = Vector3.zero;
            rotation.y = lookAngle;
            Quaternion targetRotation = Quaternion.Euler(rotation);
            myTransform.rotation = targetRotation;
            rotation = Vector3.zero;
            rotation.x = pivotAngle;
            targetRotation = Quaternion.Euler(rotation);
            cameraPivotTransform.localRotation = targetRotation;
        }
        else
        {
            Vector3 dir = currentLockOnTransform.transform.position - transform.position;
            dir.Normalize();
            dir.y = 0;
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = targetRot;

            dir = currentLockOnTransform.transform.position - cameraPivotTransform.position;
            dir.Normalize();
            targetRot = Quaternion.LookRotation(dir);
            Vector3 eulerAngle = targetRot.eulerAngles;
            eulerAngle.y = 0;
            cameraPivotTransform.localEulerAngles = eulerAngle;
        }

    }

    private void CameraHandleCollision(float delta)
    {
        targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivotTransform.position;
        direction.Normalize();

        if (Physics.SphereCast(cameraPivotTransform.position, cameraSphereRadius, direction, out hit, Mathf.Abs(targetPosition), ignoreLayers))
        {
            float dis = Vector3.Distance(cameraPivotTransform.position, hit.point);
            targetPosition = -(dis - cameraCollisionOffSet);

            if (Mathf.Abs(targetPosition) < minimumCollisionOffSet)
            {
                targetPosition = -minimumCollisionOffSet;
            }
        }
        cameraTransformPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, delta / 0.2f);
        cameraTransform.localPosition = cameraTransformPosition;
    }

    public void HandleLockOn()
    {
        float shortestDistance = Mathf.Infinity;
        float shortestDistanceOfLeftTarget = -Mathf.Infinity;
        float shortestDistanceOfRigthTarget = Mathf.Infinity;
        Collider[] colliders = Physics.OverlapSphere(targetTransform.position, 25f);
        RaycastHit hit;

        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterManager character = colliders[i].GetComponent<CharacterManager>();
            if (character != null)
            {
                Vector3 lockTargetDirection = character.transform.position - targetTransform.position;
                float distanceFromTarget = Vector3.Distance(targetTransform.position, character.transform.position);
                float angle = Vector3.Angle(lockTargetDirection, cameraTransform.forward);
                if (character.transform.root != targetTransform.root
                && angle < 50 && angle > -50
                && distanceFromTarget <= maximumLockOnDistance)
                {
                    if(Physics.Linecast(playerManager.LockOnTransform.position,character.LockOnTransform.position,out hit)){
                        Debug.DrawLine(playerManager.LockOnTransform.position,character.transform.position);
                        if(hit.transform.gameObject.layer==environmentLayer){

                        }else{

                         availableTargets.Add(character);
                        }
                    }
                }
            }
        }


        for (int k = 0; k < availableTargets.Count; k++)
        {
            float distanceFromTarget = Vector3.Distance(targetTransform.position, availableTargets[k].transform.position);
            if (distanceFromTarget < shortestDistance)
            {
                shortestDistance = distanceFromTarget;
                nearestLockOnTarget = availableTargets[k];
            }

            if (inputHandler.lockOnFlag)
            {
                /*
                Vector3 relativeEnemyPosition = currentLockOnTransform.transform.InverseTransformDirection(availableTargets[k].transform.position);
                var distanceFromLeftTarget = currentLockOnTransform.transform.position.x + availableTargets[k].transform.position.x;
                var distanceFromRightTarget = currentLockOnTransform.transform.position.x - availableTargets[k].transform.position.x;

*/
                 Vector3 relativeEnemyPosition = inputHandler.transform.InverseTransformDirection(availableTargets[k].transform.position);
                 var distanceFromLeftTarget = relativeEnemyPosition.x;
                 var distanceFromRightTarget = relativeEnemyPosition.x;

                if (relativeEnemyPosition.x <= 0.00 && distanceFromLeftTarget > shortestDistanceOfLeftTarget && availableTargets[k]!=currentLockOnTransform)
                {
                    shortestDistanceOfLeftTarget = distanceFromLeftTarget;
                    leftLockTarget = availableTargets[k];
                }

                if (relativeEnemyPosition.x >= 0.00 && distanceFromRightTarget < shortestDistanceOfRigthTarget && availableTargets[k]!=currentLockOnTransform)
                {
                    shortestDistanceOfRigthTarget = distanceFromRightTarget;
                    rigthLockTarget = availableTargets[k];
                }
            }
        }
    }

    public void ClearLockOnTargets()
    {
        availableTargets.Clear();
        nearestLockOnTarget = null;
        currentLockOnTransform = null;
    }

    public void SetCameraHeight()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 newLockedPosition = new Vector3(0, lockedPivotPosition);
        Vector3 newUnlockedPosition = new Vector3(0, unlockedPivotPosition);

        if (currentLockOnTransform != null)
        {

            cameraPivotTransform.transform.localPosition = Vector3.SmoothDamp(cameraPivotTransform.transform.localPosition, newLockedPosition, ref velocity, Time.deltaTime);
        }
        else
        {
            cameraPivotTransform.transform.localPosition = Vector3.SmoothDamp(cameraPivotTransform.transform.localPosition, newUnlockedPosition, ref velocity, Time.deltaTime);
        }
    }
}
