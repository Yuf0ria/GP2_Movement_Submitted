using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLocomotion : MonoBehaviour
{
    Vector3 moveDirection;
    Transform cameraObject;


    private void Start()
    {
        cameraObject = Camera.main.transform;
    }

    public void HandlesAllMovement()
    {
        HandlesMovement();
        HandlesRotation();
    }

    private void HandlesMovement()
    {
        moveDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (PlayerManager.Instance.isSprinting == true)
        {
            moveDirection = moveDirection * PlayerManager.Instance.sprintSpeed;
        }
        else if (PlayerManager.Instance.isWalking == true)
        {
            moveDirection = moveDirection * PlayerManager.Instance.walkingSpeed;
        }
        else
        {
            moveDirection = moveDirection * PlayerManager.Instance.moveSpeed;
        }

        moveDirection = moveDirection * PlayerManager.Instance.moveSpeed;
        Vector3 movementVelocity = moveDirection;
        PlayerManager.Instance.rigidBody.velocity = movementVelocity;
    }

    private void HandlesRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation,targetRotation,PlayerManager.Instance.rotSpeed);

        transform.rotation = playerRotation;
    }

}
