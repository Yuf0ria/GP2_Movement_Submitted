using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    int horizontal, vertical;

    private void Awake()
    {
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");

    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement, bool isSprinting, bool isWalking)
    {
        if (isSprinting) { horizontalMovement = 2; }
        if (isWalking) { verticalMovement = 0.5f; }
        PlayerManager.Instance.animator.SetFloat(horizontal, horizontalMovement, 0.1f, Time.deltaTime);
        PlayerManager.Instance.animator.SetFloat(vertical, verticalMovement, 0.1f, Time.deltaTime);
    }

}
